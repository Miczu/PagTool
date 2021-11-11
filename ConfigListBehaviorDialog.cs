using System;
using System.Windows.Forms;
using TwitchLib.Api.Core.Exceptions;

namespace PagTool
{
    public partial class ConfigListBehaviorDialog : Form
    {
        private GeneralSettings thisSettings;
        
        public ConfigListBehaviorDialog()
        {
            InitializeComponent();
        }

        public GeneralSettings Show(GeneralSettings currentSettings)
        {
            thisSettings = currentSettings;
            
            //populate all switches based on currentSettings
            comboBox_LineageMode.SelectedIndex = (int) currentSettings.LineageMode;
            checkBox_DoOmitFirstLineage.Checked = currentSettings.DoOmitFirstLineage;
            
            
            
            
            DialogResult res = ShowDialog(); //show the dialog: all changes to settings will be set by components in their update events
            
            if (res == DialogResult.OK) //if affirmative
            {
                return thisSettings;
            }
            else //cancel, don't make changes
                return currentSettings;
        }

        private void comboBox_LineageMode_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (comboBox_LineageMode.SelectedIndex)
            {
                case 1:
                    thisSettings.LineageMode = GeneralSettings.LINEAGE_MODE.LINEAGE_NUMERAL;
                    break;
                case 2:
                    thisSettings.LineageMode = GeneralSettings.LINEAGE_MODE.LINEAGE_WORDS;
                    break;
                case 3:
                    thisSettings.LineageMode = GeneralSettings.LINEAGE_MODE.LINEAGE_ROMAN;
                    break;
                case 0: 
                default:
                    thisSettings.LineageMode = GeneralSettings.LINEAGE_MODE.LINEAGE_NONE;
                    break;
            }
        }

        private void checkBox_DoOmitFirstLineage_CheckedChanged(object sender, EventArgs e)
        {
            thisSettings.DoOmitFirstLineage = checkBox_DoOmitFirstLineage.Checked;
        }
    }
}