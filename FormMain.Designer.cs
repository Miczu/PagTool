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
            this.richTextBox_SelectedUserDisplay = new System.Windows.Forms.RichTextBox();
            this.listBox_CurrentLineage = new System.Windows.Forms.ListBox();
            this.verticalDivider2 = new System.Windows.Forms.Label();
            this.button4 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.button_ListDead_Remove = new System.Windows.Forms.Button();
            this.button_ListDead_Add = new System.Windows.Forms.Button();
            this.button_ListDead_MoveToActive = new System.Windows.Forms.Button();
            this.button_ListDead_MoveToWaiting = new System.Windows.Forms.Button();
            this.button_ListActive_MoveToDead = new System.Windows.Forms.Button();
            this.button_ListActive_Remove = new System.Windows.Forms.Button();
            this.button_ListActive_Add = new System.Windows.Forms.Button();
            this.button_ListActive_MoveToWaiting = new System.Windows.Forms.Button();
            this.button_ListWaiting_MoveToDead = new System.Windows.Forms.Button();
            this.button_ListWaiting_MoveToActive = new System.Windows.Forms.Button();
            this.button_ListWaiting_Remove = new System.Windows.Forms.Button();
            this.button_ListWaiting_Add = new System.Windows.Forms.Button();
            this.listBox_ListDead = new System.Windows.Forms.ListBox();
            this.listBox_ListActive = new System.Windows.Forms.ListBox();
            this.listBox_ListWaiting = new System.Windows.Forms.ListBox();
            this.button_ConfigListLogic = new System.Windows.Forms.Button();
            this.button_EditMainLists = new System.Windows.Forms.Button();
            this.button_EditLineage = new System.Windows.Forms.Button();
            this.tabPage_ConfigureCommands = new System.Windows.Forms.TabPage();
            this.button_ConfigCommandBehavior = new System.Windows.Forms.Button();
            this.button_ConfigCommandAliases = new System.Windows.Forms.Button();
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
            this.button_ForceUpdate = new System.Windows.Forms.Button();
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
            this.tabControl.Size = new System.Drawing.Size(800, 450);
            this.tabControl.TabIndex = 1;
            // 
            // tabPage_ModifyData
            // 
            this.tabPage_ModifyData.Controls.Add(this.richTextBox_SelectedUserDisplay);
            this.tabPage_ModifyData.Controls.Add(this.listBox_CurrentLineage);
            this.tabPage_ModifyData.Controls.Add(this.verticalDivider2);
            this.tabPage_ModifyData.Controls.Add(this.button4);
            this.tabPage_ModifyData.Controls.Add(this.button3);
            this.tabPage_ModifyData.Controls.Add(this.button2);
            this.tabPage_ModifyData.Controls.Add(this.button1);
            this.tabPage_ModifyData.Controls.Add(this.label2);
            this.tabPage_ModifyData.Controls.Add(this.button_ListDead_Remove);
            this.tabPage_ModifyData.Controls.Add(this.button_ListDead_Add);
            this.tabPage_ModifyData.Controls.Add(this.button_ListDead_MoveToActive);
            this.tabPage_ModifyData.Controls.Add(this.button_ListDead_MoveToWaiting);
            this.tabPage_ModifyData.Controls.Add(this.button_ListActive_MoveToDead);
            this.tabPage_ModifyData.Controls.Add(this.button_ListActive_Remove);
            this.tabPage_ModifyData.Controls.Add(this.button_ListActive_Add);
            this.tabPage_ModifyData.Controls.Add(this.button_ListActive_MoveToWaiting);
            this.tabPage_ModifyData.Controls.Add(this.button_ListWaiting_MoveToDead);
            this.tabPage_ModifyData.Controls.Add(this.button_ListWaiting_MoveToActive);
            this.tabPage_ModifyData.Controls.Add(this.button_ListWaiting_Remove);
            this.tabPage_ModifyData.Controls.Add(this.button_ListWaiting_Add);
            this.tabPage_ModifyData.Controls.Add(this.listBox_ListDead);
            this.tabPage_ModifyData.Controls.Add(this.listBox_ListActive);
            this.tabPage_ModifyData.Controls.Add(this.listBox_ListWaiting);
            this.tabPage_ModifyData.Controls.Add(this.button_ConfigListLogic);
            this.tabPage_ModifyData.Controls.Add(this.button_EditMainLists);
            this.tabPage_ModifyData.Controls.Add(this.button_EditLineage);
            this.tabPage_ModifyData.Location = new System.Drawing.Point(4, 22);
            this.tabPage_ModifyData.Name = "tabPage_ModifyData";
            this.tabPage_ModifyData.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage_ModifyData.Size = new System.Drawing.Size(792, 424);
            this.tabPage_ModifyData.TabIndex = 0;
            this.tabPage_ModifyData.Text = "Modify Data";
            this.tabPage_ModifyData.UseVisualStyleBackColor = true;
            // 
            // richTextBox_SelectedUserDisplay
            // 
            this.richTextBox_SelectedUserDisplay.Location = new System.Drawing.Point(6, 388);
            this.richTextBox_SelectedUserDisplay.Name = "richTextBox_SelectedUserDisplay";
            this.richTextBox_SelectedUserDisplay.Size = new System.Drawing.Size(250, 30);
            this.richTextBox_SelectedUserDisplay.TabIndex = 28;
            this.richTextBox_SelectedUserDisplay.Text = "";
            // 
            // listBox_CurrentLineage
            // 
            this.listBox_CurrentLineage.FormattingEnabled = true;
            this.listBox_CurrentLineage.Location = new System.Drawing.Point(270, 6);
            this.listBox_CurrentLineage.Name = "listBox_CurrentLineage";
            this.listBox_CurrentLineage.Size = new System.Drawing.Size(220, 381);
            this.listBox_CurrentLineage.TabIndex = 27;
            // 
            // verticalDivider2
            // 
            this.verticalDivider2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.verticalDivider2.Location = new System.Drawing.Point(262, 0);
            this.verticalDivider2.Margin = new System.Windows.Forms.Padding(3);
            this.verticalDivider2.Name = "verticalDivider2";
            this.verticalDivider2.Size = new System.Drawing.Size(2, 424);
            this.verticalDivider2.TabIndex = 26;
            // 
            // button4
            // 
            this.button4.Enabled = false;
            this.button4.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte) (0)));
            this.button4.Location = new System.Drawing.Point(368, 393);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(26, 26);
            this.button4.TabIndex = 25;
            this.button4.Text = "+";
            this.button4.UseVisualStyleBackColor = true;
            // 
            // button3
            // 
            this.button3.Enabled = false;
            this.button3.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte) (0)));
            this.button3.Location = new System.Drawing.Point(400, 393);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(26, 26);
            this.button3.TabIndex = 24;
            this.button3.Text = "+";
            this.button3.UseVisualStyleBackColor = true;
            // 
            // button2
            // 
            this.button2.Enabled = false;
            this.button2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte) (0)));
            this.button2.Location = new System.Drawing.Point(432, 393);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(26, 26);
            this.button2.TabIndex = 23;
            this.button2.Text = "+";
            this.button2.UseVisualStyleBackColor = true;
            // 
            // button1
            // 
            this.button1.Enabled = false;
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte) (0)));
            this.button1.Location = new System.Drawing.Point(464, 393);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(26, 26);
            this.button1.TabIndex = 22;
            this.button1.Text = "+";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // label2
            // 
            this.label2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label2.Location = new System.Drawing.Point(496, 0);
            this.label2.Margin = new System.Windows.Forms.Padding(3);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(2, 424);
            this.label2.TabIndex = 21;
            // 
            // button_ListDead_Remove
            // 
            this.button_ListDead_Remove.Enabled = false;
            this.button_ListDead_Remove.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte) (0)));
            this.button_ListDead_Remove.Location = new System.Drawing.Point(504, 393);
            this.button_ListDead_Remove.Name = "button_ListDead_Remove";
            this.button_ListDead_Remove.Size = new System.Drawing.Size(26, 26);
            this.button_ListDead_Remove.TabIndex = 20;
            this.button_ListDead_Remove.Text = "x";
            this.button_ListDead_Remove.UseVisualStyleBackColor = true;
            this.button_ListDead_Remove.Click += new System.EventHandler(this.button_ListDead_Remove_Click);
            // 
            // button_ListDead_Add
            // 
            this.button_ListDead_Add.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte) (0)));
            this.button_ListDead_Add.Location = new System.Drawing.Point(504, 361);
            this.button_ListDead_Add.Name = "button_ListDead_Add";
            this.button_ListDead_Add.Size = new System.Drawing.Size(26, 26);
            this.button_ListDead_Add.TabIndex = 19;
            this.button_ListDead_Add.Text = "+";
            this.button_ListDead_Add.UseVisualStyleBackColor = true;
            this.button_ListDead_Add.Click += new System.EventHandler(this.button_ListDead_Add_Click);
            // 
            // button_ListDead_MoveToActive
            // 
            this.button_ListDead_MoveToActive.Enabled = false;
            this.button_ListDead_MoveToActive.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte) (0)));
            this.button_ListDead_MoveToActive.Location = new System.Drawing.Point(504, 328);
            this.button_ListDead_MoveToActive.Name = "button_ListDead_MoveToActive";
            this.button_ListDead_MoveToActive.Size = new System.Drawing.Size(26, 26);
            this.button_ListDead_MoveToActive.TabIndex = 18;
            this.button_ListDead_MoveToActive.Text = "↑";
            this.button_ListDead_MoveToActive.UseVisualStyleBackColor = true;
            this.button_ListDead_MoveToActive.Click += new System.EventHandler(this.button_ListDead_MoveToActive_Click);
            // 
            // button_ListDead_MoveToWaiting
            // 
            this.button_ListDead_MoveToWaiting.Enabled = false;
            this.button_ListDead_MoveToWaiting.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte) (0)));
            this.button_ListDead_MoveToWaiting.Location = new System.Drawing.Point(504, 296);
            this.button_ListDead_MoveToWaiting.Name = "button_ListDead_MoveToWaiting";
            this.button_ListDead_MoveToWaiting.Size = new System.Drawing.Size(26, 26);
            this.button_ListDead_MoveToWaiting.TabIndex = 17;
            this.button_ListDead_MoveToWaiting.Text = "⇈";
            this.button_ListDead_MoveToWaiting.UseVisualStyleBackColor = true;
            this.button_ListDead_MoveToWaiting.Click += new System.EventHandler(this.button_ListDead_MoveToWaiting_Click);
            // 
            // button_ListActive_MoveToDead
            // 
            this.button_ListActive_MoveToDead.Enabled = false;
            this.button_ListActive_MoveToDead.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte) (0)));
            this.button_ListActive_MoveToDead.Location = new System.Drawing.Point(504, 248);
            this.button_ListActive_MoveToDead.Name = "button_ListActive_MoveToDead";
            this.button_ListActive_MoveToDead.Size = new System.Drawing.Size(26, 26);
            this.button_ListActive_MoveToDead.TabIndex = 16;
            this.button_ListActive_MoveToDead.Text = "↓";
            this.button_ListActive_MoveToDead.UseVisualStyleBackColor = true;
            this.button_ListActive_MoveToDead.Click += new System.EventHandler(this.button_ListActive_MoveToDead_Click);
            // 
            // button_ListActive_Remove
            // 
            this.button_ListActive_Remove.Enabled = false;
            this.button_ListActive_Remove.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte) (0)));
            this.button_ListActive_Remove.Location = new System.Drawing.Point(504, 216);
            this.button_ListActive_Remove.Name = "button_ListActive_Remove";
            this.button_ListActive_Remove.Size = new System.Drawing.Size(26, 26);
            this.button_ListActive_Remove.TabIndex = 15;
            this.button_ListActive_Remove.Text = "x";
            this.button_ListActive_Remove.UseVisualStyleBackColor = true;
            this.button_ListActive_Remove.Click += new System.EventHandler(this.button_ListActive_Remove_Click);
            // 
            // button_ListActive_Add
            // 
            this.button_ListActive_Add.Anchor = ((System.Windows.Forms.AnchorStyles) ((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.button_ListActive_Add.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte) (0)));
            this.button_ListActive_Add.Location = new System.Drawing.Point(504, 183);
            this.button_ListActive_Add.Name = "button_ListActive_Add";
            this.button_ListActive_Add.Size = new System.Drawing.Size(26, 26);
            this.button_ListActive_Add.TabIndex = 14;
            this.button_ListActive_Add.Text = "+";
            this.button_ListActive_Add.UseVisualStyleBackColor = true;
            this.button_ListActive_Add.Click += new System.EventHandler(this.button_ListActive_Add_Click);
            // 
            // button_ListActive_MoveToWaiting
            // 
            this.button_ListActive_MoveToWaiting.Anchor = ((System.Windows.Forms.AnchorStyles) ((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.button_ListActive_MoveToWaiting.Enabled = false;
            this.button_ListActive_MoveToWaiting.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte) (0)));
            this.button_ListActive_MoveToWaiting.Location = new System.Drawing.Point(504, 151);
            this.button_ListActive_MoveToWaiting.Name = "button_ListActive_MoveToWaiting";
            this.button_ListActive_MoveToWaiting.Size = new System.Drawing.Size(26, 26);
            this.button_ListActive_MoveToWaiting.TabIndex = 13;
            this.button_ListActive_MoveToWaiting.Text = "↑";
            this.button_ListActive_MoveToWaiting.UseVisualStyleBackColor = true;
            this.button_ListActive_MoveToWaiting.Click += new System.EventHandler(this.button_ListActive_MoveToWaiting_Click);
            // 
            // button_ListWaiting_MoveToDead
            // 
            this.button_ListWaiting_MoveToDead.Anchor = ((System.Windows.Forms.AnchorStyles) ((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.button_ListWaiting_MoveToDead.Enabled = false;
            this.button_ListWaiting_MoveToDead.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte) (0)));
            this.button_ListWaiting_MoveToDead.Location = new System.Drawing.Point(504, 102);
            this.button_ListWaiting_MoveToDead.Name = "button_ListWaiting_MoveToDead";
            this.button_ListWaiting_MoveToDead.Size = new System.Drawing.Size(26, 26);
            this.button_ListWaiting_MoveToDead.TabIndex = 12;
            this.button_ListWaiting_MoveToDead.Text = "⇊";
            this.button_ListWaiting_MoveToDead.UseVisualStyleBackColor = true;
            this.button_ListWaiting_MoveToDead.Click += new System.EventHandler(this.button_ListWaiting_MoveToDead_Click);
            // 
            // button_ListWaiting_MoveToActive
            // 
            this.button_ListWaiting_MoveToActive.Anchor = ((System.Windows.Forms.AnchorStyles) ((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.button_ListWaiting_MoveToActive.Enabled = false;
            this.button_ListWaiting_MoveToActive.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte) (0)));
            this.button_ListWaiting_MoveToActive.Location = new System.Drawing.Point(504, 70);
            this.button_ListWaiting_MoveToActive.Name = "button_ListWaiting_MoveToActive";
            this.button_ListWaiting_MoveToActive.Size = new System.Drawing.Size(26, 26);
            this.button_ListWaiting_MoveToActive.TabIndex = 11;
            this.button_ListWaiting_MoveToActive.Text = "↓";
            this.button_ListWaiting_MoveToActive.UseVisualStyleBackColor = true;
            this.button_ListWaiting_MoveToActive.Click += new System.EventHandler(this.button_ListWaiting_MoveToActive_Click);
            // 
            // button_ListWaiting_Remove
            // 
            this.button_ListWaiting_Remove.Anchor = ((System.Windows.Forms.AnchorStyles) ((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.button_ListWaiting_Remove.Enabled = false;
            this.button_ListWaiting_Remove.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte) (0)));
            this.button_ListWaiting_Remove.Location = new System.Drawing.Point(504, 37);
            this.button_ListWaiting_Remove.Name = "button_ListWaiting_Remove";
            this.button_ListWaiting_Remove.Size = new System.Drawing.Size(26, 26);
            this.button_ListWaiting_Remove.TabIndex = 10;
            this.button_ListWaiting_Remove.Text = "x";
            this.button_ListWaiting_Remove.UseVisualStyleBackColor = true;
            this.button_ListWaiting_Remove.Click += new System.EventHandler(this.button_ListWaiting_Remove_Click);
            // 
            // button_ListWaiting_Add
            // 
            this.button_ListWaiting_Add.Anchor = ((System.Windows.Forms.AnchorStyles) ((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.button_ListWaiting_Add.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte) (0)));
            this.button_ListWaiting_Add.Location = new System.Drawing.Point(504, 5);
            this.button_ListWaiting_Add.Name = "button_ListWaiting_Add";
            this.button_ListWaiting_Add.Size = new System.Drawing.Size(26, 26);
            this.button_ListWaiting_Add.TabIndex = 9;
            this.button_ListWaiting_Add.Text = "+";
            this.button_ListWaiting_Add.UseVisualStyleBackColor = true;
            this.button_ListWaiting_Add.Click += new System.EventHandler(this.button_ListWaiting_Add_Click);
            // 
            // listBox_ListDead
            // 
            this.listBox_ListDead.Anchor = ((System.Windows.Forms.AnchorStyles) ((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.listBox_ListDead.FormattingEnabled = true;
            this.listBox_ListDead.Location = new System.Drawing.Point(536, 297);
            this.listBox_ListDead.Name = "listBox_ListDead";
            this.listBox_ListDead.Size = new System.Drawing.Size(250, 121);
            this.listBox_ListDead.TabIndex = 7;
            // 
            // listBox_ListActive
            // 
            this.listBox_ListActive.Anchor = ((System.Windows.Forms.AnchorStyles) ((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.listBox_ListActive.FormattingEnabled = true;
            this.listBox_ListActive.Location = new System.Drawing.Point(536, 152);
            this.listBox_ListActive.Name = "listBox_ListActive";
            this.listBox_ListActive.Size = new System.Drawing.Size(250, 121);
            this.listBox_ListActive.TabIndex = 6;
            // 
            // listBox_ListWaiting
            // 
            this.listBox_ListWaiting.Anchor = ((System.Windows.Forms.AnchorStyles) ((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.listBox_ListWaiting.FormattingEnabled = true;
            this.listBox_ListWaiting.Location = new System.Drawing.Point(536, 6);
            this.listBox_ListWaiting.Name = "listBox_ListWaiting";
            this.listBox_ListWaiting.Size = new System.Drawing.Size(250, 121);
            this.listBox_ListWaiting.TabIndex = 5;
            this.listBox_ListWaiting.SelectedIndexChanged += new System.EventHandler(this.listBox_ListWaiting_SelectedIndexChanged);
            // 
            // button_ConfigListLogic
            // 
            this.button_ConfigListLogic.Location = new System.Drawing.Point(6, 78);
            this.button_ConfigListLogic.Name = "button_ConfigListLogic";
            this.button_ConfigListLogic.Size = new System.Drawing.Size(250, 30);
            this.button_ConfigListLogic.TabIndex = 3;
            this.button_ConfigListLogic.Text = "Configure List Logic";
            this.button_ConfigListLogic.UseVisualStyleBackColor = true;
            // 
            // button_EditMainLists
            // 
            this.button_EditMainLists.Location = new System.Drawing.Point(6, 42);
            this.button_EditMainLists.Name = "button_EditMainLists";
            this.button_EditMainLists.Size = new System.Drawing.Size(250, 30);
            this.button_EditMainLists.TabIndex = 2;
            this.button_EditMainLists.Text = "Edit Main Lists";
            this.button_EditMainLists.UseVisualStyleBackColor = true;
            // 
            // button_EditLineage
            // 
            this.button_EditLineage.Location = new System.Drawing.Point(6, 6);
            this.button_EditLineage.Name = "button_EditLineage";
            this.button_EditLineage.Size = new System.Drawing.Size(250, 30);
            this.button_EditLineage.TabIndex = 1;
            this.button_EditLineage.Text = "Edit Lineage";
            this.button_EditLineage.UseVisualStyleBackColor = true;
            // 
            // tabPage_ConfigureCommands
            // 
            this.tabPage_ConfigureCommands.Controls.Add(this.button_ConfigCommandBehavior);
            this.tabPage_ConfigureCommands.Controls.Add(this.button_ConfigCommandAliases);
            this.tabPage_ConfigureCommands.Location = new System.Drawing.Point(4, 22);
            this.tabPage_ConfigureCommands.Name = "tabPage_ConfigureCommands";
            this.tabPage_ConfigureCommands.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage_ConfigureCommands.Size = new System.Drawing.Size(792, 424);
            this.tabPage_ConfigureCommands.TabIndex = 1;
            this.tabPage_ConfigureCommands.Text = "Configure Commands";
            this.tabPage_ConfigureCommands.UseVisualStyleBackColor = true;
            // 
            // button_ConfigCommandBehavior
            // 
            this.button_ConfigCommandBehavior.Location = new System.Drawing.Point(6, 52);
            this.button_ConfigCommandBehavior.Name = "button_ConfigCommandBehavior";
            this.button_ConfigCommandBehavior.Size = new System.Drawing.Size(200, 40);
            this.button_ConfigCommandBehavior.TabIndex = 2;
            this.button_ConfigCommandBehavior.Text = "Configure Command Behavior";
            this.button_ConfigCommandBehavior.UseVisualStyleBackColor = true;
            this.button_ConfigCommandBehavior.Click += new System.EventHandler(this.button_ConfigCommandBehavior_Click);
            // 
            // button_ConfigCommandAliases
            // 
            this.button_ConfigCommandAliases.Location = new System.Drawing.Point(6, 6);
            this.button_ConfigCommandAliases.Name = "button_ConfigCommandAliases";
            this.button_ConfigCommandAliases.Size = new System.Drawing.Size(200, 40);
            this.button_ConfigCommandAliases.TabIndex = 1;
            this.button_ConfigCommandAliases.Text = "Configure Command Aliases";
            this.button_ConfigCommandAliases.UseVisualStyleBackColor = true;
            this.button_ConfigCommandAliases.Click += new System.EventHandler(this.button_ConfigCommandAliases_Click);
            // 
            // tabPage_LocalSettings
            // 
            this.tabPage_LocalSettings.Controls.Add(this.button_ImportExportData);
            this.tabPage_LocalSettings.Controls.Add(this.button_ConfigCredentials);
            this.tabPage_LocalSettings.Controls.Add(this.button_ConfigHotkeys);
            this.tabPage_LocalSettings.Controls.Add(this.label1);
            this.tabPage_LocalSettings.Location = new System.Drawing.Point(4, 22);
            this.tabPage_LocalSettings.Name = "tabPage_LocalSettings";
            this.tabPage_LocalSettings.Size = new System.Drawing.Size(792, 424);
            this.tabPage_LocalSettings.TabIndex = 2;
            this.tabPage_LocalSettings.Text = "Local Settings";
            this.tabPage_LocalSettings.UseVisualStyleBackColor = true;
            // 
            // button_ImportExportData
            // 
            this.button_ImportExportData.Location = new System.Drawing.Point(6, 98);
            this.button_ImportExportData.Name = "button_ImportExportData";
            this.button_ImportExportData.Size = new System.Drawing.Size(200, 40);
            this.button_ImportExportData.TabIndex = 3;
            this.button_ImportExportData.Text = "Import / Export Data";
            this.button_ImportExportData.UseVisualStyleBackColor = true;
            // 
            // button_ConfigCredentials
            // 
            this.button_ConfigCredentials.Location = new System.Drawing.Point(6, 52);
            this.button_ConfigCredentials.Name = "button_ConfigCredentials";
            this.button_ConfigCredentials.Size = new System.Drawing.Size(200, 40);
            this.button_ConfigCredentials.TabIndex = 2;
            this.button_ConfigCredentials.Text = "Configure Twitch Credentials";
            this.button_ConfigCredentials.UseVisualStyleBackColor = true;
            // 
            // button_ConfigHotkeys
            // 
            this.button_ConfigHotkeys.Location = new System.Drawing.Point(6, 6);
            this.button_ConfigHotkeys.Name = "button_ConfigHotkeys";
            this.button_ConfigHotkeys.Size = new System.Drawing.Size(200, 40);
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
            this.tabPage_Debug.Controls.Add(this.button_ForceUpdate);
            this.tabPage_Debug.Controls.Add(this.button_ForceReconnect);
            this.tabPage_Debug.Controls.Add(this.checkBox_doVerboseLogging);
            this.tabPage_Debug.Controls.Add(this.label_VersionInfo);
            this.tabPage_Debug.Controls.Add(this.richTextBox_ConsoleDebugLog);
            this.tabPage_Debug.Location = new System.Drawing.Point(4, 22);
            this.tabPage_Debug.Name = "tabPage_Debug";
            this.tabPage_Debug.Size = new System.Drawing.Size(792, 424);
            this.tabPage_Debug.TabIndex = 3;
            this.tabPage_Debug.Text = "Debug";
            this.tabPage_Debug.UseVisualStyleBackColor = true;
            // 
            // button_ForceReconnect
            // 
            this.button_ForceReconnect.Anchor = ((System.Windows.Forms.AnchorStyles) ((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.button_ForceReconnect.Location = new System.Drawing.Point(686, 29);
            this.button_ForceReconnect.Margin = new System.Windows.Forms.Padding(3, 3, 6, 3);
            this.button_ForceReconnect.Name = "button_ForceReconnect";
            this.button_ForceReconnect.Size = new System.Drawing.Size(100, 20);
            this.button_ForceReconnect.TabIndex = 5;
            this.button_ForceReconnect.Text = "Force Reconnect";
            this.button_ForceReconnect.UseVisualStyleBackColor = true;
            this.button_ForceReconnect.Click += new System.EventHandler(this.button_ForceReconnect_Click);
            // 
            // checkBox_doVerboseLogging
            // 
            this.checkBox_doVerboseLogging.Location = new System.Drawing.Point(8, 29);
            this.checkBox_doVerboseLogging.Name = "checkBox_doVerboseLogging";
            this.checkBox_doVerboseLogging.Size = new System.Drawing.Size(100, 20);
            this.checkBox_doVerboseLogging.TabIndex = 4;
            this.checkBox_doVerboseLogging.Text = "Verbose Log";
            this.checkBox_doVerboseLogging.UseVisualStyleBackColor = true;
            this.checkBox_doVerboseLogging.CheckedChanged += new System.EventHandler(this.checkBox_doVerboseLogging_CheckedChanged);
            // 
            // label_VersionInfo
            // 
            this.label_VersionInfo.Anchor = ((System.Windows.Forms.AnchorStyles) (((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) | System.Windows.Forms.AnchorStyles.Right)));
            this.label_VersionInfo.Location = new System.Drawing.Point(3, 3);
            this.label_VersionInfo.Margin = new System.Windows.Forms.Padding(3);
            this.label_VersionInfo.Name = "label_VersionInfo";
            this.label_VersionInfo.Size = new System.Drawing.Size(786, 20);
            this.label_VersionInfo.TabIndex = 3;
            this.label_VersionInfo.Text = "Version 2.16 Beta || https://github.com/corptact/PagTool || Do Not Distribute || " + "Corporate Tactics 2021";
            this.label_VersionInfo.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // richTextBox_ConsoleDebugLog
            // 
            this.richTextBox_ConsoleDebugLog.Location = new System.Drawing.Point(6, 55);
            this.richTextBox_ConsoleDebugLog.Margin = new System.Windows.Forms.Padding(3, 3, 3, 6);
            this.richTextBox_ConsoleDebugLog.Name = "richTextBox_ConsoleDebugLog";
            this.richTextBox_ConsoleDebugLog.Size = new System.Drawing.Size(780, 363);
            this.richTextBox_ConsoleDebugLog.TabIndex = 2;
            this.richTextBox_ConsoleDebugLog.Text = "";
            // 
            // button_ForceUpdate
            // 
            this.button_ForceUpdate.Anchor = ((System.Windows.Forms.AnchorStyles) ((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.button_ForceUpdate.Location = new System.Drawing.Point(577, 29);
            this.button_ForceUpdate.Margin = new System.Windows.Forms.Padding(3, 3, 6, 3);
            this.button_ForceUpdate.Name = "button_ForceUpdate";
            this.button_ForceUpdate.Size = new System.Drawing.Size(100, 20);
            this.button_ForceUpdate.TabIndex = 6;
            this.button_ForceUpdate.Text = "Refresh Visuals";
            this.button_ForceUpdate.UseVisualStyleBackColor = true;
            this.button_ForceUpdate.Click += new System.EventHandler(this.button_ForceUpdate_Click);
            // 
            // FormMain
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size(797, 448);
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
        private System.Windows.Forms.Button button_ForceUpdate;
        private System.Windows.Forms.Button button_ImportExportData;
        private System.Windows.Forms.Button button_ListActive_Add;
        private System.Windows.Forms.Button button_ListActive_MoveToDead;
        private System.Windows.Forms.Button button_ListActive_MoveToWaiting;
        private System.Windows.Forms.Button button_ListActive_Remove;
        private System.Windows.Forms.Button button_ListDead_Add;
        private System.Windows.Forms.Button button_ListDead_MoveToActive;
        private System.Windows.Forms.Button button_ListDead_MoveToWaiting;
        private System.Windows.Forms.Button button_ListDead_Remove;
        private System.Windows.Forms.Button button_ListWaiting_Add;
        private System.Windows.Forms.Button button_ListWaiting_MoveToActive;
        private System.Windows.Forms.Button button_ListWaiting_MoveToDead;
        private System.Windows.Forms.Button button_ListWaiting_Remove;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.CheckBox checkBox_doVerboseLogging;
        private System.Windows.Forms.Label label_VersionInfo;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ListBox listBox_CurrentLineage;
        private System.Windows.Forms.ListBox listBox_ListActive;
        private System.Windows.Forms.ListBox listBox_ListDead;
        private System.Windows.Forms.ListBox listBox_ListWaiting;
        private System.Windows.Forms.RichTextBox richTextBox_ConsoleDebugLog;
        private System.Windows.Forms.RichTextBox richTextBox_SelectedUserDisplay;
        private System.Windows.Forms.TabControl tabControl;
        private System.Windows.Forms.TabPage tabPage_ConfigureCommands;
        private System.Windows.Forms.TabPage tabPage_Debug;
        private System.Windows.Forms.TabPage tabPage_LocalSettings;
        private System.Windows.Forms.TabPage tabPage_ModifyData;
        private System.Windows.Forms.Label verticalDivider2;

        #endregion
    }
}