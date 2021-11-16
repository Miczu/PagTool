using System;
using System.Windows.Forms;

namespace PagTool
{
    //this result: stores every string needed to be accessed by ChatBot to send upon !chatCommand execution.
    public class ConfigCommandBehaviorResult
    {
        //defaults:
        public string ResponseCmdNameAdd = "$USERNAME, you are now waiting. $WAITCOUNT users are waiting in total.";
        public string ResponseCmdNameAlreadyExists = "$USERNAME, you have already been added! Wait for the list to be reset.";
        public string ResponseCmdCheckStatus = "$FULLSTATUS";
        public string ResponseCmdUserDrawn = "$USERNAME, you have been selected! Your lineage is now $LINEAGE.";
        public string ResponseCmdBlacklistTriggered = "$USERNAME, your name is blacklisted. Please change your username if you wish to be added.";
        public string ResponseCmdWaitlistEmpty = "The waitlist is currently empty! Type !name to be added to the waitlist.";
        public string ResponseCmdChatReconnect = "The program is reconnecting to chat... please wait a moment...";
        public string ChatReminder = "Type !name in chat to add yourself to the waiting pool.";
        public int ChatReminderSeconds = 600; //10 minutes
        public string ResponseCmdMoveToDead = "$USERNAME, fare thee well! You are now dead.";
        public string ResponseCmdCannotDie = "$USERNAME, you cannot die! Your name is not active!";
        public string ResponseCmdHelp = "Use !name to add yourself to the list. Use !dead to mark yourself as dead, when you die in battle.";
        
        //constructor using only default values
        public ConfigCommandBehaviorResult() { }
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
            textBox_ResponseCmdNameAlreadyExists.Text = currentSettings.ResponseCmdNameAlreadyExists;
            textBox_ResponseCmdCheckStatus.Text = currentSettings.ResponseCmdCheckStatus;
            textBox_ResponseCmdUserDrawn.Text = currentSettings.ResponseCmdUserDrawn;
            textBox_ResponseCmdBlacklistTriggered.Text = currentSettings.ResponseCmdBlacklistTriggered;
            textBox_ResponseCmdWaitlistEmpty.Text = currentSettings.ResponseCmdWaitlistEmpty;
            textBox_ResponseCmdChatReconnect.Text = currentSettings.ResponseCmdChatReconnect;
            textBox_ChatReminder.Text = currentSettings.ChatReminder;
            numericUpDown_ChatReminderSeconds.Value = currentSettings.ChatReminderSeconds;
            textBox_ResponseCmdMoveToDead.Text = currentSettings.ResponseCmdMoveToDead;
            textBox_ResponseCmdCannotDie.Text = currentSettings.ResponseCmdCannotDie;
            textBox_ResponseCmdHelp.Text = currentSettings.ResponseCmdHelp;

            //show the dialog
            var result = ShowDialog();

            //check if user clicked OK 
            if (result == DialogResult.OK)
            {
                //if so, set all updated settings and return it
                updatedSettings.ResponseCmdNameAdd = textBox_ResponseCmdAddName.Text;
                updatedSettings.ResponseCmdNameAlreadyExists = textBox_ResponseCmdNameAlreadyExists.Text;
                updatedSettings.ResponseCmdCheckStatus = textBox_ResponseCmdCheckStatus.Text;
                updatedSettings.ResponseCmdUserDrawn = textBox_ResponseCmdUserDrawn.Text;
                updatedSettings.ResponseCmdBlacklistTriggered = textBox_ResponseCmdBlacklistTriggered.Text;
                updatedSettings.ResponseCmdWaitlistEmpty = textBox_ResponseCmdWaitlistEmpty.Text;
                updatedSettings.ResponseCmdChatReconnect = textBox_ResponseCmdChatReconnect.Text;
                updatedSettings.ChatReminder = textBox_ChatReminder.Text;
                updatedSettings.ChatReminderSeconds = Convert.ToInt32(numericUpDown_ChatReminderSeconds.Value);
                updatedSettings.ResponseCmdMoveToDead = textBox_ResponseCmdMoveToDead.Text;
                updatedSettings.ResponseCmdCannotDie = textBox_ResponseCmdCannotDie.Text;
                updatedSettings.ResponseCmdHelp = textBox_ResponseCmdHelp.Text;
                
                return updatedSettings;
            } else
                return currentSettings;
        }

        private void label_FormatStringsSupported_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Format strings currently implemented:\n" +
                            "$TEST -- format string demo.\n" +
                            "$USERNAME -- prints the user's name.\n" +
                            "$LINEAGE -- prints the user's current lineage as an integer value.\n" +
                            "$WAITCOUNT -- the current number of users in the waitlist.\n" +
                            "$FULLSTATUS -- a complete report on the user's status in the list.\n" +
                            "$QUICKSTATUS -- a short report on a user's status.");
        }
    }
}