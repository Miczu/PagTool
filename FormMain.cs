using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Threading;
using System.Windows.Forms;
using Newtonsoft.Json;
using System.Net.Http;
using TwitchLib.Client.Events;

// todo lineage modes: I,II,III / 1,2,3 / #1, #2, #3 / One, Two, Three / The First, The Second / etc
// todo esc key closes addtolist dialog and enter selects ok
// also give an option to not include this at all

// considering renaming to PogTool LUL
namespace PagTool
{
    //class to package data into one object for serialization
    public class DataSet
    {
        public List<string> listWaiting;
        public List<string> listActive;
        public List<string> listDead;
        public Dictionary<string, int> dictLineage;

        public DataSet(List<string> waiting, List<string> active, List<string> dead, Dictionary<string, int> lineage)
        {
            listWaiting = waiting;
            listActive = active;
            listDead = dead;
            dictLineage = lineage;
        }
    }
    
    //catch-all for general application settings
    public class GeneralSettings
    {
        public bool DoVerboseLog = false; //enable extra verbose logging in the debug log. for reasons?
        public bool DoConnectOnStartup = true; //connect automaticall when the app launches using stored creds.
        public int AutoRefreshSeconds = 10; // seconds it takes for the ui to update all its information visually

        public bool DoAskConfirmClearButtons = true; // should i pop up a confirm dialog when pressing the 'clear <list>' buttons in the UI?
                                        // the red "clear all" button will ALWAYS get an 'are you sure' dialog. 
        public bool DoAskConfirmClearHotkey = false; // should i pop up a confirm dialog when using the 'clear list' hotkey?

        public enum LINEAGE_MODE
        {
            LINEAGE_NONE = 0,   //no lineage
            LINEAGE_NUMERAL,    //1, 2, 3
            LINEAGE_WORDS,      //the First, the Second
            LINEAGE_ROMAN       //I, II, III
        }
        public LINEAGE_MODE LineageMode = LINEAGE_MODE.LINEAGE_NONE; // which mode should the lineage be printed in
        public bool DoOmitFirstLineage = true; // whether or not the first lineage should be omitted

        //defaults only
        public GeneralSettings() { }

        //overridable
        /* this code is never actually used
        public GeneralSettings(bool doVerboseLog, bool doConnectOnStartup, int autoRefreshSeconds,
                        bool doAskConfirmClearButtons, bool doAskConfirmClearHotkey)
        {
            DoVerboseLog = doVerboseLog;
            DoConnectOnStartup = doConnectOnStartup;
            AutoRefreshSeconds = autoRefreshSeconds;
            DoAskConfirmClearButtons = doAskConfirmClearButtons;
            DoAskConfirmClearHotkey = doAskConfirmClearHotkey;
        }
        */
    }

    public partial class FormMain : Form
    {
        #region Field Variable
        
        //she do everything with irc chat
        private ChatBot _twitchChatBot;
        
        //HTTP client that will be passed around application-wide to make API calls or other HTTP requests
        // https://stackoverflow.com/questions/4015324/how-to-make-an-http-post-web-request
        public static readonly HttpClient HttpClient = new HttpClient();

        //plaintext credentials :^) #NoZeroDays #OCSPCertified #GirlbossingIt TODO: disclose this to the users in the readme lmao
        string[] _twitchBotCredentials;
                
        //general settings file, anything that doesn't have its own dialog form to tweak falls in here
        public GeneralSettings GeneralSettings;

        // dialog results: store all the information for each configurable aspect to the program
        public ConfigCommandAliasResult ConfigCommandAlias; //command aliases
        public ConfigCommandBehaviorResult ConfigCommandBehavior; //chat responses and switches to define behaviors
        public ConfigHotkeyResult ConfigHotkey; //hotkey information

        //three lists.
        public List<string> _listWaiting = new List<string>();
        public List<string> _listActive = new List<string>();
        public List<string> _listDead = new List<string>();

        // name, generation
        public Dictionary<string, int> _dictLineage = new Dictionary<string, int>();

        //used to let threads know if the application is terminating
        private bool _isApplicationClosing = false;
        public Thread updateAndRefreshComponentsThread;
        public Thread chatReminderThread;

        #endregion
        
        public FormMain()
        {
            //load twitch credentials and create 
            _twitchBotCredentials = CheckFileAndLoadTwitchCredentials("_secret.safe");
            
            // quickly instantiate this
            _twitchChatBot = new ChatBot(this);

            // Load the form's components, then launch async tasks
            InitializeComponent();

            //TODO load config.ini data
            //if these files don't exist, create a new default config Result for each respectively and then store it. otherwise, parse the file
            TryParseConfigCommandAlias();
            TryParseConfigCommandBehavior();
            TryParseConfigHotkey();
            TryParseGeneralSettings();
            //etc etc

            //this will check default CurrentDataSet file for any data from last run, and load it into memory
            TryParseDataSet();
            
            //first, update all elements manually
            DoAllUpdates();
            
            //register global hotkeys
            RegisterAllHotkeys();

            // then, start thread to auto-refresh contents of components every 5 seconds
            updateAndRefreshComponentsThread = new Thread(new ThreadStart(UpdateThreadTimer));
            updateAndRefreshComponentsThread.Start();

            // connect twitch bot to IRC chat
            if(GeneralSettings.DoConnectOnStartup)
                _twitchChatBot.Connect(_twitchBotCredentials[0],
                _twitchBotCredentials[1], _twitchBotCredentials[2]); 
            
            // launch chat reminder thread
            chatReminderThread = new Thread(new ThreadStart(ChatReminderThreadTimer));
            chatReminderThread.Start();
        }

        #region Hotkey Management
        
        //variables to store hotkey hook IDs, const here for static context (IDs don't need to change ever, just be re-registered)
        public const int HKIDSelectRandomUser = 1; 
        public const int HKIDClearAllLists = 2; 
        public const int HKIDShuffleIntoWaitlist = 3; 

        //import hotkey register functions
        [DllImport("user32.dll")]
        public static extern bool RegisterHotKey(IntPtr hWnd, int id, int fsModifiers, int key);
        [DllImport("user32.dll")]
        public static extern bool UnregisterHotKey(IntPtr hWnd, int id);

        public void RegisterAllHotkeys()
        {
            //register all keys
            RegisterHotKey(this.Handle, HKIDSelectRandomUser, ConfigHotkey.HKModSelectRandomUser, ConfigHotkey.HKKeySelectRandomUser);
            RegisterHotKey(this.Handle, HKIDClearAllLists, ConfigHotkey.HKModClearAllLists, ConfigHotkey.HKKeyClearAllLists);
            RegisterHotKey(this.Handle, HKIDShuffleIntoWaitlist, ConfigHotkey.HKModShuffleIntoWaitlist, ConfigHotkey.HKKeyShuffleIntoWaitlist);
                        
        }

        public void UnregisterAllHotkeys()
        {
            //unregister all hotkeys
            UnregisterHotKey(this.Handle, HKIDSelectRandomUser);
            UnregisterHotKey(this.Handle, HKIDClearAllLists);
            UnregisterHotKey(this.Handle, HKIDShuffleIntoWaitlist);
        }

        //what to do when a global hotkey is triggered
        protected override void WndProc(ref Message m)
        {
            if (m.Msg == 0x0312 && m.WParam.ToInt32() == HKIDSelectRandomUser)
            {
                //select random user
                //MessageBox.Show("select random user hotkey triggered");
                TrySelectRandomUser();
            }
            
            if (m.Msg == 0x0312 && m.WParam.ToInt32() == HKIDClearAllLists)
            {
                //ALWAYS prompt for this one.
                if(MessageBox.Show("Are you REALLY sure?\n" +
                                   "This will delete ALL currently loaded data!\n", 
                    "Confirm Delete", MessageBoxButtons.OKCancel) == DialogResult.OK)
                {
                    //i don't fucking trust my users LMAO
                    WriteAllDataToFiles("MostRecent-ClearAll-Data.Backup"); //sorry buster i'm not allowing any accidents here
                
                    //delete everything and update
                    _listWaiting.Clear();
                    _listActive.Clear();
                    _listDead.Clear();
                    _dictLineage.Clear();
                
                    _twitchChatBot.LogLine($"Cleared all data... a backup was made, just in case.", ChatBot.LOG_LEVEL.LOG_INFO);
                    DoAllUpdates();                        
                }
            }
                        
            if (m.Msg == 0x0312 && m.WParam.ToInt32() == HKIDShuffleIntoWaitlist)
            {
                //todo move this and the above into helper functions for sanity
                _listWaiting.AddRange(_listDead.ToArray());
                _listDead.Clear();
            
                _listWaiting.AddRange(_listActive.ToArray());
                _listActive.Clear();
            
                _twitchChatBot.LogLine("Shuffled contents of both ListDead and ListActive into ListWaiting.", ChatBot.LOG_LEVEL.LOG_INFO);
                DoAllUpdates();
            }

            base.WndProc(ref m);
        }

        #endregion

        #region Component Update Thread

        void UpdateThreadTimer()
        {
            while (!_isApplicationClosing)
            {
                Thread.Sleep(1000 * GeneralSettings.AutoRefreshSeconds); //set in debug screen
                
                //visual only
                DoAllUpdates();
                
                // save data
                WriteAllConfigToFiles();
                WriteAllDataToFiles();
            }
        }
        
        void ChatReminderThreadTimer()
        {
            //wait a bit first to give client time to connect
            Thread.Sleep(5000);
            
            while (!_isApplicationClosing)
            {
                Thread.Sleep(1000 * ConfigCommandBehavior.ChatReminderSeconds); // set in cmdbehavior
                
                //send message to chat
                _twitchChatBot.Chat(ConfigCommandBehavior.ChatReminder);
            }
        }

        void DoAllUpdates()
        {
            //update the text from the log output
            UpdateText(richTextBox_ConsoleDebugLog, _twitchChatBot.LogOutput);
            
            //update the display listBoxes
            listBox_ListWaiting.Items.Clear(); listBox_ListWaiting.Items.AddRange(_listWaiting.ToArray());
            listBox_ListActive.Items.Clear();  listBox_ListActive.Items.AddRange( _listActive.ToArray());
            listBox_ListDead.Items.Clear();    listBox_ListDead.Items.AddRange(   _listDead.ToArray());

            if (_listWaiting.Count <= 0)
            {
                //todo CMD WAITLIST EMPTY
                listBox_ListWaiting.Items.Add("(waiting list is empty...)");
            }
            
            if (_listActive.Count <= 0) listBox_ListActive.Items.Add("(active list is empty...)");
            if (_listDead.Count <= 0) listBox_ListDead.Items.Add("(dead list is empty...)");

            //update the Lineage listbox
            listBox_CurrentLineage.Items.Clear();
            foreach (string s in _dictLineage.Keys)
            {
                _dictLineage.TryGetValue(s, out int val);
                listBox_CurrentLineage.Items.Add(s + ": " + val.ToString());
            }

            //set the state of all General Settings
            checkBox_doVerboseLogging.Checked = GeneralSettings.DoVerboseLog;
            checkBox_ConnectOnStartup.Checked = GeneralSettings.DoConnectOnStartup;
            numericUpDown_AutoRefreshSeconds.Value = GeneralSettings.AutoRefreshSeconds;
        }

        // https://www.codeproject.com/articles/269787/accessing-windows-forms-controls-across-threads
        delegate void UpdateTextDelegate(Control control, string text);
        void UpdateText(Control control, string text)
        {
            if (control.InvokeRequired)
            {
                UpdateTextDelegate del = new UpdateTextDelegate(UpdateText);
                control.Invoke(del, control, text);
            }
            else
                control.Text = text;
        }

        #endregion

        #region File I/O

        string[] CheckFileAndLoadTwitchCredentials(string filepath)
        {
            if (File.Exists(filepath))
            {
                string[] data = File.ReadAllLines(filepath);
                if (data.Length == 3 && !String.IsNullOrWhiteSpace(data[0])) // quick sanity check
                    return data;
                
                //bad data? pop open the credential config dialog
                ConfigTwitchCredentialsDialog configTwitchCredentialsDialog = new ConfigTwitchCredentialsDialog();
                data = configTwitchCredentialsDialog.Show(data); //show dialog 

                //try again 
                if (data.Length == 3 && !String.IsNullOrWhiteSpace(data[0])) // quick sanity check
                {
                    File.WriteAllLines(filepath, data); //save these new changes
                    return data;
                }

                //otherwise, fuck it! start anyways
                return new[] {"DoesNotExist", "DoesNotExist", "DoesNotExist"};
            }
            else
            {
                //bad data? pop open the credential config dialog
                ConfigTwitchCredentialsDialog configTwitchCredentialsDialog = new ConfigTwitchCredentialsDialog();
                string[] data = configTwitchCredentialsDialog.Show(new[] {"","",""}); //show dialog 

                //see if it's ok?
                if (data.Length == 3 && !String.IsNullOrWhiteSpace(data[0])) // quick sanity check
                {
                    File.WriteAllLines(filepath, data); //save these new changes
                    return data;
                }
                
                //otherwise, fuck it! start anyways
                return new[] {"DoesNotExist", "DoesNotExist", "DoesNotExist"};
            }
        }
        
        //if it exists, deserialize the contents. otherwise, create a new default object, use it, and write it to the file
        public void TryParseConfigCommandAlias()
        {
            if (File.Exists("CommandAlias.config"))
                ConfigCommandAlias =
                    JsonConvert.DeserializeObject<ConfigCommandAliasResult>(File.ReadAllText("CommandAlias.config"));
            else
            {
                ConfigCommandAlias = new ConfigCommandAliasResult();
                File.WriteAllText("CommandAlias.config", JsonConvert.SerializeObject(ConfigCommandAlias));
            }
        }
        public void TryParseConfigCommandBehavior()
        {
            if (File.Exists("CommandBehavior.config"))
                ConfigCommandBehavior =
                    JsonConvert.DeserializeObject<ConfigCommandBehaviorResult>(File.ReadAllText("CommandBehavior.config"));
            else
            {
                ConfigCommandBehavior = new ConfigCommandBehaviorResult();
                File.WriteAllText("CommandBehavior.config", JsonConvert.SerializeObject(ConfigCommandBehavior));
            }
        }
        public void TryParseConfigHotkey()
        {
            if (File.Exists("Hotkey.config"))
                ConfigHotkey =
                    JsonConvert.DeserializeObject<ConfigHotkeyResult>(File.ReadAllText("Hotkey.config"));
            else
            {
                ConfigHotkey = new ConfigHotkeyResult();
                File.WriteAllText("Hotkey.config", JsonConvert.SerializeObject(ConfigHotkey));
            }
        }
        
        public void TryParseGeneralSettings()
        {
            if (File.Exists("GeneralSettings.config"))
                GeneralSettings =
                    JsonConvert.DeserializeObject<GeneralSettings>(File.ReadAllText("GeneralSettings.config"));
            else
            {
                GeneralSettings = new GeneralSettings();
                File.WriteAllText("GeneralSettings.config", JsonConvert.SerializeObject(GeneralSettings));
            }
        }

        // save all Config to files
        public void WriteAllConfigToFiles()
        {
            File.WriteAllText("CommandAlias.config", JsonConvert.SerializeObject(ConfigCommandAlias));
            File.WriteAllText("CommandBehavior.config", JsonConvert.SerializeObject(ConfigCommandBehavior));
            File.WriteAllText("Hotkey.config", JsonConvert.SerializeObject(ConfigHotkey));
            File.WriteAllText("GeneralSettings.config", JsonConvert.SerializeObject(GeneralSettings));
            // etc...
        }

        // load dataset from path
        public void TryParseDataSet(string path = "CurrentDataSet")
        {
            if (File.Exists(path))
            {
                DataSet newDataSet = JsonConvert.DeserializeObject<DataSet>(File.ReadAllText(path));
                _listWaiting = newDataSet.listWaiting;
                _listActive = newDataSet.listActive;
                _listDead = newDataSet.listDead;
                _dictLineage = newDataSet.dictLineage;
            }
            else
                WriteAllDataToFiles(path);
        }

        //save current dataset to filepath
        public void WriteAllDataToFiles(string path = "CurrentDataSet")
        {
            DataSet currentDataSet = new DataSet(_listWaiting, _listActive, _listDead, _dictLineage);
            File.WriteAllText(path, JsonConvert.SerializeObject(currentDataSet));
        }

        #endregion

        #region Data Structure Interactions

        public void TryAddNameToList(List<string> list, string name, OnChatCommandReceivedArgs e = null)
        {
            //check all three lists for redundancy
            //check blacklist
            //if all good, add <name> to <list>

            // first, check the blacklist. TODO BLACKLLIST
            
            // is the name anywhere in the lists? 
            if (_listWaiting.Contains(name) || _listActive.Contains(name) || _listDead.Contains(name))
            {
                //reject attempt and log. name already exists in list.
                _twitchChatBot.LogLine($"Name already exists: <{name}>. Skipped.", ChatBot.LOG_LEVEL.LOG_WARNING);
                if(e != null) //if e was passed to this function, it's from chat, and we should reply in turn
                    _twitchChatBot.Chat(_twitchChatBot.TryReplaceFormatStrings(ConfigCommandBehavior.ResponseCmdNameAlreadyExists, e));
            }
            else //name doesn't exist in list. go ahead!
            {
                list.Add(name);
                _twitchChatBot.LogLine($"Added to list: <{name}>.", ChatBot.LOG_LEVEL.LOG_INFO);
                if(e != null) //if e was passed to this function, it's from chat, and we should reply in turn
                    _twitchChatBot.Chat(_twitchChatBot.TryReplaceFormatStrings(ConfigCommandBehavior.ResponseCmdNameAdd, e));
            }
        }

        public void TrySelectRandomUser() //get a random user from waitlist (according to SelectRandom behavior options)
        {
            if (_listWaiting.Count > 0) //make sure the list isn't empty
            { //todo behavior & priority switches
                int pos = new Random().Next(_listWaiting.Count - 1);
                string selected = _listWaiting.ElementAt(pos); //get random position in list
                
                // update lineage of selected
                // check if name exists in lineage, if so increment. otherwise, add new at 1
                if (_dictLineage.ContainsKey(selected))
                {
                    _dictLineage.TryGetValue(selected, out int val);
                    _dictLineage[selected] = ++val;
                }
                else
                {
                    _dictLineage.Add(selected, 1);
                }
                
                PutSelectedToClipboard(selected);
                
                _listActive.Add(selected);
                _listWaiting.Remove(selected);
                
                // log drawn user
                _twitchChatBot.LogLine($"Selected random user from Waiting list: <{selected}>. Added to Active list.", ChatBot.LOG_LEVEL.LOG_INFO);
                
                // send response message to chat
                _twitchChatBot.Chat(_twitchChatBot.TryReplaceFormatStrings(ConfigCommandBehavior.ResponseCmdUserDrawn, selected));
                // update display lists
                DoAllUpdates();
            }
            else
            { // list is empty
                //log that and return
                _twitchChatBot.LogLine($"Waiting list is empty! Cannot select random user.", ChatBot.LOG_LEVEL.LOG_WARNING);
                _twitchChatBot.Chat(ConfigCommandBehavior.ResponseCmdWaitlistEmpty);
            }
        }

        public void PutSelectedToClipboard(string selected)
        {
            _dictLineage.TryGetValue(selected, out int value);
            
            string lineageAppendText = "";
            if (GeneralSettings.LineageMode != GeneralSettings.LINEAGE_MODE.LINEAGE_NONE)
            { //if we aren't using lineages, don't set the append text
                switch (value)
                {
                    // i am so sorry for this awful branching i don't know if there's a better way LMAO please let me know
                    case 1:
                        if(!GeneralSettings.DoOmitFirstLineage) //check that we actually want to set the text for the first lineage
                            switch (GeneralSettings.LineageMode)
                            {
                                case GeneralSettings.LINEAGE_MODE.LINEAGE_NUMERAL:
                                    lineageAppendText = " 1";
                                    break;
                                case GeneralSettings.LINEAGE_MODE.LINEAGE_WORDS:
                                    lineageAppendText = " the First";
                                    break;
                                case GeneralSettings.LINEAGE_MODE.LINEAGE_ROMAN:
                                    lineageAppendText = " I";
                                    break;
                            }
                        break;
                    
                    case 2:
                        switch (GeneralSettings.LineageMode)
                        {
                            case GeneralSettings.LINEAGE_MODE.LINEAGE_NUMERAL:
                                lineageAppendText = " 2";
                                break;
                            case GeneralSettings.LINEAGE_MODE.LINEAGE_WORDS:
                                lineageAppendText = " the Second";
                                break;
                            case GeneralSettings.LINEAGE_MODE.LINEAGE_ROMAN:
                                lineageAppendText = " II";
                                break;
                        }
                        break;
                    
                    case 3:
                        switch (GeneralSettings.LineageMode)
                        {
                            case GeneralSettings.LINEAGE_MODE.LINEAGE_NUMERAL:
                                lineageAppendText = " 3";
                                break;
                            case GeneralSettings.LINEAGE_MODE.LINEAGE_WORDS:
                                lineageAppendText = " the Third";
                                break;
                            case GeneralSettings.LINEAGE_MODE.LINEAGE_ROMAN:
                                lineageAppendText = " III";
                                break;
                        }
                        break;
                    
                    case 4:
                        switch (GeneralSettings.LineageMode)
                        {
                            case GeneralSettings.LINEAGE_MODE.LINEAGE_NUMERAL:
                                lineageAppendText = " 4";
                                break;
                            case GeneralSettings.LINEAGE_MODE.LINEAGE_WORDS:
                                lineageAppendText = " the Fourth";
                                break;
                            case GeneralSettings.LINEAGE_MODE.LINEAGE_ROMAN:
                                lineageAppendText = " IV";
                                break;
                        }
                        break;
                    
                    case 5:
                        switch (GeneralSettings.LineageMode)
                        {
                            case GeneralSettings.LINEAGE_MODE.LINEAGE_NUMERAL:
                                lineageAppendText = " 5";
                                break;
                            case GeneralSettings.LINEAGE_MODE.LINEAGE_WORDS:
                                lineageAppendText = " the Fifth";
                                break;
                            case GeneralSettings.LINEAGE_MODE.LINEAGE_ROMAN:
                                lineageAppendText = " V";
                                break;
                        }
                        break;
                    
                    case 6:
                        switch (GeneralSettings.LineageMode)
                        {
                            case GeneralSettings.LINEAGE_MODE.LINEAGE_NUMERAL:
                                lineageAppendText = " 6";
                                break;
                            case GeneralSettings.LINEAGE_MODE.LINEAGE_WORDS:
                                lineageAppendText = " the Sixth";
                                break;
                            case GeneralSettings.LINEAGE_MODE.LINEAGE_ROMAN:
                                lineageAppendText = " VI";
                                break;
                        }
                        break;
                        
                    case 7:
                        switch (GeneralSettings.LineageMode)
                        {
                            case GeneralSettings.LINEAGE_MODE.LINEAGE_NUMERAL:
                                lineageAppendText = " 7";
                                break;
                            case GeneralSettings.LINEAGE_MODE.LINEAGE_WORDS:
                                lineageAppendText = " the Seventh";
                                break;
                            case GeneralSettings.LINEAGE_MODE.LINEAGE_ROMAN:
                                lineageAppendText = " VII";
                                break;
                        }
                        break;

                    case 8: 
                        switch (GeneralSettings.LineageMode)
                        {
                            case GeneralSettings.LINEAGE_MODE.LINEAGE_NUMERAL:
                                lineageAppendText = " 8";
                                break;
                            case GeneralSettings.LINEAGE_MODE.LINEAGE_WORDS:
                                lineageAppendText = " the Eighth";
                                break;
                            case GeneralSettings.LINEAGE_MODE.LINEAGE_ROMAN:
                                lineageAppendText = " VIII";
                                break;
                        }
                        break;

                    case 9:
                        switch (GeneralSettings.LineageMode)
                        {
                            case GeneralSettings.LINEAGE_MODE.LINEAGE_NUMERAL:
                                lineageAppendText = " 9";
                                break;
                            case GeneralSettings.LINEAGE_MODE.LINEAGE_WORDS:
                                lineageAppendText = " the Ninth";
                                break;
                            case GeneralSettings.LINEAGE_MODE.LINEAGE_ROMAN:
                                lineageAppendText = " IX";
                                break;
                        }
                        break;
                    
                    case 10:
                        switch (GeneralSettings.LineageMode)
                        {
                            case GeneralSettings.LINEAGE_MODE.LINEAGE_NUMERAL:
                                lineageAppendText = " 10";
                                break;
                            case GeneralSettings.LINEAGE_MODE.LINEAGE_WORDS:
                                lineageAppendText = " the Tenth";
                                break;
                            case GeneralSettings.LINEAGE_MODE.LINEAGE_ROMAN:
                                lineageAppendText = " X";
                                break;
                        }
                        break;
                    
                    case 11:
                        switch (GeneralSettings.LineageMode)
                        {
                            case GeneralSettings.LINEAGE_MODE.LINEAGE_NUMERAL:
                                lineageAppendText = " 11";
                                break;
                            case GeneralSettings.LINEAGE_MODE.LINEAGE_WORDS:
                                lineageAppendText = " the Eleventh";
                                break;
                            case GeneralSettings.LINEAGE_MODE.LINEAGE_ROMAN:
                                lineageAppendText = " XI";
                                break;
                        }
                        break;
                    
                    case 12:
                        switch (GeneralSettings.LineageMode)
                        {
                            case GeneralSettings.LINEAGE_MODE.LINEAGE_NUMERAL:
                                lineageAppendText = " 12";
                                break;
                            case GeneralSettings.LINEAGE_MODE.LINEAGE_WORDS:
                                lineageAppendText = " the Twelfth";
                                break;
                            case GeneralSettings.LINEAGE_MODE.LINEAGE_ROMAN:
                                lineageAppendText = " XII";
                                break;
                        }
                        break;
                    
                    case 13:
                        switch (GeneralSettings.LineageMode)
                        {
                            case GeneralSettings.LINEAGE_MODE.LINEAGE_NUMERAL:
                                lineageAppendText = " 13";
                                break;
                            case GeneralSettings.LINEAGE_MODE.LINEAGE_WORDS:
                                lineageAppendText = " the Thirteenth";
                                break;
                            case GeneralSettings.LINEAGE_MODE.LINEAGE_ROMAN:
                                lineageAppendText = " XIII";
                                break;
                        }
                        break;
                        
                    case 14:
                        switch (GeneralSettings.LineageMode)
                        {
                            case GeneralSettings.LINEAGE_MODE.LINEAGE_NUMERAL:
                                lineageAppendText = " 14";
                                break;
                            case GeneralSettings.LINEAGE_MODE.LINEAGE_WORDS:
                                lineageAppendText = " the Fourteenth";
                                break;
                            case GeneralSettings.LINEAGE_MODE.LINEAGE_ROMAN:
                                lineageAppendText = " XIV";
                                break;
                        }
                        break;
                                            
                    case 15:
                        switch (GeneralSettings.LineageMode)
                        {
                            case GeneralSettings.LINEAGE_MODE.LINEAGE_NUMERAL:
                                lineageAppendText = " 15";
                                break;
                            case GeneralSettings.LINEAGE_MODE.LINEAGE_WORDS:
                                lineageAppendText = " the Fifteenth";
                                break;
                            case GeneralSettings.LINEAGE_MODE.LINEAGE_ROMAN:
                                lineageAppendText = " XV";
                                break;
                        }
                        break;
                    
                    default:
                        lineageAppendText = $" {value}";
                        break;
                }
            }

            Clipboard.SetText($"{selected}{lineageAppendText}");
        }
        
        // no confirm dialog
        public void ClearWaitingList()
        {
            //delete all elements and update
            _listWaiting.Clear();
            _twitchChatBot.LogLine($"Cleared all elements in ListWaiting.", ChatBot.LOG_LEVEL.LOG_INFO);
            DoAllUpdates();
        }
        public void ClearActiveList()
        {
            //delete all elements and update
            _listActive.Clear();
            _twitchChatBot.LogLine($"Cleared all elements in ListActive.", ChatBot.LOG_LEVEL.LOG_INFO);
            DoAllUpdates();
        }
        public void ClearDeadList()
        {
            //delete all elements and update
            _listDead.Clear();
            _twitchChatBot.LogLine($"Cleared all elements in ListDead.", ChatBot.LOG_LEVEL.LOG_INFO);
            DoAllUpdates();
        }
        public void ClearLineage()
        {
            //delete all elements and update
            _dictLineage.Clear();
            _twitchChatBot.LogLine($"Cleared all elements in Lineage.", ChatBot.LOG_LEVEL.LOG_INFO);
            DoAllUpdates();
        }

        // confirm dialog, then delete
        public void AskAndClearWaitingList()
        {
            if(MessageBox.Show("Are you sure?", "Confirm Delete", MessageBoxButtons.OKCancel) == DialogResult.OK)
            {
                //delete all elements and update
                _listWaiting.Clear();
                _twitchChatBot.LogLine($"Cleared all elements in ListWaiting.", ChatBot.LOG_LEVEL.LOG_INFO);
                DoAllUpdates();       
            }
        }
        public void AskAndClearActiveList()
        {
            if(MessageBox.Show("Are you sure?", "Confirm Delete", MessageBoxButtons.OKCancel) == DialogResult.OK)
            {
                //delete all elements and update
                _listActive.Clear();
                _twitchChatBot.LogLine($"Cleared all elements in ListActive.", ChatBot.LOG_LEVEL.LOG_INFO);
                DoAllUpdates();           
            }
        }
        public void AskAndClearDeadList()
        {
            if(MessageBox.Show("Are you sure?", "Confirm Delete", MessageBoxButtons.OKCancel) == DialogResult.OK)
            {
                //delete all elements and update
                _listDead.Clear();
                _twitchChatBot.LogLine($"Cleared all elements in ListDead.", ChatBot.LOG_LEVEL.LOG_INFO);
                DoAllUpdates();
            }
        }
        public void AskAndClearLineage()
        {
            if(MessageBox.Show("Are you sure?", "Confirm Delete", MessageBoxButtons.OKCancel) == DialogResult.OK)
            {
                //delete all elements and update
                _dictLineage.Clear();
                _twitchChatBot.LogLine($"Cleared all elements in Lineage.", ChatBot.LOG_LEVEL.LOG_INFO);
                DoAllUpdates();                        
            }
        }
        
        #endregion

        #region Event Handlers

        //main buttons
        private void button_SelectRandom_Click(object sender, EventArgs e)
        {
            TrySelectRandomUser();
        }
        
        private void button_ClearWaiting_Click(object sender, EventArgs e)
        {
            //pop up a confirmation dialog and then clear (todo hotkey can ask for confirmation or not?)
            if (GeneralSettings.DoAskConfirmClearButtons)
                AskAndClearWaitingList();
            else
                ClearWaitingList();
        }
        private void button_ClearActive_Click(object sender, EventArgs e)
        {
            if (GeneralSettings.DoAskConfirmClearButtons)
                AskAndClearActiveList();
            else
                ClearActiveList();
        }
        private void button_ClearDead_Click(object sender, EventArgs e)
        {
            if (GeneralSettings.DoAskConfirmClearButtons)
                AskAndClearDeadList();
            else
                ClearDeadList();
        }
        private void button_ClearLineage_Click(object sender, EventArgs e)
        {
            if (GeneralSettings.DoAskConfirmClearButtons)
                AskAndClearLineage();
            else
                ClearLineage();
        }
        
        private void button_ClearAll_Click(object sender, EventArgs e)
        {
            //ALWAYS prompt for this one.
            if(MessageBox.Show("Are you REALLY sure?\n" +
                               "This will delete ALL currently loaded data!\n", 
                "Confirm Delete", MessageBoxButtons.OKCancel) == DialogResult.OK)
            {
                //i don't fucking trust my users LMAO
                WriteAllDataToFiles("MostRecent-ClearAll-Data.Backup"); //sorry buster i'm not allowing any accidents here
                
                //delete everything and update
                _listWaiting.Clear();
                _listActive.Clear();
                _listDead.Clear();
                _dictLineage.Clear();
                
                _twitchChatBot.LogLine($"Cleared all data... a backup was made, just in case.", ChatBot.LOG_LEVEL.LOG_INFO);
                DoAllUpdates();                        
            }
        }
        
        private void button_ShuffleDeadIntoWaiting_Click(object sender, EventArgs e)
        {
            //predicated on the fact that no duplicates should exist in any of the three lists, we can safely just move every element without worrying about it generating errors
            _listWaiting.AddRange(_listDead.ToArray());
            _listDead.Clear();
            
            _twitchChatBot.LogLine("Shuffled contents of ListDead into ListWaiting.", ChatBot.LOG_LEVEL.LOG_INFO);
            DoAllUpdates();
        }
        private void button_ShuffleBothIntoWaiting_Click(object sender, EventArgs e)
        {
            _listWaiting.AddRange(_listDead.ToArray());
            _listDead.Clear();
            
            _listWaiting.AddRange(_listActive.ToArray());
            _listActive.Clear();
            
            _twitchChatBot.LogLine("Shuffled contents of both ListDead and ListActive into ListWaiting.", ChatBot.LOG_LEVEL.LOG_INFO);
            DoAllUpdates();
        }
        
        #region ListBox Elements

        private bool AssertListWaitingIndex(int index)
        {
            // ensure that index is a real item in the list.
            if (index >= 0 && index < _listWaiting.Count)
            {
                // conditions are safe. return true so you can do your code.
                return true;
            }
            else
            {
                // not safe! disable the buttons and return false.
                //_twitchChatBot.LogLine("ListWaiting index out of bounds. Did not complete action.", ChatBot.LOG_LEVEL.LOG_WARNING);
                // logging was too noisy LOL
                
                button_ListWaiting_Remove.Enabled = false;
                button_ListWaiting_MoveToActive.Enabled = false;
                button_ListWaiting_MoveToDead.Enabled = false;
                return false;
            }
        }
        private bool AssertListActiveIndex(int index)
        {
            // ensure that index is a real item in the list.
            if (index >= 0 && index < _listActive.Count)
            {
                // conditions are safe. return true so you can do your code.
                return true;
            }
            else
            {
                // not safe! disable the buttons and return false.
                //_twitchChatBot.LogLine("ListActive index out of bounds. Did not complete action.", ChatBot.LOG_LEVEL.LOG_WARNING);
                
                button_ListActive_Remove.Enabled = false;
                button_ListActive_MoveToWaiting.Enabled = false;
                button_ListActive_MoveToDead.Enabled = false;
                return false;
            }
        }
        private bool AssertListDeadIndex(int index)
        {
            // ensure that index is a real item in the list.
            if (index >= 0 && index < _listDead.Count)
            {
                // conditions are safe. return true so you can do your code.
                return true;
            }
            else
            {
                // not safe! disable the buttons and return false.
                //_twitchChatBot.LogLine("ListDead index out of bounds. Did not complete action.", ChatBot.LOG_LEVEL.LOG_WARNING);
                
                button_ListDead_Remove.Enabled = false;
                button_ListDead_MoveToActive.Enabled = false;
                button_ListDead_MoveToWaiting.Enabled = false;
                return false;
            }
        }
        
        // ListWaiting
        
        private void listBox_ListWaiting_SelectedIndexChanged(object sender, EventArgs e)
        {
            //store index in a variable to prevent a race condition when comparing against it multiple times
            int index = listBox_ListWaiting.SelectedIndex;
            
            // check if index in within array size
            // if so, activate the mutable buttons
            if (AssertListWaitingIndex(index))
            {
                button_ListWaiting_Remove.Enabled = true;
                button_ListWaiting_MoveToActive.Enabled = true;
                button_ListWaiting_MoveToDead.Enabled = true;
            }
        }
        
        private void button_ListWaiting_Add_Click(object sender, EventArgs e)
        {
            //pop up a new input dialog
            AddToListDialog dialog = new AddToListDialog();
            string input = dialog.Show();
            
            //if not empty, try to add to list
            if (!String.IsNullOrWhiteSpace(input))
            {
                //try add to list
                TryAddNameToList(_listWaiting, input);
            }
            else
            {
                //log that input was invalid
                _twitchChatBot.LogLine("User input field was empty or invalid. No action taken.", ChatBot.LOG_LEVEL.LOG_WARNING);
            }
            
            // refresh list contents
            DoAllUpdates();
        }

        private void button_ListWaiting_Remove_Click(object sender, EventArgs e)
        {
            int index = listBox_ListWaiting.SelectedIndex;
            
            // assert & only then do code
            if (AssertListWaitingIndex(index))
            {
                string s = _listWaiting.ElementAt(index);
                
                // remove item
                _listWaiting.Remove(s);
                // disable buttons
                button_ListWaiting_Remove.Enabled = false;
                button_ListWaiting_MoveToActive.Enabled = false;
                button_ListWaiting_MoveToDead.Enabled = false;
                
                _twitchChatBot.LogLine($"Element <{s}> removed from ListWaiting.", ChatBot.LOG_LEVEL.LOG_INFO);
                
                // refresh list contents
                DoAllUpdates();
            }
        }

        private void button_ListWaiting_MoveToActive_Click(object sender, EventArgs e)
        {
            int index = listBox_ListWaiting.SelectedIndex;
            
            // assert & only then do code
            if (AssertListWaitingIndex(index))
            {
                //another store to prevent a race condition
                string s = _listWaiting.ElementAt(index);
                
                // add item to active list 
                _listActive.Add(s);
                // remove item from waiting
                _listWaiting.Remove(s);
                
                //update lineage
                if (_dictLineage.ContainsKey(s))
                {
                    _dictLineage.TryGetValue(s, out int val);
                    _dictLineage[s] = ++val;
                }
                else
                {
                    _dictLineage.Add(s, 1);
                }
                
                PutSelectedToClipboard(s);
                _twitchChatBot.Chat(_twitchChatBot.TryReplaceFormatStrings(ConfigCommandBehavior.ResponseCmdUserDrawn, s));
                
                //disable buttons
                button_ListWaiting_Remove.Enabled = false;
                button_ListWaiting_MoveToActive.Enabled = false;
                button_ListWaiting_MoveToDead.Enabled = false;
                
                _twitchChatBot.LogLine($"Element <{s}> moved from ListWaiting to ListActive.", ChatBot.LOG_LEVEL.LOG_INFO);
                
                // refresh list contents
                DoAllUpdates();
            }
        }
        
        private void button_ListWaiting_MoveToDead_Click(object sender, EventArgs e)
        {
            int index = listBox_ListWaiting.SelectedIndex;
            
            // assert & only then do code
            if (AssertListWaitingIndex(index))
            {
                string s = _listWaiting.ElementAt(index);
                
                // add item to dead list 
                _listDead.Add(s);
                // remove item from waiting
                _listWaiting.Remove(s);
                
                // disable buttons
                button_ListWaiting_Remove.Enabled = false;
                button_ListWaiting_MoveToActive.Enabled = false;
                button_ListWaiting_MoveToDead.Enabled = false;
                
                _twitchChatBot.LogLine($"Element <{s}> moved from ListWaiting to ListDead.", ChatBot.LOG_LEVEL.LOG_INFO);
                
                // refresh list contents
                DoAllUpdates();
            }
        }

        // ListActive
        
        private void listBox_ListActive_SelectedIndexChanged(object sender, EventArgs e)
        {
            //store index in a variable to prevent a race condition when comparing against it multiple times
            int index = listBox_ListActive.SelectedIndex;
            
            // check if index in within array size
            // if so, activate the mutable buttons
            if (AssertListActiveIndex(index))
            {
                button_ListActive_Remove.Enabled = true;
                button_ListActive_MoveToWaiting.Enabled = true;
                button_ListActive_MoveToDead.Enabled = true;
            }
        }
        
        private void button_ListActive_MoveToWaiting_Click(object sender, EventArgs e)
        {
            int index = listBox_ListActive.SelectedIndex;
            
            // assert & only then do code
            if (AssertListActiveIndex(index))
            {
                string s = _listActive.ElementAt(index);
                
                // add item to dead list 
                _listWaiting.Add(s);
                // remove item from waiting
                _listActive.Remove(s);
                
                // disable buttons
                button_ListActive_Remove.Enabled = false;
                button_ListActive_MoveToWaiting.Enabled = false;
                button_ListActive_MoveToDead.Enabled = false;
                
                _twitchChatBot.LogLine($"Element <{s}> moved from ListActive to ListWaiting.", ChatBot.LOG_LEVEL.LOG_INFO);
                
                // refresh list contents
                DoAllUpdates();
            }
        }

        private void button_ListActive_Add_Click(object sender, EventArgs e)
        {
            //pop up a new input dialog
            AddToListDialog dialog = new AddToListDialog();
            string input = dialog.Show();
            
            //if not empty, try to add to list
            if (!String.IsNullOrWhiteSpace(input))
            {
                //try add to list
                TryAddNameToList(_listActive, input);
            }
            else
            {
                //log that input was invalid
                _twitchChatBot.LogLine("User input field was empty or invalid. No action taken.", ChatBot.LOG_LEVEL.LOG_WARNING);
            }
            
            // refresh list contents
            DoAllUpdates();
        }

        private void button_ListActive_Remove_Click(object sender, EventArgs e)
        {
            int index = listBox_ListActive.SelectedIndex;
            
            // assert & only then do code
            if (AssertListActiveIndex(index))
            {
                string s = _listActive.ElementAt(index);
                
                // remove item
                _listActive.Remove(s);
                // disable buttons
                button_ListActive_Remove.Enabled = false;
                button_ListActive_MoveToWaiting.Enabled = false;
                button_ListActive_MoveToDead.Enabled = false;
                
                _twitchChatBot.LogLine($"Element <{s}> removed from ListActive.", ChatBot.LOG_LEVEL.LOG_INFO);
                
                // refresh list contents
                DoAllUpdates();
            }
        }

        private void button_ListActive_MoveToDead_Click(object sender, EventArgs e)
        {
            int index = listBox_ListActive.SelectedIndex;
            
            // assert & only then do code
            if (AssertListActiveIndex(index))
            {
                string s = _listActive.ElementAt(index);
                
                // add item to dead list 
                _listDead.Add(s);
                // remove item from waiting
                _listActive.Remove(s);
                
                // disable buttons
                button_ListActive_Remove.Enabled = false;
                button_ListActive_MoveToWaiting.Enabled = false;
                button_ListActive_MoveToDead.Enabled = false;
                
                _twitchChatBot.LogLine($"Element <{s}> moved from ListActive to ListDead.", ChatBot.LOG_LEVEL.LOG_INFO);
                
                // refresh list contents
                DoAllUpdates();
            }
        }
        
        // ListDead
        
        private void listBox_ListDead_SelectedIndexChanged(object sender, EventArgs e)
        {
            //store index in a variable to prevent a race condition when comparing against it multiple times
            int index = listBox_ListDead.SelectedIndex;
            
            // check if index in within array size
            // if so, activate the mutable buttons
            if (AssertListDeadIndex(index))
            {
                button_ListDead_Remove.Enabled = true;
                button_ListDead_MoveToActive.Enabled = true;
                button_ListDead_MoveToWaiting.Enabled = true;
            }
        }
        
        private void button_ListDead_MoveToWaiting_Click(object sender, EventArgs e)
        {
            int index = listBox_ListDead.SelectedIndex;
            
            // assert & only then do code
            if (AssertListDeadIndex(index))
            {
                string s = _listDead.ElementAt(index);
                
                // add item to dead list 
                _listWaiting.Add(s);
                // remove item from waiting
                _listDead.Remove(s);
                
                // disable buttons
                button_ListDead_Remove.Enabled = false;
                button_ListDead_MoveToWaiting.Enabled = false;
                button_ListDead_MoveToActive.Enabled = false;
                
                _twitchChatBot.LogLine($"Element <{s}> moved from ListDead to ListWaiting.", ChatBot.LOG_LEVEL.LOG_INFO);
                
                // refresh list contents
                DoAllUpdates();
            }
        }

        private void button_ListDead_MoveToActive_Click(object sender, EventArgs e)
        {
            int index = listBox_ListDead.SelectedIndex;
            
            // assert & only then do code
            if (AssertListDeadIndex(index))
            {
                //another store to prevent a race condition
                string s = _listDead.ElementAt(index);
                
                // add item to active list 
                _listActive.Add(s);
                // remove item from waiting
                _listDead.Remove(s);
                
                //disable buttons
                button_ListDead_Remove.Enabled = false;
                button_ListDead_MoveToActive.Enabled = false;
                button_ListDead_MoveToWaiting.Enabled = false;
                
                _twitchChatBot.LogLine($"Element <{s}> moved from ListDead to ListActive.", ChatBot.LOG_LEVEL.LOG_INFO);
                
                // refresh list contents
                DoAllUpdates();
            }
        }

        private void button_ListDead_Add_Click(object sender, EventArgs e)
        {
            //pop up a new input dialog
            AddToListDialog dialog = new AddToListDialog();
            string input = dialog.Show();
            
            //if not empty, try to add to list
            if (!String.IsNullOrWhiteSpace(input))
            {
                //try add to list
                TryAddNameToList(_listDead, input);
            }
            else
            {
                //log that input was invalid
                _twitchChatBot.LogLine("User input field was empty or invalid. No action taken.", ChatBot.LOG_LEVEL.LOG_WARNING);
            }
            
            // refresh list contents
            DoAllUpdates();
        }

        private void button_ListDead_Remove_Click(object sender, EventArgs e)
        {
            int index = listBox_ListDead.SelectedIndex;
            
            // assert & only then do code
            if (AssertListDeadIndex(index))
            {
                string s = _listDead.ElementAt(index);
                
                // remove item
                _listDead.Remove(s);
                // disable buttons
                button_ListDead_Remove.Enabled = false;
                button_ListDead_MoveToActive.Enabled = false;
                button_ListDead_MoveToWaiting.Enabled = false;
                
                _twitchChatBot.LogLine($"Element <{s}> removed from ListDead.", ChatBot.LOG_LEVEL.LOG_INFO);
                
                // refresh list contents
                DoAllUpdates();
            }
        }

        // Lineage
        
        private bool AssertLineageIndex(int index)
        {
            // ensure that index is a real item in the list.
            if (index >= 0 && index < _dictLineage.Count)
            {
                // conditions are safe. return true so you can do your code.
                return true;
            }
            else
            {
                // not safe! disable the buttons and return false.
                //_twitchChatBot.LogLine("ListDead index out of bounds. Did not complete action.", ChatBot.LOG_LEVEL.LOG_WARNING);
                
                button_LineageRemove.Enabled = false;
                button_LineageIncrement.Enabled = false;
                button_LineageDecrement.Enabled = false;
                return false;
            }
        }
        
        private void listBox_CurrentLineage_SelectedIndexChanged(object sender, EventArgs e)
        {
            //store index in a variable to prevent a race condition when comparing against it multiple times
            int index = listBox_CurrentLineage.SelectedIndex;
            
            // check if index in within array size
            // if so, activate the mutable buttons
            if (AssertLineageIndex(index))
            {
                button_LineageRemove.Enabled = true;
                button_LineageIncrement.Enabled = true;
                button_LineageDecrement.Enabled = true;
            }
        }
        
        private void button_LineageAdd_Click(object sender, EventArgs e)
        {
            //pop up a new input dialog
            AddToListDialog dialog = new AddToListDialog();
            string input = dialog.Show();
            
            //if not empty, try to add to list
            if (!String.IsNullOrWhiteSpace(input))
            {
                //update lineage
                if (_dictLineage.ContainsKey(input))
                {
                    _dictLineage.TryGetValue(input, out int val);
                    _dictLineage[input] = ++val;
                    _twitchChatBot.LogLine($"Element <{input}> already exists in Lineage, incrementing its value.", ChatBot.LOG_LEVEL.LOG_WARNING);
                }
                else
                {
                    _dictLineage.Add(input, 1);
                    _twitchChatBot.LogLine($"Element <{input}> was added to Lineage with a generation of 1.", ChatBot.LOG_LEVEL.LOG_INFO);
                }
            }
            else
            {
                //log that input was invalid
                _twitchChatBot.LogLine("User input field was empty or invalid. No action taken.", ChatBot.LOG_LEVEL.LOG_WARNING);
            }
            
            // refresh list contents
            DoAllUpdates();
        }
        
        private void button_LineageRemove_Click(object sender, EventArgs e)
        {
            int index = listBox_CurrentLineage.SelectedIndex;
            
            // assert & only then do code
            if (AssertLineageIndex(index))
            {
                string s = _dictLineage.Keys.ElementAt(index);
                
                // remove item
                _dictLineage.Remove(s);
                
                // disable buttons
                button_ListDead_Remove.Enabled = false;
                button_ListDead_MoveToActive.Enabled = false;
                button_ListDead_MoveToWaiting.Enabled = false;
                
                _twitchChatBot.LogLine($"Element <{s}> removed from Lineage.", ChatBot.LOG_LEVEL.LOG_INFO);
                
                // refresh list contents
                DoAllUpdates();
            }
        }

        private void button_LineageIncrement_Click(object sender, EventArgs e)
        {
            int index = listBox_CurrentLineage.SelectedIndex;
            
            // assert & only then do code
            if (AssertLineageIndex(index))
            {
                string s = _dictLineage.Keys.ElementAt(index);
                
                // increase the value
                _dictLineage.TryGetValue(s, out int val);
                _dictLineage[s] = ++val;
                
                // disable buttons
                button_LineageRemove.Enabled = false;
                button_LineageIncrement.Enabled = false;
                button_LineageDecrement.Enabled = false;
                
                _twitchChatBot.LogLine($"Element <{s}> in Lineage was incremented.", ChatBot.LOG_LEVEL.LOG_INFO);
                
                // refresh list contents
                DoAllUpdates();
            }
        }
        
        private void button_LineageDecrement_Click(object sender, EventArgs e)
        {
            int index = listBox_CurrentLineage.SelectedIndex;
            
            // assert & only then do code
            if (AssertLineageIndex(index))
            {
                string s = _dictLineage.Keys.ElementAt(index);
                
                // decrease the value to a minimum of 1
                _dictLineage.TryGetValue(s, out int val);
                _dictLineage[s] = (--val < 1) ? 1 : val;
                
                // disable buttons
                button_LineageRemove.Enabled = false;
                button_LineageIncrement.Enabled = false;
                button_LineageDecrement.Enabled = false;
                
                _twitchChatBot.LogLine($"Element <{s}> in Lineage was decremented.", ChatBot.LOG_LEVEL.LOG_INFO);
                
                // refresh list contents
                DoAllUpdates();
            }
        }
        
        #endregion

        // the application is closing: update variables to tell any external threads to stop
        private void FormMain_FormClosing(object sender, FormClosingEventArgs e)
        {
            // save data
            WriteAllConfigToFiles();
            WriteAllDataToFiles();
            
            _isApplicationClosing = true;
            UnregisterAllHotkeys();
            
            updateAndRefreshComponentsThread.Abort();
            chatReminderThread.Abort();
        }
        
        // pop a file dialog and store the dataset to it
        private void button_SaveData_Click(object sender, EventArgs e)
        {
            using (SaveFileDialog saveFileDialog = new SaveFileDialog() {InitialDirectory = AppContext.BaseDirectory})
                if (saveFileDialog.ShowDialog() == DialogResult.OK)
                    WriteAllDataToFiles(saveFileDialog.FileName); //so clean lmao i love it
        }
        
        // pop a file dialog and try to load it as the current dataset (but save the current one first Just In Case)
        private void button_LoadData_Click(object sender, EventArgs e)
        {
            WriteAllDataToFiles();
            using (OpenFileDialog openFileDialog = new OpenFileDialog() {InitialDirectory = AppContext.BaseDirectory})
                if (openFileDialog.ShowDialog() == DialogResult.OK)
                    TryParseDataSet(openFileDialog.FileName);
            DoAllUpdates();
        }

        // Debug Menu 'do verbose logging' checkbox updated, begin showing/hiding verbose logging
        private void checkBox_doVerboseLogging_CheckedChanged(object sender, EventArgs e)
        {
            GeneralSettings.DoVerboseLog = checkBox_doVerboseLogging.Checked; //reference this instead of its own variable
            WriteAllConfigToFiles();
        }
        
        private void checkBox_ConnectOnStartup_CheckedChanged(object sender, EventArgs e)
        {
            GeneralSettings.DoConnectOnStartup = checkBox_ConnectOnStartup.Checked;
            WriteAllConfigToFiles();
        }
        
        // set the new auto-refresh interval
        private void numericUpDown_AutoRefreshSeconds_ValueChanged(object sender, EventArgs e)
        {
            GeneralSettings.AutoRefreshSeconds = Convert.ToInt32(numericUpDown_AutoRefreshSeconds.Value);
            WriteAllConfigToFiles();
        }

        // reconnect button on the Debug page clicked. manually disconnect from IRC, wait, then reconnect.
        private void button_ForceReconnect_Click(object sender, EventArgs e)
        {
            _twitchChatBot.Chat(ConfigCommandBehavior.ResponseCmdChatReconnect);
            
            _twitchChatBot.Disconnect();

            string holdoverText = richTextBox_ConsoleDebugLog.Text;
            _twitchChatBot = new ChatBot(this);
            _twitchChatBot.LogOutput = holdoverText;
            
            _twitchChatBot.LogLine("Force reconnect triggered. Chat log cleared, automatically re-connecting...", ChatBot.LOG_LEVEL.LOG_INFO);
            _twitchChatBot.Connect(_twitchBotCredentials[0],
                _twitchBotCredentials[1], _twitchBotCredentials[2]);
        }

        // 'configure command aliases'. show the custom dialog, then get its settings if OK, and save them to the config.
        private void button_ConfigCommandAliases_Click(object sender, EventArgs e)
        {
            ConfigCommandAliasDialog configCommandAliasDialog = new ConfigCommandAliasDialog();
            ConfigCommandAliasResult result = configCommandAliasDialog.Show(ConfigCommandAlias); //get updated settings (if any)
            ConfigCommandAlias = result; //store new settings into memory
            WriteAllConfigToFiles(); //save new settings to files
            //todo refresh, potentially reconnect
        }
        
        private void button_ConfigCommandBehavior_Click(object sender, EventArgs e)
        {
            ConfigCommandBehaviorDialog configCommandBehaviorDialog = new ConfigCommandBehaviorDialog();
            ConfigCommandBehaviorResult result = configCommandBehaviorDialog.Show(ConfigCommandBehavior); //get updated settings if any
            ConfigCommandBehavior = result; //store new settings into memory
            WriteAllConfigToFiles(); //save settings
            //todo refresh
        }
        
        private void button_ConfigHotkeys_Click(object sender, EventArgs e)
        {
            ConfigHotkeyDialog configHotkeyDialog = new ConfigHotkeyDialog();
            ConfigHotkeyResult result = configHotkeyDialog.Show(ConfigHotkey);
            ConfigHotkey = result;
            WriteAllConfigToFiles();
            RegisterAllHotkeys();
        }
        
        private void button_ConfigCredentials_Click(object sender, EventArgs e)
        {
            ConfigTwitchCredentialsDialog configTwitchCredentialsDialog = new ConfigTwitchCredentialsDialog();
            _twitchBotCredentials = configTwitchCredentialsDialog.Show(_twitchBotCredentials); //show dialog and save the result
            
            if (configTwitchCredentialsDialog.DialogResult == DialogResult.OK)
            {
                File.WriteAllLines("_secret.safe", _twitchBotCredentials); //write creds to file (only doing it here, not on the auto-cycle)
                
                string holdoverText = richTextBox_ConsoleDebugLog.Text;
                _twitchChatBot.Disconnect();
                _twitchChatBot.LogOutput = holdoverText;
                
                _twitchChatBot = new ChatBot(this);
                _twitchChatBot.LogLine("Credentials reconfigured. Chat log cleared, automatically re-connecting...", ChatBot.LOG_LEVEL.LOG_INFO);
                _twitchChatBot.Connect(_twitchBotCredentials[0],
                    _twitchBotCredentials[1], _twitchBotCredentials[2]);
            }
            
        }
        
        private void button_TwitchApiDialog_Click(object sender, EventArgs e)
        {
            TwitchApiDialog twitchApiDialog = new TwitchApiDialog();
            twitchApiDialog.Show(_twitchBotCredentials[0], HttpClient);
        }
        
        private void button_ForceUpdate_Click(object sender, EventArgs e)
        {
            DoAllUpdates();
        }
        
        private void button_SaveDebugLog_Click(object sender, EventArgs e)
        {
            using (SaveFileDialog saveFileDialog = new SaveFileDialog() {InitialDirectory = AppContext.BaseDirectory})
                if (saveFileDialog.ShowDialog() == DialogResult.OK)
                    File.WriteAllText(saveFileDialog.FileName, richTextBox_ConsoleDebugLog.Text);
        }
        
        private void button_ManualChat_Click(object sender, EventArgs e)
        {
            //get the text in the textbox, then purge it
            string textToSend = textBox_ManualChat.Text.Trim();
            textBox_ManualChat.Text = "";
            
            //disable the button
            button_ManualChat.Enabled = false;

            //send the text to the chat if it's safe
            if (!String.IsNullOrWhiteSpace(textToSend))
            {
                _twitchChatBot.Chat(textToSend);
                _twitchChatBot.LogLine($">> <{_twitchBotCredentials[2]}>: {textToSend}", ChatBot.LOG_LEVEL.LOG_CHAT);
            }
                
        }

        private void textBox_ManualChat_TextChanged(object sender, EventArgs e)
        {
            //if text is not null, enable the send button
            button_ManualChat.Enabled = !String.IsNullOrEmpty(textBox_ManualChat.Text);
        }

        private void textBox_ManualChat_KeyDown(object sender, KeyEventArgs e)
        {
            //if the enter key is pressed, do the button's thing
            if (e.KeyCode == Keys.Enter)
            {
                e.Handled = true;
                e.SuppressKeyPress = true;
            
                //get the text in the textbox, then purge it
                string textToSend = textBox_ManualChat.Text.Trim();
                textBox_ManualChat.Text = "";
            
                //disable the button
                button_ManualChat.Enabled = false;

                //send the text to the chat if it's safe
                if (!String.IsNullOrWhiteSpace(textToSend))
                {
                    _twitchChatBot.Chat(textToSend);
                    _twitchChatBot.LogLine($">> <{_twitchBotCredentials[2]}>: {textToSend}", ChatBot.LOG_LEVEL.LOG_CHAT);
                }
            }
        }
        
        private void button_ConfigListLogic_Click(object sender, EventArgs e)
        {
            ConfigListBehaviorDialog dialog = new ConfigListBehaviorDialog();
            GeneralSettings = dialog.Show(GeneralSettings); //pass in current settings, get back updated settings
        }

        #endregion

        #region ChatBot Getters

        public string FormatStringDemo(string username)
        {
            return $"Hello, {username}!";
        }

        public string FormatStringGetLineage(string username)
        {
            _dictLineage.TryGetValue(username, out int value);
            return value.ToString();
        }
        
        public string FormatStringFullStatus(string username)
        {
            //get the full status and pass it back to the user.

            int userState = 0; //0 = not in list. 1 = in waiting. 2 = in active. 4 = in dead. any other = weird shit happened
            if (_listWaiting.Contains(username)) userState += 1;
            if (_listActive.Contains(username)) userState += 2;
            if (_listDead.Contains(username)) userState += 4;

            string response = "";
            
            switch (userState)
            {
                case 0: // not in any list
                    _dictLineage.TryGetValue(username, out int value); // check if they have lineage data
                    
                    if(value != 0) //if so...
                        response = $"{username}, you are not in any list. Your current lineage is {value}.";
                    else
                        response = $"{username}, you are not in any list."; //don't mention if not
                    break;
                    
                case 1: // in waiting list
                    _dictLineage.TryGetValue(username, out value);
                    string format = $"There are {_listWaiting.Count - 1} others waiting with you.";
                    if (_listWaiting.Count <= 2)
                        format = _listWaiting.Count == 2 ? "There is one other waiting with you." : "You are the only one waiting.";
                    
                    if(value != 0) 
                        response = $"{username}, you are waiting to be drawn. {format} Your current lineage is {value}.";
                    else
                        response = $"{username}, you are waiting to be drawn. {format}"; 
                    break;
                    
                case 2: // in active list
                    _dictLineage.TryGetValue(username, out value);
                    
                    if(value != 0)
                        response = $"{username}, you are active in-game. Your current lineage is {value}.";
                    else
                        response = $"{username}, you are active in-game."; 
                    break;
                                        
                case 4: // in dead list
                    _dictLineage.TryGetValue(username, out value);
                    
                    if(value != 0)
                        response = $"{username}, you have fallen and are waiting to be returned to the waitlist. Your current lineage is {value}.";
                    else
                        response = $"{username}, you have fallen and are waiting to be returned to the waitlist."; 
                    break;
                
                default: //something weird happened!
                    response = $"Uh oh! {username}, something weird has happened to your state in the program. " +
                               $"You seem to exist in multiple places at once! Please alert the streamer so they can correct this.";
                    break;
            }
            
            return response;
        }

        public string FormatStringQuickStatus(string username)
        {
            //quick status. for after attempting to add.

            int userState = 0; //0 = not in list. 1 = in waiting. 2 = in active. 4 = in dead. any other = weird shit happened
            if (_listWaiting.Contains(username)) userState += 1;
            if (_listActive.Contains(username)) userState += 2;
            if (_listDead.Contains(username)) userState += 4;

            string response = "";
            
            switch (userState)
            {
                case 0: // not in any list
                    response = $"You are not in any list."; 
                    break;
                    
                case 1: // in waiting list
                    response = $"You are in the waitlist."; 
                    break;
                    
                case 2: // in active list
                    response = $"You are already active."; 
                    break;
                                        
                case 4: // in dead list
                    response = $"You must wait to be reset."; 
                    break;
                
                default: //something weird happened!
                    response = $"An error occurred.";
                    break;
            }

            return response;
        }

        #endregion


        
    }
}
