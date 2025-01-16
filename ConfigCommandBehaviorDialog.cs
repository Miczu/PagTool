using System;
using System.Windows.Forms;

namespace PagTool
{
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
            textBox_ResponseCmdAutoShuffledDead.Text = currentSettings.ResponseCmdAutoShuffledDead;
            textBox_ResponseCmdAutoShuffleNoDead.Text = currentSettings.ResponseCmdAutoShuffleNoDead;

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
                updatedSettings.ResponseCmdAutoShuffledDead = textBox_ResponseCmdAutoShuffledDead.Text;
                updatedSettings.ResponseCmdAutoShuffleNoDead = textBox_ResponseCmdAutoShuffleNoDead.Text;

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