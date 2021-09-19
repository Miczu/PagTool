using System;
using System.Linq;
using System.Windows.Forms;
using System.Windows.Forms.VisualStyles;

namespace PagTool
{
    // this class will define everything in the dialog and return it on Show() when DialogResult is OK
    
    // from FormMain: pass in one of these with all current settings
    // populate dialog using current settings Result object and then display it
    // user changes (maybe) settings, clicks on OK / Cancel
    // if OK: store all changes to the result and pass it back to FormMain
    // otherwise: return unchanged result
    public class ConfigCommandAliasResult
    {
        // list all switches / settings in order here
        // for this dialog: command descriptor (e.g., Add Name (!name)) + command aliases (with one minimum default value)
        public bool DoCmdNameAdd = true; public string[] AliasCmdNameAdd = new []{"name"}; //add me to the list.
        public bool DoCmdCheckStatus = true; public string[] AliasCmdCheckStatus = new []{"status"}; //where am i in the list?

        //use defaults only
        public ConfigCommandAliasResult() { }

        // define all default values in the constructor
        public ConfigCommandAliasResult(bool doCmdNameAdd, string[] aliasCmdNameAdd,
                                        bool doCmdCheckStatus, string[] aliasCmdCheckStatus)
        {
            DoCmdNameAdd = doCmdNameAdd; AliasCmdNameAdd = aliasCmdNameAdd;
            DoCmdCheckStatus = doCmdNameAdd; AliasCmdCheckStatus = aliasCmdCheckStatus;
        }
    }
    
    // IN THIS FORM: define the names of the !commands that chat can use to trigger various functions. 
    // e.g., !name can be reconfigured to be any !text or !word chosen and will still trigger.
    // can also define multiple aliases for each command.
    // ChatBot will iterate through all AliasCmd[] during OnChatCommandReceived to check for a match
    public partial class ConfigCommandAliasDialog : Form
    { 
        public ConfigCommandAliasDialog()
        {
            InitializeComponent();
        }

        public ConfigCommandAliasResult Show(ConfigCommandAliasResult currentSettings)
        {
            ConfigCommandAliasResult updatedSettings = new ConfigCommandAliasResult();
            
            // set all components values based on currentSettings
            checkBox_DoCmdNameAdd.Checked = currentSettings.DoCmdNameAdd;
            textBox_AliasDoCmdNameAdd.Text = (currentSettings.AliasCmdNameAdd == null) ? 
                "name" : (String.Join(" ", currentSettings.AliasCmdNameAdd));
                
            checkBox_DoCmdCheckStatus.Checked = currentSettings.DoCmdCheckStatus;
            textBox_AliasDoCmdCheckStatus.Text = (currentSettings.AliasCmdCheckStatus == null) ? 
                "status" : (String.Join(" ", currentSettings.AliasCmdCheckStatus));
            
            //show the dialog
            var result = ShowDialog();

            //check if user clicked OK 
            if (result == DialogResult.OK)
            {
                //if so, set all updated settings and return it
                updatedSettings.DoCmdNameAdd = checkBox_DoCmdNameAdd.Checked;
                updatedSettings.AliasCmdNameAdd = (String.IsNullOrWhiteSpace(textBox_AliasDoCmdNameAdd.Text)) ? //if the text field is empty, make sure we set the default
                    new[] {"name"} : textBox_AliasDoCmdNameAdd.Text.Split(' ');
                    
                updatedSettings.DoCmdCheckStatus = checkBox_DoCmdCheckStatus.Checked;
                updatedSettings.AliasCmdCheckStatus = (String.IsNullOrWhiteSpace(textBox_AliasDoCmdCheckStatus.Text)) ? 
                    new[] {"status"} : textBox_AliasDoCmdCheckStatus.Text.Split(' ');
                
                return updatedSettings;
            } else
                return currentSettings;
        }
    }
}