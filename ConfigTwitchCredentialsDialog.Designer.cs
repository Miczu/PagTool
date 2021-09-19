using System.ComponentModel;

namespace PagTool
{
    partial class ConfigTwitchCredentialsDialog
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
            this.button_LaunchTokenGenerator = new System.Windows.Forms.Button();
            this.buttonCancel = new System.Windows.Forms.Button();
            this.textBox_AccessToken = new System.Windows.Forms.TextBox();
            this.label_AccessToken = new System.Windows.Forms.Label();
            this.label_ChannelName = new System.Windows.Forms.Label();
            this.textBox_ChannelName = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // buttonOK
            // 
            this.buttonOK.Anchor = ((System.Windows.Forms.AnchorStyles) ((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.buttonOK.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.buttonOK.Location = new System.Drawing.Point(12, 110);
            this.buttonOK.Name = "buttonOK";
            this.buttonOK.Size = new System.Drawing.Size(150, 40);
            this.buttonOK.TabIndex = 0;
            this.buttonOK.Text = "OK";
            this.buttonOK.UseVisualStyleBackColor = true;
            // 
            // button_LaunchTokenGenerator
            // 
            this.button_LaunchTokenGenerator.Location = new System.Drawing.Point(12, 12);
            this.button_LaunchTokenGenerator.Name = "button_LaunchTokenGenerator";
            this.button_LaunchTokenGenerator.Size = new System.Drawing.Size(312, 40);
            this.button_LaunchTokenGenerator.TabIndex = 1;
            this.button_LaunchTokenGenerator.Text = "Open Token Generator";
            this.button_LaunchTokenGenerator.UseVisualStyleBackColor = true;
            this.button_LaunchTokenGenerator.Click += new System.EventHandler(this.button_OpenTokenGenerator_Click);
            // 
            // buttonCancel
            // 
            this.buttonCancel.Anchor = ((System.Windows.Forms.AnchorStyles) ((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.buttonCancel.Location = new System.Drawing.Point(174, 110);
            this.buttonCancel.Name = "buttonCancel";
            this.buttonCancel.Size = new System.Drawing.Size(150, 40);
            this.buttonCancel.TabIndex = 2;
            this.buttonCancel.Text = "Cancel";
            this.buttonCancel.UseVisualStyleBackColor = true;
            // 
            // textBox_AccessToken
            // 
            this.textBox_AccessToken.Anchor = ((System.Windows.Forms.AnchorStyles) ((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.textBox_AccessToken.Location = new System.Drawing.Point(91, 84);
            this.textBox_AccessToken.Name = "textBox_AccessToken";
            this.textBox_AccessToken.Size = new System.Drawing.Size(232, 20);
            this.textBox_AccessToken.TabIndex = 3;
            // 
            // label_AccessToken
            // 
            this.label_AccessToken.Anchor = ((System.Windows.Forms.AnchorStyles) ((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label_AccessToken.Location = new System.Drawing.Point(11, 83);
            this.label_AccessToken.Name = "label_AccessToken";
            this.label_AccessToken.Size = new System.Drawing.Size(79, 20);
            this.label_AccessToken.TabIndex = 4;
            this.label_AccessToken.Text = "Access Token:";
            this.label_AccessToken.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label_ChannelName
            // 
            this.label_ChannelName.Anchor = ((System.Windows.Forms.AnchorStyles) ((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label_ChannelName.Location = new System.Drawing.Point(11, 58);
            this.label_ChannelName.Name = "label_ChannelName";
            this.label_ChannelName.Size = new System.Drawing.Size(80, 20);
            this.label_ChannelName.TabIndex = 6;
            this.label_ChannelName.Text = "Channel Name:";
            this.label_ChannelName.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // textBox_ChannelName
            // 
            this.textBox_ChannelName.Anchor = ((System.Windows.Forms.AnchorStyles) ((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.textBox_ChannelName.Location = new System.Drawing.Point(91, 58);
            this.textBox_ChannelName.Name = "textBox_ChannelName";
            this.textBox_ChannelName.Size = new System.Drawing.Size(232, 20);
            this.textBox_ChannelName.TabIndex = 5;
            // 
            // ConfigTwitchCredentialsDialog
            // 
            this.AcceptButton = this.buttonOK;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.buttonCancel;
            this.ClientSize = new System.Drawing.Size(336, 162);
            this.Controls.Add(this.label_ChannelName);
            this.Controls.Add(this.textBox_ChannelName);
            this.Controls.Add(this.label_AccessToken);
            this.Controls.Add(this.textBox_AccessToken);
            this.Controls.Add(this.buttonCancel);
            this.Controls.Add(this.button_LaunchTokenGenerator);
            this.Controls.Add(this.buttonOK);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ConfigTwitchCredentialsDialog";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "ConfigTwitchCredentialsDialog";
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        private System.Windows.Forms.Button button_LaunchTokenGenerator;
        private System.Windows.Forms.Button buttonCancel;
        private System.Windows.Forms.Button buttonOK;
        private System.Windows.Forms.Label label_AccessToken;
        private System.Windows.Forms.Label label_ChannelName;
        private System.Windows.Forms.TextBox textBox_AccessToken;
        private System.Windows.Forms.TextBox textBox_ChannelName;

        #endregion
    }
}