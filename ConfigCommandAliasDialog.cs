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
        public bool DoCmdNameAdd; public string ArgsCmdNameAdd; public string[] AliasCmdNameAdd;

        // define all default values in the constructor
        public ConfigCommandAliasResult(bool doCmdNameAdd = true, string argsCmdNameAdd = "name", string[] aliasCmdNameAdd = null)
        {
            DoCmdNameAdd = doCmdNameAdd; ArgsCmdNameAdd = argsCmdNameAdd; AliasCmdNameAdd = aliasCmdNameAdd;
        }
    }
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
            textBox_ArgsDoCmdNameAdd.Text = currentSettings.ArgsCmdNameAdd;
            textBox_AliasDoCmdNameAdd.Text = (currentSettings.AliasCmdNameAdd == null) ? 
                "" : (String.Join(" ", currentSettings.AliasCmdNameAdd));
            
            //show the dialog
            var result = ShowDialog();

            //check if user clicked OK 
            if (result == DialogResult.OK)
            {
                //if so, set all updated settings and return it
                updatedSettings.DoCmdNameAdd = checkBox_DoCmdNameAdd.Checked;
                updatedSettings.ArgsCmdNameAdd = textBox_ArgsDoCmdNameAdd.Text;
                updatedSettings.AliasCmdNameAdd = textBox_AliasDoCmdNameAdd.Text.Split(' ');

                return updatedSettings;
            } else
                return currentSettings;
        }
    }
}