﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace PagTool
{
    public class ConfigHotkeyResult
    {
        //variables to store hotkey MODIFIER and KEYS
        public int HKModSelectRandomUser = 0; public int HKKeySelectRandomUser = 0; //select random user
        public int HKModClearAllLists = 0; public int HKKeyClearAllLists = 0; //clear all lists
        public int HKModShuffleIntoWaitlist = 0; public int HKKeyShuffleIntoWaitlist = 0; //shuffle BOTH into waitlist
            
        //default values
        public ConfigHotkeyResult() { }

        //override values
        public ConfigHotkeyResult(int hkModSelectRandomUser, int hkKeySelectRandomUser,
            int hkModClearAllLists, int hkKeyClearAllLists,
            int hkModShuffleIntoWaitlist, int hkKeyShuffleIntoWaitlist)
        {
            HKModSelectRandomUser = hkModSelectRandomUser; HKKeySelectRandomUser = hkKeySelectRandomUser;
            HKModClearAllLists = hkModClearAllLists; HKKeyClearAllLists = hkKeyClearAllLists;
            HKModShuffleIntoWaitlist = hkModShuffleIntoWaitlist; HKKeyShuffleIntoWaitlist = hkKeyShuffleIntoWaitlist;
        }
    }

    public partial class ConfigHotkeyDialog : Form
    {
        private Keys[] ModKeys= { Keys.ControlKey, Keys.Menu, Keys.ShiftKey };

        private ConfigHotkeyResult updatedSettings = new ConfigHotkeyResult();

        public ConfigHotkeyDialog()
        {
            InitializeComponent();
        }
        
        private void textBox_SelectRandomUser_KeyDown(object sender, KeyEventArgs e)
        {
            //set updatedSettings anytime a change is made
            //...or, clear the hotkey if it ESC is pressed
            if (e.KeyCode == Keys.Escape)
            {
                e.Handled = true;
                e.SuppressKeyPress = true;
                updatedSettings.HKModSelectRandomUser = 0;
                updatedSettings.HKKeySelectRandomUser = 0;
                textBox_SelectRandomUser.Text = $"None";
            }
            else
            {
                bool isKeyPressedModKey = ModKeys.Contains(e.KeyCode);

                string isAltHeld = e.Alt ? "ALT + " : "";
                string isCtrlHeld = e.Control ? "CTRL + " : "";
                string isShiftHeld = e.Shift ? "SHIFT + " : "";
                string key = isKeyPressedModKey ? "..." : e.KeyCode.ToString();

                textBox_SelectRandomUser.Text = $"{isCtrlHeld}{isAltHeld}{isShiftHeld}{key}";
            
                //assign mod bitmask and key value, only if key isn't a mod key
                if (!isKeyPressedModKey)
                {
                    int mod = 0; mod += e.Alt ? 1 : 0; mod += e.Control ? 2 : 0; mod += e.Shift ? 4 : 0;
                    updatedSettings.HKModSelectRandomUser = mod;
                    updatedSettings.HKKeySelectRandomUser = e.KeyValue;
                } 
            }
        }
        
        private void textBox_ClearAllLists_KeyDown(object sender, KeyEventArgs e)
        {
            //set updatedSettings anytime a change is made
            //...or, clear the hotkey if it ESC is pressed
            if (e.KeyCode == Keys.Escape)
            {
                e.Handled = true;
                e.SuppressKeyPress = true;
                updatedSettings.HKModClearAllLists = 0;
                updatedSettings.HKKeyClearAllLists = 0;
                textBox_ClearAllLists.Text = $"None";
            }
            else
            {
                bool isKeyPressedModKey = ModKeys.Contains(e.KeyCode);

                string isAltHeld = e.Alt ? "ALT + " : "";
                string isCtrlHeld = e.Control ? "CTRL + " : "";
                string isShiftHeld = e.Shift ? "SHIFT + " : "";
                string key = isKeyPressedModKey ? "..." : e.KeyCode.ToString();

                textBox_ClearAllLists.Text = $"{isCtrlHeld}{isAltHeld}{isShiftHeld}{key}";
            
                //assign mod bitmask and key value, only if key isn't a mod key
                if (!isKeyPressedModKey)
                {
                    int mod = 0; mod += e.Alt ? 1 : 0; mod += e.Control ? 2 : 0; mod += e.Shift ? 4 : 0;
                    updatedSettings.HKModClearAllLists = mod;
                    updatedSettings.HKKeyClearAllLists = e.KeyValue;
                }
            }
        }
        
        private void textBox_ShuffleIntoWaitlist_KeyDown(object sender, KeyEventArgs e)
        {
            //set updatedSettings anytime a change is made
            //...or, clear the hotkey if it ESC is pressed
            if (e.KeyCode == Keys.Escape)
            {
                e.Handled = true;
                e.SuppressKeyPress = true;
                updatedSettings.HKModShuffleIntoWaitlist = 0;
                updatedSettings.HKKeyShuffleIntoWaitlist = 0;
                textBox_ShuffleIntoWaitlist.Text = $"None";
            }
            else
            {
                bool isKeyPressedModKey = ModKeys.Contains(e.KeyCode);

                string isAltHeld = e.Alt ? "ALT + " : "";
                string isCtrlHeld = e.Control ? "CTRL + " : "";
                string isShiftHeld = e.Shift ? "SHIFT + " : "";
                string key = isKeyPressedModKey ? "..." : e.KeyCode.ToString();

                textBox_ShuffleIntoWaitlist.Text = $"{isCtrlHeld}{isAltHeld}{isShiftHeld}{key}";
            
                //assign mod bitmask and key value, only if key isn't a mod key
                if (!isKeyPressedModKey)
                {
                    int mod = 0; mod += e.Alt ? 1 : 0; mod += e.Control ? 2 : 0; mod += e.Shift ? 4 : 0;
                    updatedSettings.HKModShuffleIntoWaitlist = mod;
                    updatedSettings.HKKeyShuffleIntoWaitlist = e.KeyValue;
                }
            }
        }

        public ConfigHotkeyResult Show(ConfigHotkeyResult currentSettings)
        {
            // set all components values based on currentSettings
            updatedSettings = currentSettings;
            
            if (Keys.TryParse<Keys>(currentSettings.HKKeySelectRandomUser.ToString(), out var selectRandomUser)) //parse Key by int value
                textBox_SelectRandomUser.Text = interpretBitmask(currentSettings.HKModSelectRandomUser) + selectRandomUser.ToString();

            if (Keys.TryParse<Keys>(currentSettings.HKKeyClearAllLists.ToString(), out var clearAllLists)) 
                textBox_ClearAllLists.Text = interpretBitmask(currentSettings.HKModClearAllLists) + clearAllLists.ToString();
            
            if (Keys.TryParse<Keys>(currentSettings.HKKeyShuffleIntoWaitlist.ToString(), out var shuffleIntoWaitlist)) //parse Key by int value
                textBox_ShuffleIntoWaitlist.Text = interpretBitmask(currentSettings.HKModShuffleIntoWaitlist) + shuffleIntoWaitlist.ToString();
            
            //show the dialog
            var result = ShowDialog();

            //check if user clicked OK 
            if (result == DialogResult.OK)
            {
                //updatedSettings is instantiated upon dialog creation and updated any time the fields are populated by user input.
                //if so, return updated settings
                return updatedSettings;
            } else
                return currentSettings; //don't save any changes
        }

        private string interpretBitmask(int mask)
        {
            //i seriously ought to be using bitwise operations or modulo or literally anything clever here but my brain is frying trying to figure 
            //out the right way to implement it so for now i'm just going to hardcode it

            switch (mask)
            {
                default:
                //case 0:
                    return "";
                case 1:
                    return "ALT + ";
                case 2:
                    return "CTRL + ";
                case 3:
                    return "CTRL + ALT + ";
                case 4:
                    return "SHIFT + ";
                case 5:
                    return "ALT + SHIFT + ";
                case 6:
                    return "CTRL + SHIFT + ";
                case 7:
                    return "CTRL + ALT + SHIFT + ";
            }
        }

        
    }
}