using System;
using System.Windows.Forms;

namespace PagTool
{
    //this result: stores every string needed to be accessed by ChatBot to send upon !chatCommand execution.
    public class ConfigCommandBehaviorResult
    {
        //defaults:
        public string ResponseCmdNameAdd = "";
        public string ResponseCmdWaitlistEmpty = "";
        public string ResponseCmdChatReconnect = "";
        public string ResponseCmdSelectRandomUser = "";

        //constructor using only default values
        public ConfigCommandBehaviorResult() { }

        //define values (passed to form when loading current settings from memory)
        public ConfigCommandBehaviorResult(string responseCmdNameAdd)
        {
            ResponseCmdNameAdd = responseCmdNameAdd;
        }
    }
    
    //IN THIS FORM: define the text that will return to the users after completing a !chatCommand
    // can be null? ChatBot should check for this text, replace any $FORMATSTRINGS, and chat it (if not empty)
    // $FORMATSTRING examples could be @<username> or <lineageNumber> or whatever is contextually important. this will be a TODO
    public partial class ConfigCommandBehaviorDialog : Form
    {
        public ConfigCommandBehaviorDialog()
        {
            InitializeComponent();
        }

        public ConfigCommandBehaviorResult Show(ConfigCommandBehaviorResult currentSettings)
        {
            //create new result to return if settings are changed
            ConfigCommandBehaviorResult updatedSettings = new ConfigCommandBehaviorResult();
            
            // set all components values based on currentSettings
            textBox_ResponseCmdAddName.Text = currentSettings.ResponseCmdNameAdd;

            //show the dialog
            var result = ShowDialog();

            //check if user clicked OK 
            if (result == DialogResult.OK)
            {
                //if so, set all updated settings and return it
                updatedSettings.ResponseCmdNameAdd = textBox_ResponseCmdAddName.Text;
                
                return updatedSettings;
            } else
                return currentSettings;
        }
        
    }
}