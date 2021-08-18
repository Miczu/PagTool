using System;
using System.IO;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using TwitchLib.Client;

namespace PagTool
{
    public partial class FormMain : Form
    {
        #region Field Variables

        // TODO: field variables
        ChatBot _twitchChatBot = new ChatBot();
        
        //config file data variables
        string[] _twitchBotCredentials;
        // string[] _configData;

        //used to let threads know if the application is terminating
        private bool _isApplicationClosing = false;
        
        #endregion
        
        public FormMain()
        {
            // TODO: load configs, initialize variables, etc...
            //load twitch credentials
            _twitchBotCredentials = CheckFileAndLoadTwitchCredentials("_secret.safe");
            
            //TODO load config.ini data
            
            
            // Load the form's components, then launch async tasks
            InitializeComponent();
            
            // thread to auto-refresh contents of components
            Thread updateAndRefreshComponentsThread = new Thread(new ThreadStart(UpdateThreadTimer));
            updateAndRefreshComponentsThread.Start();
            
            // connect twitch bot to IRC chat
            _twitchChatBot.Connect(_twitchBotCredentials[0], _twitchBotCredentials[1]); //todo again this needs to be much more secure but this will do for now
        }
        
        #region Component Update Thread

        void UpdateThreadTimer()
        {
            while (!_isApplicationClosing)
            {
                Thread.Sleep(1000 * 5); // every five seconds
                
                //update the text from the log output
                UpdateText(richTextBox_ConsoleDebugLog, _twitchChatBot.LogOutput);
            }
        }
        
        // https://www.codeproject.com/articles/269787/accessing-windows-forms-controls-across-threads
        // please work
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

        #region Utility Functions

        string[] CheckFileAndLoadTwitchCredentials(string filepath)
        {
            if (File.Exists(filepath)) //TODO also check the format and make sure all args exist for this file
                return File.ReadAllLines(filepath);
            else
            {
                // TODO: create this file and write default arguments to it
                File.WriteAllText(filepath, "Store your twitch credentials in this file.");
                return new[] { "DoesNotExist", "DoesNotExist"};
            }
        }
        
        #endregion

        #region Event Handlers

        // the application is closing: update variables to tell any external threads to stop
        private void FormMain_FormClosing(object sender, FormClosingEventArgs e)
        {
            _isApplicationClosing = true;
        }
        
        // Debug Menu 'do verbose logging' checkbox updated, begin showing/hiding verbose logging
        private void checkBox_doVerboseLogging_CheckedChanged(object sender, EventArgs e)
        {
            _twitchChatBot.DoVerboseLogging = checkBox_doVerboseLogging.Checked;
            // TODO save this setting to configs.
        }

        #endregion

        // reconnect button on the Debug page clicked. manually disconnect from IRC, wait, then reconnect.
        private void button_ForceReconnect_Click(object sender, EventArgs e)
        {
            // TODO: use _twitchChatBot.Chat(""); to post a message to chat -- should use the "chat message config" page for specific message
            _twitchChatBot.DisconnectWaitReconnect(_twitchBotCredentials[0], _twitchBotCredentials[1]);
        }
    }
}