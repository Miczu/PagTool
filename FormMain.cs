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
        private ChatBot twitchChatBot = new ChatBot();

        private string[] twitchBotCredentials;

        #endregion
        
        public FormMain()
        {
            // TODO: load configs, initialize variables, etc...
            //load twitch credentials
            twitchBotCredentials = CheckFileAndLoadTwitchCredentials("_secret.safe");
            
            // Load the form's components, then launch async tasks
            InitializeComponent();
            
            // thread to auto-refresh contents of components
            Thread updateAndRefreshComponentsThread = new Thread(new ThreadStart(UpdateThreadTimer));
            updateAndRefreshComponentsThread.Start();
            
            // connect twitch bot to IRC chat
            twitchChatBot.Connect(twitchBotCredentials[0], twitchBotCredentials[1]); //todo again this needs to be much more secure but this will do for now
        }
        
        #region Component Update Thread

        void UpdateThreadTimer()
        {
            while (true) // TODO: bad bad bad fix this
            {
                Thread.Sleep(1000 * 5); // every five seconds
                
                //update the text from the log output
                UpdateText(richTextBox_ConsoleDebugLog, twitchChatBot.LogOutput);
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
        
    }
}