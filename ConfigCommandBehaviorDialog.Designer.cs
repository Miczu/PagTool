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
            this.SuspendLayout();
            // 
            // buttonOK
            // 
            this.buttonOK.Anchor = ((System.Windows.Forms.AnchorStyles) ((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.buttonOK.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.buttonOK.Location = new System.Drawing.Point(12, 363);
            this.buttonOK.Name = "buttonOK";
            this.buttonOK.Size = new System.Drawing.Size(199, 40);
            this.buttonOK.TabIndex = 0;
            this.buttonOK.Text = "OK";
            this.buttonOK.UseVisualStyleBackColor = true;
            // 
            // buttonCancel
            // 
            this.buttonCancel.Anchor = ((System.Windows.Forms.AnchorStyles) ((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.buttonCancel.Location = new System.Drawing.Point(222, 363);
            this.buttonCancel.Name = "buttonCancel";
            this.buttonCancel.Size = new System.Drawing.Size(199, 40);
            this.buttonCancel.TabIndex = 1;
            this.buttonCancel.Text = "Cancel";
            this.buttonCancel.UseVisualStyleBackColor = true;
            // 
            // labelCmdAddName
            // 
            this.labelCmdAddName.Anchor = ((System.Windows.Forms.AnchorStyles) ((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.labelCmdAddName.Location = new System.Drawing.Point(12, 340);
            this.labelCmdAddName.Name = "labelCmdAddName";
            this.labelCmdAddName.Size = new System.Drawing.Size(58, 20);
            this.labelCmdAddName.TabIndex = 2;
            this.labelCmdAddName.Text = "Add Name";
            this.labelCmdAddName.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // textBox_ResponseCmdAddName
            // 
            this.textBox_ResponseCmdAddName.Anchor = ((System.Windows.Forms.AnchorStyles) (((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) | System.Windows.Forms.AnchorStyles.Right)));
            this.textBox_ResponseCmdAddName.Location = new System.Drawing.Point(113, 341);
            this.textBox_ResponseCmdAddName.Name = "textBox_ResponseCmdAddName";
            this.textBox_ResponseCmdAddName.Size = new System.Drawing.Size(307, 20);
            this.textBox_ResponseCmdAddName.TabIndex = 3;
            // 
            // label_FormatStringsSupported
            // 
            this.label_FormatStringsSupported.Anchor = ((System.Windows.Forms.AnchorStyles) ((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label_FormatStringsSupported.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte) (0)));
            this.label_FormatStringsSupported.Location = new System.Drawing.Point(12, 227);
            this.label_FormatStringsSupported.Name = "label_FormatStringsSupported";
            this.label_FormatStringsSupported.Size = new System.Drawing.Size(129, 20);
            this.label_FormatStringsSupported.TabIndex = 4;
            this.label_FormatStringsSupported.Text = "Format Strings Supported:";
            this.label_FormatStringsSupported.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.label_FormatStringsSupported.Click += new System.EventHandler(this.label_FormatStringsSupported_Click);
            // 
            // textBox_ResponseCmdCheckStatus
            // 
            this.textBox_ResponseCmdCheckStatus.Anchor = ((System.Windows.Forms.AnchorStyles) (((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) | System.Windows.Forms.AnchorStyles.Right)));
            this.textBox_ResponseCmdCheckStatus.Location = new System.Drawing.Point(113, 319);
            this.textBox_ResponseCmdCheckStatus.Name = "textBox_ResponseCmdCheckStatus";
            this.textBox_ResponseCmdCheckStatus.Size = new System.Drawing.Size(307, 20);
            this.textBox_ResponseCmdCheckStatus.TabIndex = 6;
            // 
            // labelCmdCheckStatus
            // 
            this.labelCmdCheckStatus.Anchor = ((System.Windows.Forms.AnchorStyles) ((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.labelCmdCheckStatus.Location = new System.Drawing.Point(12, 319);
            this.labelCmdCheckStatus.Name = "labelCmdCheckStatus";
            this.labelCmdCheckStatus.Size = new System.Drawing.Size(72, 20);
            this.labelCmdCheckStatus.TabIndex = 5;
            this.labelCmdCheckStatus.Text = "Check Status";
            this.labelCmdCheckStatus.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // labelCmdNameAlreadyExists
            // 
            this.labelCmdNameAlreadyExists.Anchor = ((System.Windows.Forms.AnchorStyles) ((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.labelCmdNameAlreadyExists.Location = new System.Drawing.Point(12, 296);
            this.labelCmdNameAlreadyExists.Name = "labelCmdNameAlreadyExists";
            this.labelCmdNameAlreadyExists.Size = new System.Drawing.Size(104, 20);
            this.labelCmdNameAlreadyExists.TabIndex = 5;
            this.labelCmdNameAlreadyExists.Text = "Name Already Exists";
            this.labelCmdNameAlreadyExists.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // textBox_ResponseCmdNameAlreadyExists
            // 
            this.textBox_ResponseCmdNameAlreadyExists.Anchor = ((System.Windows.Forms.AnchorStyles) (((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) | System.Windows.Forms.AnchorStyles.Right)));
            this.textBox_ResponseCmdNameAlreadyExists.Location = new System.Drawing.Point(113, 296);
            this.textBox_ResponseCmdNameAlreadyExists.Name = "textBox_ResponseCmdNameAlreadyExists";
            this.textBox_ResponseCmdNameAlreadyExists.Size = new System.Drawing.Size(307, 20);
            this.textBox_ResponseCmdNameAlreadyExists.TabIndex = 6;
            // 
            // labelCmdUserDrawn
            // 
            this.labelCmdUserDrawn.Anchor = ((System.Windows.Forms.AnchorStyles) ((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.labelCmdUserDrawn.Location = new System.Drawing.Point(12, 273);
            this.labelCmdUserDrawn.Name = "labelCmdUserDrawn";
            this.labelCmdUserDrawn.Size = new System.Drawing.Size(104, 20);
            this.labelCmdUserDrawn.TabIndex = 5;
            this.labelCmdUserDrawn.Text = "User Drawn";
            this.labelCmdUserDrawn.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // textBox_ResponseCmdUserDrawn
            // 
            this.textBox_ResponseCmdUserDrawn.Anchor = ((System.Windows.Forms.AnchorStyles) (((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) | System.Windows.Forms.AnchorStyles.Right)));
            this.textBox_ResponseCmdUserDrawn.Location = new System.Drawing.Point(113, 273);
            this.textBox_ResponseCmdUserDrawn.Name = "textBox_ResponseCmdUserDrawn";
            this.textBox_ResponseCmdUserDrawn.Size = new System.Drawing.Size(307, 20);
            this.textBox_ResponseCmdUserDrawn.TabIndex = 6;
            // 
            // labelCmdBlacklistTriggered
            // 
            this.labelCmdBlacklistTriggered.Anchor = ((System.Windows.Forms.AnchorStyles) ((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.labelCmdBlacklistTriggered.Location = new System.Drawing.Point(12, 250);
            this.labelCmdBlacklistTriggered.Name = "labelCmdBlacklistTriggered";
            this.labelCmdBlacklistTriggered.Size = new System.Drawing.Size(104, 20);
            this.labelCmdBlacklistTriggered.TabIndex = 5;
            this.labelCmdBlacklistTriggered.Text = "Blacklist Triggered";
            this.labelCmdBlacklistTriggered.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // textBox_ResponseCmdBlacklistTriggered
            // 
            this.textBox_ResponseCmdBlacklistTriggered.Anchor = ((System.Windows.Forms.AnchorStyles) (((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) | System.Windows.Forms.AnchorStyles.Right)));
            this.textBox_ResponseCmdBlacklistTriggered.Location = new System.Drawing.Point(113, 250);
            this.textBox_ResponseCmdBlacklistTriggered.Name = "textBox_ResponseCmdBlacklistTriggered";
            this.textBox_ResponseCmdBlacklistTriggered.Size = new System.Drawing.Size(307, 20);
            this.textBox_ResponseCmdBlacklistTriggered.TabIndex = 6;
            // 
            // labelCmdWaitlistEmpty
            // 
            this.labelCmdWaitlistEmpty.Anchor = ((System.Windows.Forms.AnchorStyles) ((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.labelCmdWaitlistEmpty.Location = new System.Drawing.Point(12, 184);
            this.labelCmdWaitlistEmpty.Name = "labelCmdWaitlistEmpty";
            this.labelCmdWaitlistEmpty.Size = new System.Drawing.Size(104, 20);
            this.labelCmdWaitlistEmpty.TabIndex = 5;
            this.labelCmdWaitlistEmpty.Text = "Waitlist Empty";
            this.labelCmdWaitlistEmpty.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // textBox_ResponseCmdWaitlistEmpty
            // 
            this.textBox_ResponseCmdWaitlistEmpty.Anchor = ((System.Windows.Forms.AnchorStyles) (((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) | System.Windows.Forms.AnchorStyles.Right)));
            this.textBox_ResponseCmdWaitlistEmpty.Location = new System.Drawing.Point(113, 184);
            this.textBox_ResponseCmdWaitlistEmpty.Name = "textBox_ResponseCmdWaitlistEmpty";
            this.textBox_ResponseCmdWaitlistEmpty.Size = new System.Drawing.Size(307, 20);
            this.textBox_ResponseCmdWaitlistEmpty.TabIndex = 6;
            // 
            // labelCmdChatReconnect
            // 
            this.labelCmdChatReconnect.Anchor = ((System.Windows.Forms.AnchorStyles) ((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.labelCmdChatReconnect.Location = new System.Drawing.Point(12, 206);
            this.labelCmdChatReconnect.Name = "labelCmdChatReconnect";
            this.labelCmdChatReconnect.Size = new System.Drawing.Size(104, 20);
            this.labelCmdChatReconnect.TabIndex = 5;
            this.labelCmdChatReconnect.Text = "Chat Reconnect";
            this.labelCmdChatReconnect.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // textBox_ResponseCmdChatReconnect
            // 
            this.textBox_ResponseCmdChatReconnect.Anchor = ((System.Windows.Forms.AnchorStyles) (((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) | System.Windows.Forms.AnchorStyles.Right)));
            this.textBox_ResponseCmdChatReconnect.Location = new System.Drawing.Point(113, 207);
            this.textBox_ResponseCmdChatReconnect.Name = "textBox_ResponseCmdChatReconnect";
            this.textBox_ResponseCmdChatReconnect.Size = new System.Drawing.Size(307, 20);
            this.textBox_ResponseCmdChatReconnect.TabIndex = 6;
            // 
            // ConfigCommandBehaviorDialog
            // 
            this.AcceptButton = this.buttonOK;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.buttonCancel;
            this.ClientSize = new System.Drawing.Size(433, 415);
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
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        private System.Windows.Forms.Button buttonCancel;
        private System.Windows.Forms.Button buttonOK;
        private System.Windows.Forms.Label label_FormatStringsSupported;
        private System.Windows.Forms.Label labelCmdAddName;
        private System.Windows.Forms.Label labelCmdBlacklistTriggered;
        private System.Windows.Forms.Label labelCmdChatReconnect;
        private System.Windows.Forms.Label labelCmdCheckStatus;
        private System.Windows.Forms.Label labelCmdNameAlreadyExists;
        private System.Windows.Forms.Label labelCmdUserDrawn;
        private System.Windows.Forms.Label labelCmdWaitlistEmpty;
        private System.Windows.Forms.TextBox textBox_ResponseCmdAddName;
        private System.Windows.Forms.TextBox textBox_ResponseCmdBlacklistTriggered;
        private System.Windows.Forms.TextBox textBox_ResponseCmdChatReconnect;
        private System.Windows.Forms.TextBox textBox_ResponseCmdCheckStatus;
        private System.Windows.Forms.TextBox textBox_ResponseCmdNameAlreadyExists;
        private System.Windows.Forms.TextBox textBox_ResponseCmdUserDrawn;
        private System.Windows.Forms.TextBox textBox_ResponseCmdWaitlistEmpty;

        #endregion
    }
}