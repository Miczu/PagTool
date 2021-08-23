namespace PagTool
{
    partial class FormMain
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }

            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.tabControl = new System.Windows.Forms.TabControl();
            this.tabPage_ModifyData = new System.Windows.Forms.TabPage();
            this.listBox_ListDead = new System.Windows.Forms.ListBox();
            this.listBox_ListActive = new System.Windows.Forms.ListBox();
            this.listBox_ListWaiting = new System.Windows.Forms.ListBox();
            this.button_ConfigListLogic = new System.Windows.Forms.Button();
            this.button_EditMainLists = new System.Windows.Forms.Button();
            this.button_EditLineage = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.tabPage_ConfigureCommands = new System.Windows.Forms.TabPage();
            this.button_ConfigCommandBehavior = new System.Windows.Forms.Button();
            this.button_ConfigCommandAliases = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.tabPage_LocalSettings = new System.Windows.Forms.TabPage();
            this.button_ImportExportData = new System.Windows.Forms.Button();
            this.button_ConfigCredentials = new System.Windows.Forms.Button();
            this.button_ConfigHotkeys = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.tabPage_Debug = new System.Windows.Forms.TabPage();
            this.button_ForceReconnect = new System.Windows.Forms.Button();
            this.checkBox_doVerboseLogging = new System.Windows.Forms.CheckBox();
            this.label_VersionInfo = new System.Windows.Forms.Label();
            this.richTextBox_ConsoleDebugLog = new System.Windows.Forms.RichTextBox();
            this.tabControl.SuspendLayout();
            this.tabPage_ModifyData.SuspendLayout();
            this.tabPage_ConfigureCommands.SuspendLayout();
            this.tabPage_LocalSettings.SuspendLayout();
            this.tabPage_Debug.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControl
            // 
            this.tabControl.Controls.Add(this.tabPage_ModifyData);
            this.tabControl.Controls.Add(this.tabPage_ConfigureCommands);
            this.tabControl.Controls.Add(this.tabPage_LocalSettings);
            this.tabControl.Controls.Add(this.tabPage_Debug);
            this.tabControl.Location = new System.Drawing.Point(0, 0);
            this.tabControl.Margin = new System.Windows.Forms.Padding(0);
            this.tabControl.Name = "tabControl";
            this.tabControl.SelectedIndex = 0;
            this.tabControl.Size = new System.Drawing.Size(800, 449);
            this.tabControl.TabIndex = 1;
            // 
            // tabPage_ModifyData
            // 
            this.tabPage_ModifyData.Controls.Add(this.listBox_ListDead);
            this.tabPage_ModifyData.Controls.Add(this.listBox_ListActive);
            this.tabPage_ModifyData.Controls.Add(this.listBox_ListWaiting);
            this.tabPage_ModifyData.Controls.Add(this.button_ConfigListLogic);
            this.tabPage_ModifyData.Controls.Add(this.button_EditMainLists);
            this.tabPage_ModifyData.Controls.Add(this.button_EditLineage);
            this.tabPage_ModifyData.Controls.Add(this.label3);
            this.tabPage_ModifyData.Location = new System.Drawing.Point(4, 22);
            this.tabPage_ModifyData.Name = "tabPage_ModifyData";
            this.tabPage_ModifyData.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage_ModifyData.Size = new System.Drawing.Size(792, 423);
            this.tabPage_ModifyData.TabIndex = 0;
            this.tabPage_ModifyData.Text = "Modify Data";
            this.tabPage_ModifyData.UseVisualStyleBackColor = true;
            // 
            // listBox_ListDead
            // 
            this.listBox_ListDead.FormattingEnabled = true;
            this.listBox_ListDead.Location = new System.Drawing.Point(531, 250);
            this.listBox_ListDead.Name = "listBox_ListDead";
            this.listBox_ListDead.Size = new System.Drawing.Size(253, 108);
            this.listBox_ListDead.TabIndex = 7;
            // 
            // listBox_ListActive
            // 
            this.listBox_ListActive.FormattingEnabled = true;
            this.listBox_ListActive.Location = new System.Drawing.Point(531, 136);
            this.listBox_ListActive.Name = "listBox_ListActive";
            this.listBox_ListActive.Size = new System.Drawing.Size(253, 108);
            this.listBox_ListActive.TabIndex = 6;
            // 
            // listBox_ListWaiting
            // 
            this.listBox_ListWaiting.FormattingEnabled = true;
            this.listBox_ListWaiting.Location = new System.Drawing.Point(531, 22);
            this.listBox_ListWaiting.Name = "listBox_ListWaiting";
            this.listBox_ListWaiting.Size = new System.Drawing.Size(253, 108);
            this.listBox_ListWaiting.TabIndex = 5;
            // 
            // button_ConfigListLogic
            // 
            this.button_ConfigListLogic.Location = new System.Drawing.Point(6, 96);
            this.button_ConfigListLogic.Name = "button_ConfigListLogic";
            this.button_ConfigListLogic.Size = new System.Drawing.Size(184, 43);
            this.button_ConfigListLogic.TabIndex = 3;
            this.button_ConfigListLogic.Text = "Configure List Logic";
            this.button_ConfigListLogic.UseVisualStyleBackColor = true;
            // 
            // button_EditMainLists
            // 
            this.button_EditMainLists.Location = new System.Drawing.Point(6, 47);
            this.button_EditMainLists.Name = "button_EditMainLists";
            this.button_EditMainLists.Size = new System.Drawing.Size(187, 43);
            this.button_EditMainLists.TabIndex = 2;
            this.button_EditMainLists.Text = "Edit Main Lists";
            this.button_EditMainLists.UseVisualStyleBackColor = true;
            // 
            // button_EditLineage
            // 
            this.button_EditLineage.Location = new System.Drawing.Point(6, 6);
            this.button_EditLineage.Name = "button_EditLineage";
            this.button_EditLineage.Size = new System.Drawing.Size(189, 35);
            this.button_EditLineage.TabIndex = 1;
            this.button_EditLineage.Text = "Edit Lineage";
            this.button_EditLineage.UseVisualStyleBackColor = true;
            // 
            // label3
            // 
            this.label3.Location = new System.Drawing.Point(296, 386);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(488, 33);
            this.label3.TabIndex = 0;
            this.label3.Text = "pop open list editors for every list, PLUS main editor with condensed view and po" + "p/push controls";
            // 
            // tabPage_ConfigureCommands
            // 
            this.tabPage_ConfigureCommands.Controls.Add(this.button_ConfigCommandBehavior);
            this.tabPage_ConfigureCommands.Controls.Add(this.button_ConfigCommandAliases);
            this.tabPage_ConfigureCommands.Controls.Add(this.label2);
            this.tabPage_ConfigureCommands.Location = new System.Drawing.Point(4, 22);
            this.tabPage_ConfigureCommands.Name = "tabPage_ConfigureCommands";
            this.tabPage_ConfigureCommands.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage_ConfigureCommands.Size = new System.Drawing.Size(792, 423);
            this.tabPage_ConfigureCommands.TabIndex = 1;
            this.tabPage_ConfigureCommands.Text = "Configure Commands";
            this.tabPage_ConfigureCommands.UseVisualStyleBackColor = true;
            // 
            // button_ConfigCommandBehavior
            // 
            this.button_ConfigCommandBehavior.Location = new System.Drawing.Point(9, 57);
            this.button_ConfigCommandBehavior.Name = "button_ConfigCommandBehavior";
            this.button_ConfigCommandBehavior.Size = new System.Drawing.Size(210, 40);
            this.button_ConfigCommandBehavior.TabIndex = 2;
            this.button_ConfigCommandBehavior.Text = "Configure Command Behavior";
            this.button_ConfigCommandBehavior.UseVisualStyleBackColor = true;
            this.button_ConfigCommandBehavior.Click += new System.EventHandler(this.button_ConfigCommandBehavior_Click);
            // 
            // button_ConfigCommandAliases
            // 
            this.button_ConfigCommandAliases.Location = new System.Drawing.Point(8, 6);
            this.button_ConfigCommandAliases.Name = "button_ConfigCommandAliases";
            this.button_ConfigCommandAliases.Size = new System.Drawing.Size(212, 37);
            this.button_ConfigCommandAliases.TabIndex = 1;
            this.button_ConfigCommandAliases.Text = "Configure Command Aliases";
            this.button_ConfigCommandAliases.UseVisualStyleBackColor = true;
            this.button_ConfigCommandAliases.Click += new System.EventHandler(this.button_ConfigCommandAliases_Click);
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(225, 347);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(550, 52);
            this.label2.TabIndex = 0;
            this.label2.Text = "configure command names and enable/disable them, configure command text sent to c" + "hat";
            // 
            // tabPage_LocalSettings
            // 
            this.tabPage_LocalSettings.Controls.Add(this.button_ImportExportData);
            this.tabPage_LocalSettings.Controls.Add(this.button_ConfigCredentials);
            this.tabPage_LocalSettings.Controls.Add(this.button_ConfigHotkeys);
            this.tabPage_LocalSettings.Controls.Add(this.label1);
            this.tabPage_LocalSettings.Location = new System.Drawing.Point(4, 22);
            this.tabPage_LocalSettings.Name = "tabPage_LocalSettings";
            this.tabPage_LocalSettings.Size = new System.Drawing.Size(792, 423);
            this.tabPage_LocalSettings.TabIndex = 2;
            this.tabPage_LocalSettings.Text = "Local Settings";
            this.tabPage_LocalSettings.UseVisualStyleBackColor = true;
            // 
            // button_ImportExportData
            // 
            this.button_ImportExportData.Location = new System.Drawing.Point(10, 100);
            this.button_ImportExportData.Name = "button_ImportExportData";
            this.button_ImportExportData.Size = new System.Drawing.Size(188, 39);
            this.button_ImportExportData.TabIndex = 3;
            this.button_ImportExportData.Text = "Import / Export Data";
            this.button_ImportExportData.UseVisualStyleBackColor = true;
            // 
            // button_ConfigCredentials
            // 
            this.button_ConfigCredentials.Location = new System.Drawing.Point(8, 56);
            this.button_ConfigCredentials.Name = "button_ConfigCredentials";
            this.button_ConfigCredentials.Size = new System.Drawing.Size(191, 31);
            this.button_ConfigCredentials.TabIndex = 2;
            this.button_ConfigCredentials.Text = "Configure Twitch Credentials";
            this.button_ConfigCredentials.UseVisualStyleBackColor = true;
            // 
            // button_ConfigHotkeys
            // 
            this.button_ConfigHotkeys.Location = new System.Drawing.Point(8, 13);
            this.button_ConfigHotkeys.Name = "button_ConfigHotkeys";
            this.button_ConfigHotkeys.Size = new System.Drawing.Size(191, 28);
            this.button_ConfigHotkeys.TabIndex = 1;
            this.button_ConfigHotkeys.Text = "Configure Hotkeys";
            this.button_ConfigHotkeys.UseVisualStyleBackColor = true;
            this.button_ConfigHotkeys.Click += new System.EventHandler(this.button_ConfigHotkeys_Click);
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(297, 204);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(301, 27);
            this.label1.TabIndex = 0;
            this.label1.Text = "hotkeys, import/export config files, change credentials, etc";
            // 
            // tabPage_Debug
            // 
            this.tabPage_Debug.Controls.Add(this.button_ForceReconnect);
            this.tabPage_Debug.Controls.Add(this.checkBox_doVerboseLogging);
            this.tabPage_Debug.Controls.Add(this.label_VersionInfo);
            this.tabPage_Debug.Controls.Add(this.richTextBox_ConsoleDebugLog);
            this.tabPage_Debug.Location = new System.Drawing.Point(4, 22);
            this.tabPage_Debug.Name = "tabPage_Debug";
            this.tabPage_Debug.Size = new System.Drawing.Size(792, 423);
            this.tabPage_Debug.TabIndex = 3;
            this.tabPage_Debug.Text = "Debug";
            this.tabPage_Debug.UseVisualStyleBackColor = true;
            // 
            // button_ForceReconnect
            // 
            this.button_ForceReconnect.Location = new System.Drawing.Point(685, 29);
            this.button_ForceReconnect.Name = "button_ForceReconnect";
            this.button_ForceReconnect.Size = new System.Drawing.Size(99, 21);
            this.button_ForceReconnect.TabIndex = 5;
            this.button_ForceReconnect.Text = "Force Reconnect";
            this.button_ForceReconnect.UseVisualStyleBackColor = true;
            this.button_ForceReconnect.Click += new System.EventHandler(this.button_ForceReconnect_Click);
            // 
            // checkBox_doVerboseLogging
            // 
            this.checkBox_doVerboseLogging.Location = new System.Drawing.Point(8, 29);
            this.checkBox_doVerboseLogging.Name = "checkBox_doVerboseLogging";
            this.checkBox_doVerboseLogging.Size = new System.Drawing.Size(86, 21);
            this.checkBox_doVerboseLogging.TabIndex = 4;
            this.checkBox_doVerboseLogging.Text = "Verbose Log";
            this.checkBox_doVerboseLogging.UseVisualStyleBackColor = true;
            this.checkBox_doVerboseLogging.CheckedChanged += new System.EventHandler(this.checkBox_doVerboseLogging_CheckedChanged);
            // 
            // label_VersionInfo
            // 
            this.label_VersionInfo.Location = new System.Drawing.Point(8, 9);
            this.label_VersionInfo.Name = "label_VersionInfo";
            this.label_VersionInfo.Size = new System.Drawing.Size(776, 17);
            this.label_VersionInfo.TabIndex = 3;
            this.label_VersionInfo.Text = "Version 2.01b || https://github.com/corptact/PagTool || Do Not Distribute || Corp" + "orate Tactics 2021";
            this.label_VersionInfo.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // richTextBox_ConsoleDebugLog
            // 
            this.richTextBox_ConsoleDebugLog.Location = new System.Drawing.Point(8, 56);
            this.richTextBox_ConsoleDebugLog.Name = "richTextBox_ConsoleDebugLog";
            this.richTextBox_ConsoleDebugLog.Size = new System.Drawing.Size(776, 360);
            this.richTextBox_ConsoleDebugLog.TabIndex = 2;
            this.richTextBox_ConsoleDebugLog.Text = "";
            // 
            // FormMain
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.tabControl);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "FormMain";
            this.Text = "PagTool";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FormMain_FormClosing);
            this.tabControl.ResumeLayout(false);
            this.tabPage_ModifyData.ResumeLayout(false);
            this.tabPage_ConfigureCommands.ResumeLayout(false);
            this.tabPage_LocalSettings.ResumeLayout(false);
            this.tabPage_Debug.ResumeLayout(false);
            this.ResumeLayout(false);
        }

        private System.Windows.Forms.Button button_ConfigCommandAliases;
        private System.Windows.Forms.Button button_ConfigCommandBehavior;
        private System.Windows.Forms.Button button_ConfigCredentials;
        private System.Windows.Forms.Button button_ConfigHotkeys;
        private System.Windows.Forms.Button button_ConfigListLogic;
        private System.Windows.Forms.Button button_EditLineage;
        private System.Windows.Forms.Button button_EditMainLists;
        private System.Windows.Forms.Button button_ForceReconnect;
        private System.Windows.Forms.Button button_ImportExportData;
        private System.Windows.Forms.CheckBox checkBox_doVerboseLogging;
        private System.Windows.Forms.Label label_VersionInfo;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ListBox listBox_ListActive;
        private System.Windows.Forms.ListBox listBox_ListDead;
        private System.Windows.Forms.ListBox listBox_ListWaiting;
        private System.Windows.Forms.RichTextBox richTextBox_ConsoleDebugLog;
        private System.Windows.Forms.TabControl tabControl;
        private System.Windows.Forms.TabPage tabPage_ConfigureCommands;
        private System.Windows.Forms.TabPage tabPage_Debug;
        private System.Windows.Forms.TabPage tabPage_LocalSettings;
        private System.Windows.Forms.TabPage tabPage_ModifyData;

        #endregion
    }
}