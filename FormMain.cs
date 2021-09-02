using System;
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
        public List<string> _listWaiting = new List<string>();
        public List<string> _listActive = new List<string>();
        public List<string> _listDead = new List<string>();

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

        public void TryAddNameToList(List<string> list, string name)
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
                // CMD: NAME ALREADY EXISTS
            }
            else //name doesn't exist in list. go ahead!
            {
                list.Add(name);
                _twitchChatBot.LogLine($"Added to list: <{name}>.", ChatBot.LOG_LEVEL.LOG_INFO);
                //CMD : NAME ADD\
                
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
                _twitchChatBot.LogLine("ListWaiting index out of bounds. Did not complete action.", ChatBot.LOG_LEVEL.LOG_WARNING);
                
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
                _twitchChatBot.LogLine("ListActive index out of bounds. Did not complete action.", ChatBot.LOG_LEVEL.LOG_WARNING);
                
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
                _twitchChatBot.LogLine("ListDead index out of bounds. Did not complete action.", ChatBot.LOG_LEVEL.LOG_WARNING);
                
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

        #endregion

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
        
        private void button_ForceUpdate_Click(object sender, EventArgs e)
        {
            DoAllUpdates();
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
