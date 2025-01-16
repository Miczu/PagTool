using System.ComponentModel;

namespace PagTool
{
    partial class ConfigCommandBehaviorDialog
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
            this.buttonOK = new System.Windows.Forms.Button();
            this.buttonCancel = new System.Windows.Forms.Button();
            this.labelCmdAddName = new System.Windows.Forms.Label();
            this.textBox_ResponseCmdAddName = new System.Windows.Forms.TextBox();
            this.label_FormatStringsSupported = new System.Windows.Forms.Label();
            this.textBox_ResponseCmdCheckStatus = new System.Windows.Forms.TextBox();
            this.labelCmdCheckStatus = new System.Windows.Forms.Label();
            this.labelCmdNameAlreadyExists = new System.Windows.Forms.Label();
            this.textBox_ResponseCmdNameAlreadyExists = new System.Windows.Forms.TextBox();
            this.labelCmdUserDrawn = new System.Windows.Forms.Label();
            this.textBox_ResponseCmdUserDrawn = new System.Windows.Forms.TextBox();
            this.labelCmdBlacklistTriggered = new System.Windows.Forms.Label();
            this.textBox_ResponseCmdBlacklistTriggered = new System.Windows.Forms.TextBox();
            this.labelCmdWaitlistEmpty = new System.Windows.Forms.Label();
            this.textBox_ResponseCmdWaitlistEmpty = new System.Windows.Forms.TextBox();
            this.labelCmdChatReconnect = new System.Windows.Forms.Label();
            this.textBox_ResponseCmdChatReconnect = new System.Windows.Forms.TextBox();
            this.textBox_ChatReminder = new System.Windows.Forms.TextBox();
            this.label_ChatReminder = new System.Windows.Forms.Label();
            this.numericUpDown_ChatReminderSeconds = new System.Windows.Forms.NumericUpDown();
            this.label_ChatReminderTimer = new System.Windows.Forms.Label();
            this.label_ChatReminderSeconds = new System.Windows.Forms.Label();
            this.textBox_ResponseCmdMoveToDead = new System.Windows.Forms.TextBox();
            this.labelCmdMoveToDead = new System.Windows.Forms.Label();
            this.textBox_ResponseCmdHelp = new System.Windows.Forms.TextBox();
            this.labelCmdHelp = new System.Windows.Forms.Label();
            this.textBox_ResponseCmdCannotDie = new System.Windows.Forms.TextBox();
            this.label_CmdCannotDie = new System.Windows.Forms.Label();
            this.textBox_ResponseCmdAutoShuffledDead = new System.Windows.Forms.TextBox();
            this.label_CmdAutoShuffledDead = new System.Windows.Forms.Label();
            this.textBox_ResponseCmdAutoShuffleNoDead = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_ChatReminderSeconds)).BeginInit();
            this.SuspendLayout();
            // 
            // buttonOK
            // 
            this.buttonOK.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.buttonOK.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.buttonOK.Location = new System.Drawing.Point(12, 384);
            this.buttonOK.Name = "buttonOK";
            this.buttonOK.Size = new System.Drawing.Size(199, 40);
            this.buttonOK.TabIndex = 0;
            this.buttonOK.Text = "OK";
            this.buttonOK.UseVisualStyleBackColor = true;
            // 
            // buttonCancel
            // 
            this.buttonCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.buttonCancel.Location = new System.Drawing.Point(252, 384);
            this.buttonCancel.Name = "buttonCancel";
            this.buttonCancel.Size = new System.Drawing.Size(199, 40);
            this.buttonCancel.TabIndex = 1;
            this.buttonCancel.Text = "Cancel";
            this.buttonCancel.UseVisualStyleBackColor = true;
            // 
            // labelCmdAddName
            // 
            this.labelCmdAddName.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.labelCmdAddName.Location = new System.Drawing.Point(12, 361);
            this.labelCmdAddName.Name = "labelCmdAddName";
            this.labelCmdAddName.Size = new System.Drawing.Size(58, 20);
            this.labelCmdAddName.TabIndex = 2;
            this.labelCmdAddName.Text = "Add Name";
            this.labelCmdAddName.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // textBox_ResponseCmdAddName
            // 
            this.textBox_ResponseCmdAddName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBox_ResponseCmdAddName.Location = new System.Drawing.Point(129, 362);
            this.textBox_ResponseCmdAddName.Name = "textBox_ResponseCmdAddName";
            this.textBox_ResponseCmdAddName.Size = new System.Drawing.Size(321, 20);
            this.textBox_ResponseCmdAddName.TabIndex = 3;
            // 
            // label_FormatStringsSupported
            // 
            this.label_FormatStringsSupported.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label_FormatStringsSupported.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_FormatStringsSupported.Location = new System.Drawing.Point(12, 118);
            this.label_FormatStringsSupported.Name = "label_FormatStringsSupported";
            this.label_FormatStringsSupported.Size = new System.Drawing.Size(340, 20);
            this.label_FormatStringsSupported.TabIndex = 4;
            this.label_FormatStringsSupported.Text = "Format Strings Supported: (click here for help!)";
            this.label_FormatStringsSupported.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.label_FormatStringsSupported.Click += new System.EventHandler(this.label_FormatStringsSupported_Click);
            // 
            // textBox_ResponseCmdCheckStatus
            // 
            this.textBox_ResponseCmdCheckStatus.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBox_ResponseCmdCheckStatus.Location = new System.Drawing.Point(129, 340);
            this.textBox_ResponseCmdCheckStatus.Name = "textBox_ResponseCmdCheckStatus";
            this.textBox_ResponseCmdCheckStatus.Size = new System.Drawing.Size(321, 20);
            this.textBox_ResponseCmdCheckStatus.TabIndex = 6;
            // 
            // labelCmdCheckStatus
            // 
            this.labelCmdCheckStatus.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.labelCmdCheckStatus.Location = new System.Drawing.Point(12, 340);
            this.labelCmdCheckStatus.Name = "labelCmdCheckStatus";
            this.labelCmdCheckStatus.Size = new System.Drawing.Size(72, 20);
            this.labelCmdCheckStatus.TabIndex = 5;
            this.labelCmdCheckStatus.Text = "Check Status";
            this.labelCmdCheckStatus.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // labelCmdNameAlreadyExists
            // 
            this.labelCmdNameAlreadyExists.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.labelCmdNameAlreadyExists.Location = new System.Drawing.Point(12, 317);
            this.labelCmdNameAlreadyExists.Name = "labelCmdNameAlreadyExists";
            this.labelCmdNameAlreadyExists.Size = new System.Drawing.Size(104, 20);
            this.labelCmdNameAlreadyExists.TabIndex = 5;
            this.labelCmdNameAlreadyExists.Text = "Name Already Exists";
            this.labelCmdNameAlreadyExists.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // textBox_ResponseCmdNameAlreadyExists
            // 
            this.textBox_ResponseCmdNameAlreadyExists.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBox_ResponseCmdNameAlreadyExists.Location = new System.Drawing.Point(129, 317);
            this.textBox_ResponseCmdNameAlreadyExists.Name = "textBox_ResponseCmdNameAlreadyExists";
            this.textBox_ResponseCmdNameAlreadyExists.Size = new System.Drawing.Size(321, 20);
            this.textBox_ResponseCmdNameAlreadyExists.TabIndex = 6;
            // 
            // labelCmdUserDrawn
            // 
            this.labelCmdUserDrawn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.labelCmdUserDrawn.Location = new System.Drawing.Point(12, 294);
            this.labelCmdUserDrawn.Name = "labelCmdUserDrawn";
            this.labelCmdUserDrawn.Size = new System.Drawing.Size(104, 20);
            this.labelCmdUserDrawn.TabIndex = 5;
            this.labelCmdUserDrawn.Text = "User Drawn";
            this.labelCmdUserDrawn.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // textBox_ResponseCmdUserDrawn
            // 
            this.textBox_ResponseCmdUserDrawn.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBox_ResponseCmdUserDrawn.Location = new System.Drawing.Point(129, 294);
            this.textBox_ResponseCmdUserDrawn.Name = "textBox_ResponseCmdUserDrawn";
            this.textBox_ResponseCmdUserDrawn.Size = new System.Drawing.Size(321, 20);
            this.textBox_ResponseCmdUserDrawn.TabIndex = 6;
            // 
            // labelCmdBlacklistTriggered
            // 
            this.labelCmdBlacklistTriggered.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.labelCmdBlacklistTriggered.Location = new System.Drawing.Point(12, 271);
            this.labelCmdBlacklistTriggered.Name = "labelCmdBlacklistTriggered";
            this.labelCmdBlacklistTriggered.Size = new System.Drawing.Size(104, 20);
            this.labelCmdBlacklistTriggered.TabIndex = 5;
            this.labelCmdBlacklistTriggered.Text = "Blacklist Triggered";
            this.labelCmdBlacklistTriggered.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // textBox_ResponseCmdBlacklistTriggered
            // 
            this.textBox_ResponseCmdBlacklistTriggered.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBox_ResponseCmdBlacklistTriggered.Location = new System.Drawing.Point(129, 271);
            this.textBox_ResponseCmdBlacklistTriggered.Name = "textBox_ResponseCmdBlacklistTriggered";
            this.textBox_ResponseCmdBlacklistTriggered.Size = new System.Drawing.Size(321, 20);
            this.textBox_ResponseCmdBlacklistTriggered.TabIndex = 6;
            // 
            // labelCmdWaitlistEmpty
            // 
            this.labelCmdWaitlistEmpty.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.labelCmdWaitlistEmpty.Location = new System.Drawing.Point(12, 56);
            this.labelCmdWaitlistEmpty.Name = "labelCmdWaitlistEmpty";
            this.labelCmdWaitlistEmpty.Size = new System.Drawing.Size(104, 20);
            this.labelCmdWaitlistEmpty.TabIndex = 5;
            this.labelCmdWaitlistEmpty.Text = "Waitlist Empty";
            this.labelCmdWaitlistEmpty.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // textBox_ResponseCmdWaitlistEmpty
            // 
            this.textBox_ResponseCmdWaitlistEmpty.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBox_ResponseCmdWaitlistEmpty.Location = new System.Drawing.Point(129, 56);
            this.textBox_ResponseCmdWaitlistEmpty.Name = "textBox_ResponseCmdWaitlistEmpty";
            this.textBox_ResponseCmdWaitlistEmpty.Size = new System.Drawing.Size(321, 20);
            this.textBox_ResponseCmdWaitlistEmpty.TabIndex = 6;
            // 
            // labelCmdChatReconnect
            // 
            this.labelCmdChatReconnect.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.labelCmdChatReconnect.Location = new System.Drawing.Point(12, 78);
            this.labelCmdChatReconnect.Name = "labelCmdChatReconnect";
            this.labelCmdChatReconnect.Size = new System.Drawing.Size(104, 20);
            this.labelCmdChatReconnect.TabIndex = 5;
            this.labelCmdChatReconnect.Text = "Chat Reconnect";
            this.labelCmdChatReconnect.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // textBox_ResponseCmdChatReconnect
            // 
            this.textBox_ResponseCmdChatReconnect.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBox_ResponseCmdChatReconnect.Location = new System.Drawing.Point(129, 79);
            this.textBox_ResponseCmdChatReconnect.Name = "textBox_ResponseCmdChatReconnect";
            this.textBox_ResponseCmdChatReconnect.Size = new System.Drawing.Size(321, 20);
            this.textBox_ResponseCmdChatReconnect.TabIndex = 6;
            // 
            // textBox_ChatReminder
            // 
            this.textBox_ChatReminder.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBox_ChatReminder.Location = new System.Drawing.Point(129, 33);
            this.textBox_ChatReminder.Name = "textBox_ChatReminder";
            this.textBox_ChatReminder.Size = new System.Drawing.Size(321, 20);
            this.textBox_ChatReminder.TabIndex = 8;
            // 
            // label_ChatReminder
            // 
            this.label_ChatReminder.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label_ChatReminder.Location = new System.Drawing.Point(12, 33);
            this.label_ChatReminder.Name = "label_ChatReminder";
            this.label_ChatReminder.Size = new System.Drawing.Size(104, 20);
            this.label_ChatReminder.TabIndex = 7;
            this.label_ChatReminder.Text = "Chat Reminder";
            this.label_ChatReminder.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // numericUpDown_ChatReminderSeconds
            // 
            this.numericUpDown_ChatReminderSeconds.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.numericUpDown_ChatReminderSeconds.Location = new System.Drawing.Point(161, 10);
            this.numericUpDown_ChatReminderSeconds.Maximum = new decimal(new int[] {
            3600,
            0,
            0,
            0});
            this.numericUpDown_ChatReminderSeconds.Minimum = new decimal(new int[] {
            60,
            0,
            0,
            0});
            this.numericUpDown_ChatReminderSeconds.Name = "numericUpDown_ChatReminderSeconds";
            this.numericUpDown_ChatReminderSeconds.Size = new System.Drawing.Size(118, 20);
            this.numericUpDown_ChatReminderSeconds.TabIndex = 9;
            this.numericUpDown_ChatReminderSeconds.Value = new decimal(new int[] {
            60,
            0,
            0,
            0});
            // 
            // label_ChatReminderTimer
            // 
            this.label_ChatReminderTimer.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label_ChatReminderTimer.Location = new System.Drawing.Point(12, 10);
            this.label_ChatReminderTimer.Name = "label_ChatReminderTimer";
            this.label_ChatReminderTimer.Size = new System.Drawing.Size(143, 20);
            this.label_ChatReminderTimer.TabIndex = 10;
            this.label_ChatReminderTimer.Text = "Chat Reminder Time Interval";
            this.label_ChatReminderTimer.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label_ChatReminderSeconds
            // 
            this.label_ChatReminderSeconds.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label_ChatReminderSeconds.Location = new System.Drawing.Point(255, 10);
            this.label_ChatReminderSeconds.Name = "label_ChatReminderSeconds";
            this.label_ChatReminderSeconds.Size = new System.Drawing.Size(143, 20);
            this.label_ChatReminderSeconds.TabIndex = 11;
            this.label_ChatReminderSeconds.Text = "seconds";
            this.label_ChatReminderSeconds.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // textBox_ResponseCmdMoveToDead
            // 
            this.textBox_ResponseCmdMoveToDead.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBox_ResponseCmdMoveToDead.Location = new System.Drawing.Point(129, 248);
            this.textBox_ResponseCmdMoveToDead.Name = "textBox_ResponseCmdMoveToDead";
            this.textBox_ResponseCmdMoveToDead.Size = new System.Drawing.Size(321, 20);
            this.textBox_ResponseCmdMoveToDead.TabIndex = 13;
            // 
            // labelCmdMoveToDead
            // 
            this.labelCmdMoveToDead.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.labelCmdMoveToDead.Location = new System.Drawing.Point(12, 248);
            this.labelCmdMoveToDead.Name = "labelCmdMoveToDead";
            this.labelCmdMoveToDead.Size = new System.Drawing.Size(104, 20);
            this.labelCmdMoveToDead.TabIndex = 12;
            this.labelCmdMoveToDead.Text = "Move To Dead";
            this.labelCmdMoveToDead.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // textBox_ResponseCmdHelp
            // 
            this.textBox_ResponseCmdHelp.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBox_ResponseCmdHelp.Location = new System.Drawing.Point(129, 202);
            this.textBox_ResponseCmdHelp.Name = "textBox_ResponseCmdHelp";
            this.textBox_ResponseCmdHelp.Size = new System.Drawing.Size(321, 20);
            this.textBox_ResponseCmdHelp.TabIndex = 15;
            // 
            // labelCmdHelp
            // 
            this.labelCmdHelp.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.labelCmdHelp.Location = new System.Drawing.Point(12, 202);
            this.labelCmdHelp.Name = "labelCmdHelp";
            this.labelCmdHelp.Size = new System.Drawing.Size(104, 20);
            this.labelCmdHelp.TabIndex = 14;
            this.labelCmdHelp.Text = "Show Help";
            this.labelCmdHelp.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // textBox_ResponseCmdCannotDie
            // 
            this.textBox_ResponseCmdCannotDie.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBox_ResponseCmdCannotDie.Location = new System.Drawing.Point(129, 225);
            this.textBox_ResponseCmdCannotDie.Name = "textBox_ResponseCmdCannotDie";
            this.textBox_ResponseCmdCannotDie.Size = new System.Drawing.Size(321, 20);
            this.textBox_ResponseCmdCannotDie.TabIndex = 17;
            // 
            // label_CmdCannotDie
            // 
            this.label_CmdCannotDie.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label_CmdCannotDie.Location = new System.Drawing.Point(12, 225);
            this.label_CmdCannotDie.Name = "label_CmdCannotDie";
            this.label_CmdCannotDie.Size = new System.Drawing.Size(104, 20);
            this.label_CmdCannotDie.TabIndex = 16;
            this.label_CmdCannotDie.Text = "User Cannot Die";
            this.label_CmdCannotDie.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // textBox_ResponseCmdAutoShuffledDead
            // 
            this.textBox_ResponseCmdAutoShuffledDead.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBox_ResponseCmdAutoShuffledDead.Location = new System.Drawing.Point(129, 156);
            this.textBox_ResponseCmdAutoShuffledDead.Name = "textBox_ResponseCmdAutoShuffledDead";
            this.textBox_ResponseCmdAutoShuffledDead.Size = new System.Drawing.Size(321, 20);
            this.textBox_ResponseCmdAutoShuffledDead.TabIndex = 19;
            // 
            // label_CmdAutoShuffledDead
            // 
            this.label_CmdAutoShuffledDead.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label_CmdAutoShuffledDead.Location = new System.Drawing.Point(12, 156);
            this.label_CmdAutoShuffledDead.Name = "label_CmdAutoShuffledDead";
            this.label_CmdAutoShuffledDead.Size = new System.Drawing.Size(104, 20);
            this.label_CmdAutoShuffledDead.TabIndex = 18;
            this.label_CmdAutoShuffledDead.Text = "Auto-Shuffled Dead";
            this.label_CmdAutoShuffledDead.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // textBox_ResponseCmdAutoShuffleNoDead
            // 
            this.textBox_ResponseCmdAutoShuffleNoDead.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBox_ResponseCmdAutoShuffleNoDead.Location = new System.Drawing.Point(129, 179);
            this.textBox_ResponseCmdAutoShuffleNoDead.Name = "textBox_ResponseCmdAutoShuffleNoDead";
            this.textBox_ResponseCmdAutoShuffleNoDead.Size = new System.Drawing.Size(321, 20);
            this.textBox_ResponseCmdAutoShuffleNoDead.TabIndex = 21;
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label1.Location = new System.Drawing.Point(12, 179);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(119, 20);
            this.label1.TabIndex = 20;
            this.label1.Text = "Auto-Shuffled No-Dead";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // ConfigCommandBehaviorDialog
            // 
            this.AcceptButton = this.buttonOK;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.buttonCancel;
            this.ClientSize = new System.Drawing.Size(463, 436);
            this.Controls.Add(this.textBox_ResponseCmdAutoShuffleNoDead);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.textBox_ResponseCmdAutoShuffledDead);
            this.Controls.Add(this.label_CmdAutoShuffledDead);
            this.Controls.Add(this.textBox_ResponseCmdCannotDie);
            this.Controls.Add(this.label_CmdCannotDie);
            this.Controls.Add(this.textBox_ResponseCmdHelp);
            this.Controls.Add(this.labelCmdHelp);
            this.Controls.Add(this.textBox_ResponseCmdMoveToDead);
            this.Controls.Add(this.labelCmdMoveToDead);
            this.Controls.Add(this.label_ChatReminderSeconds);
            this.Controls.Add(this.label_ChatReminderTimer);
            this.Controls.Add(this.numericUpDown_ChatReminderSeconds);
            this.Controls.Add(this.textBox_ChatReminder);
            this.Controls.Add(this.label_ChatReminder);
            this.Controls.Add(this.textBox_ResponseCmdChatReconnect);
            this.Controls.Add(this.textBox_ResponseCmdWaitlistEmpty);
            this.Controls.Add(this.textBox_ResponseCmdBlacklistTriggered);
            this.Controls.Add(this.textBox_ResponseCmdUserDrawn);
            this.Controls.Add(this.textBox_ResponseCmdNameAlreadyExists);
            this.Controls.Add(this.textBox_ResponseCmdCheckStatus);
            this.Controls.Add(this.labelCmdChatReconnect);
            this.Controls.Add(this.labelCmdWaitlistEmpty);
            this.Controls.Add(this.labelCmdBlacklistTriggered);
            this.Controls.Add(this.labelCmdUserDrawn);
            this.Controls.Add(this.labelCmdNameAlreadyExists);
            this.Controls.Add(this.labelCmdCheckStatus);
            this.Controls.Add(this.label_FormatStringsSupported);
            this.Controls.Add(this.textBox_ResponseCmdAddName);
            this.Controls.Add(this.labelCmdAddName);
            this.Controls.Add(this.buttonCancel);
            this.Controls.Add(this.buttonOK);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Name = "ConfigCommandBehaviorDialog";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "ConfigCommandBehaviorDialog";
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_ChatReminderSeconds)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        private System.Windows.Forms.Button buttonCancel;
        private System.Windows.Forms.Button buttonOK;
        private System.Windows.Forms.Label label_ChatReminder;
        private System.Windows.Forms.Label label_ChatReminderSeconds;
        private System.Windows.Forms.Label label_ChatReminderTimer;
        private System.Windows.Forms.Label label_CmdAutoShuffledDead;
        private System.Windows.Forms.Label label_CmdCannotDie;
        private System.Windows.Forms.Label label_FormatStringsSupported;
        private System.Windows.Forms.Label labelCmdAddName;
        private System.Windows.Forms.Label labelCmdBlacklistTriggered;
        private System.Windows.Forms.Label labelCmdChatReconnect;
        private System.Windows.Forms.Label labelCmdCheckStatus;
        private System.Windows.Forms.Label labelCmdHelp;
        private System.Windows.Forms.Label labelCmdMoveToDead;
        private System.Windows.Forms.Label labelCmdNameAlreadyExists;
        private System.Windows.Forms.Label labelCmdUserDrawn;
        private System.Windows.Forms.Label labelCmdWaitlistEmpty;
        private System.Windows.Forms.NumericUpDown numericUpDown_ChatReminderSeconds;
        private System.Windows.Forms.TextBox textBox_ChatReminder;
        private System.Windows.Forms.TextBox textBox_ResponseCmdAddName;
        private System.Windows.Forms.TextBox textBox_ResponseCmdAutoShuffledDead;
        private System.Windows.Forms.TextBox textBox_ResponseCmdBlacklistTriggered;
        private System.Windows.Forms.TextBox textBox_ResponseCmdCannotDie;
        private System.Windows.Forms.TextBox textBox_ResponseCmdChatReconnect;
        private System.Windows.Forms.TextBox textBox_ResponseCmdCheckStatus;
        private System.Windows.Forms.TextBox textBox_ResponseCmdHelp;
        private System.Windows.Forms.TextBox textBox_ResponseCmdMoveToDead;
        private System.Windows.Forms.TextBox textBox_ResponseCmdNameAlreadyExists;
        private System.Windows.Forms.TextBox textBox_ResponseCmdUserDrawn;
        private System.Windows.Forms.TextBox textBox_ResponseCmdWaitlistEmpty;

        #endregion

        private System.Windows.Forms.TextBox textBox_ResponseCmdAutoShuffleNoDead;
        private System.Windows.Forms.Label label1;
    }
}