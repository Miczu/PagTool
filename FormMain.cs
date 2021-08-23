﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Threading;
using System.Windows.Forms;
using Newtonsoft.Json;

// considering renaming to PogTool LUL
namespace PagTool
{
    public partial class FormMain : Form
    {
        #region Field Variables

        // TODO: field variables
        private ChatBot _twitchChatBot;

        //config file data variables
        string[] _twitchBotCredentials;

        // dialog results: store all the information for each configurable aspect to the program
        public ConfigCommandAliasResult ConfigCommandAlias; //command aliases
        public ConfigCommandBehaviorResult ConfigCommandBehavior; //chat responses and switches to define behaviors
        public ConfigHotkeyResult ConfigHotkey; //hotkey information
        //todo make a Result for each config dialog and use them to save/load config files

        //three lists.
        List<string> _listWaiting = new List<string>();
        List<string> _listActive = new List<string>();
        List<string> _listDead = new List<string>();

        //used to let threads know if the application is terminating
        private bool _isApplicationClosing = false;

        #endregion
        
        public FormMain()
        {
            // quickly instantiate this
            _twitchChatBot = new ChatBot(this);

            // Load the form's components, then launch async tasks
            InitializeComponent();

            // TODO: load configs, initialize variables, etc...
            //load twitch credentials and create 
            _twitchBotCredentials = CheckFileAndLoadTwitchCredentials("_secret.safe");

            //TODO load config.ini data
            //if these files don't exist, create a new default config Result for each respectively and then store it. otherwise, parse the file
            TryParseConfigCommandAlias();
            TryParseConfigCommandBehavior();
            TryParseConfigHotkey();
            //etc etc

            //first, update all elements manually
            DoAllUpdates();
            
            //register global hotkeys
            //RegisterAllHotkeys();

            // then, start thread to auto-refresh contents of components every 5 seconds
            Thread updateAndRefreshComponentsThread = new Thread(new ThreadStart(UpdateThreadTimer));
            updateAndRefreshComponentsThread.Start();

            // connect twitch bot to IRC chat
            _twitchChatBot.Connect(_twitchBotCredentials[0],
                _twitchBotCredentials[1]); //todo again this needs to be much more secure but this will do for now
        }

        #region Hotkey Management
        
        //variables to store hotkey hook IDs, const here for static context (IDs don't need to change ever, just be re-registered)
        public const int HKIDSelectRandomUser = 1; 

        //import hotkey register functions
        [DllImport("user32.dll")]
        public static extern bool RegisterHotKey(IntPtr hWnd, int id, int fsModifiers, int key);
        [DllImport("user32.dll")]
        public static extern bool UnregisterHotKey(IntPtr hWnd, int id);

        public void RegisterAllHotkeys()
        {
            //register all keys
            RegisterHotKey(this.Handle, HKIDSelectRandomUser, ConfigHotkey.HKModSelectRandomUser, ConfigHotkey.HKKeySelectRandomUser);
            
        }

        public void UnregisterAllHotkeys()
        {
            //unregister all hotkeys
            UnregisterHotKey(this.Handle, HKIDSelectRandomUser);
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

            base.WndProc(ref m);
        }

        #endregion

        #region Component Update Thread

        void UpdateThreadTimer()
        {
            while (!_isApplicationClosing)
            {
                Thread.Sleep(1000 * 5); // every five seconds
                DoAllUpdates();
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
            if (File.Exists(filepath)) //TODO also check the format and make sure all args exist for this file
                return File.ReadAllLines(filepath);
            else
            {
                // TODO: create this file and write default arguments to it
                File.WriteAllText(filepath, "Store your twitch credentials in this file.");
                return new[] {"DoesNotExist", "DoesNotExist"};
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

        // save all Config to files
        public void WriteAllConfigToFiles()
        {
            File.WriteAllText("CommandAlias.config", JsonConvert.SerializeObject(ConfigCommandAlias));
            File.WriteAllText("CommandBehavior.config", JsonConvert.SerializeObject(ConfigCommandBehavior));
            File.WriteAllText("Hotkey.config", JsonConvert.SerializeObject(ConfigHotkey));
            // etc...
        }

        #endregion

        #region Data Structure Interactions

        public void TryAddNameToWaitingList(string name) //add user in chat to waitlist
        {
            //todo this and the other lists for good measure
            //todo blacklist
            if (_listWaiting.Contains(name)) //if name already exists in list
            {
                _twitchChatBot.LogLine($"Name already exists in Waiting List: <{name}>. Skipped.", ChatBot.LOG_LEVEL.LOG_WARNING); //CMD: NameAlreadyExists
            }
            else
            {
                _listWaiting.Add(name); //CMD: NameAdd
                _twitchChatBot.LogLine($"Added to Waiting List: <{name}>.", ChatBot.LOG_LEVEL.LOG_INFO);
            }
        }

        public void TrySelectRandomUser() //get a random user from waitlist (according to SelectRandom behavior options)
        {
            if (_listWaiting.Count > 0) //make sure the list isn't empty
            { //todo behavior & priority switches
                int pos = new Random().Next(_listWaiting.Count - 1);
                string selected = _listWaiting.ElementAt(pos); //get random position in list
                
                //todo all this
                // update lineage of selected
                // copy selected to clipboard + lineage if wanted
                
                // remove selected from waiting
                _listWaiting.RemoveAt(pos);
                // add selected to active
                _listActive.Add(selected);
                
                // log drawn user
                _twitchChatBot.LogLine($"Selected random user from Waiting list: <{selected}>. Added to Active list.", ChatBot.LOG_LEVEL.LOG_INFO);
                
                // send response message to chat
                // CMD: SelectRandom
                // update display lists
                DoAllUpdates();
            }
            else
            { // list is empty
                
                //log that and return
                _twitchChatBot.LogLine($"Waiting list is empty! Cannot select random user.", ChatBot.LOG_LEVEL.LOG_WARNING);
                //CMD: WaitingListEmpty
            }
        }

        #endregion

        #region Event Handlers

        // the application is closing: update variables to tell any external threads to stop
        private void FormMain_FormClosing(object sender, FormClosingEventArgs e)
        {
            _isApplicationClosing = true;
            UnregisterAllHotkeys();
        }

        // Debug Menu 'do verbose logging' checkbox updated, begin showing/hiding verbose logging
        private void checkBox_doVerboseLogging_CheckedChanged(object sender, EventArgs e)
        {
            _twitchChatBot.DoVerboseLogging = checkBox_doVerboseLogging.Checked;
            // TODO save this setting to configs.
        }

        // reconnect button on the Debug page clicked. manually disconnect from IRC, wait, then reconnect.
        private void button_ForceReconnect_Click(object sender, EventArgs e)
        {
            // TODO: use _twitchChatBot.Chat(""); to post a message to chat -- should use the "chat message config" page for specific message
            _twitchChatBot.DisconnectWaitReconnect(_twitchBotCredentials[0], _twitchBotCredentials[1]);
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

        #endregion

        #region ChatBot Getters (Temp?)

        public string FormatStringDemo(string username)
        {
            return $"Hello {username}, this format string works!";
        }

        #endregion

        
    }
}
