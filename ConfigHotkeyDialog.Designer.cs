﻿using System.ComponentModel;

namespace PagTool
{
    partial class ConfigHotkeyDialog
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
            this.label_SelectRandom = new System.Windows.Forms.Label();
            this.textBox_SelectRandomUser = new System.Windows.Forms.TextBox();
            this.label_ClearAllLists = new System.Windows.Forms.Label();
            this.textBox_ClearAllLists = new System.Windows.Forms.TextBox();
            this.label_ShuffleIntoWaitlist = new System.Windows.Forms.Label();
            this.textBox_ShuffleIntoWaitlist = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // buttonOK
            // 
            this.buttonOK.Anchor = ((System.Windows.Forms.AnchorStyles) ((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.buttonOK.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.buttonOK.Location = new System.Drawing.Point(12, 204);
            this.buttonOK.Name = "buttonOK";
            this.buttonOK.Size = new System.Drawing.Size(150, 40);
            this.buttonOK.TabIndex = 1;
            this.buttonOK.Text = "OK";
            this.buttonOK.UseVisualStyleBackColor = true;
            // 
            // buttonCancel
            // 
            this.buttonCancel.Anchor = ((System.Windows.Forms.AnchorStyles) ((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.buttonCancel.Location = new System.Drawing.Point(173, 204);
            this.buttonCancel.Name = "buttonCancel";
            this.buttonCancel.Size = new System.Drawing.Size(150, 40);
            this.buttonCancel.TabIndex = 2;
            this.buttonCancel.Text = "Cancel";
            this.buttonCancel.UseVisualStyleBackColor = true;
            // 
            // label_SelectRandom
            // 
            this.label_SelectRandom.Anchor = ((System.Windows.Forms.AnchorStyles) ((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label_SelectRandom.Location = new System.Drawing.Point(12, 178);
            this.label_SelectRandom.Name = "label_SelectRandom";
            this.label_SelectRandom.Size = new System.Drawing.Size(107, 20);
            this.label_SelectRandom.TabIndex = 3;
            this.label_SelectRandom.Text = "Select Random User";
            this.label_SelectRandom.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // textBox_SelectRandomUser
            // 
            this.textBox_SelectRandomUser.Anchor = ((System.Windows.Forms.AnchorStyles) ((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.textBox_SelectRandomUser.Location = new System.Drawing.Point(125, 178);
            this.textBox_SelectRandomUser.Name = "textBox_SelectRandomUser";
            this.textBox_SelectRandomUser.ReadOnly = true;
            this.textBox_SelectRandomUser.Size = new System.Drawing.Size(198, 20);
            this.textBox_SelectRandomUser.TabIndex = 4;
            this.textBox_SelectRandomUser.KeyDown += new System.Windows.Forms.KeyEventHandler(this.textBox_SelectRandomUser_KeyDown);
            // 
            // label_ClearAllLists
            // 
            this.label_ClearAllLists.Anchor = ((System.Windows.Forms.AnchorStyles) ((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label_ClearAllLists.Location = new System.Drawing.Point(12, 154);
            this.label_ClearAllLists.Name = "label_ClearAllLists";
            this.label_ClearAllLists.Size = new System.Drawing.Size(107, 20);
            this.label_ClearAllLists.TabIndex = 3;
            this.label_ClearAllLists.Text = "Clear All Lists";
            this.label_ClearAllLists.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // textBox_ClearAllLists
            // 
            this.textBox_ClearAllLists.Anchor = ((System.Windows.Forms.AnchorStyles) ((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.textBox_ClearAllLists.Location = new System.Drawing.Point(125, 154);
            this.textBox_ClearAllLists.Name = "textBox_ClearAllLists";
            this.textBox_ClearAllLists.ReadOnly = true;
            this.textBox_ClearAllLists.Size = new System.Drawing.Size(198, 20);
            this.textBox_ClearAllLists.TabIndex = 4;
            this.textBox_ClearAllLists.KeyDown += new System.Windows.Forms.KeyEventHandler(this.textBox_ClearAllLists_KeyDown);
            // 
            // label_ShuffleIntoWaitlist
            // 
            this.label_ShuffleIntoWaitlist.Anchor = ((System.Windows.Forms.AnchorStyles) ((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label_ShuffleIntoWaitlist.Location = new System.Drawing.Point(12, 130);
            this.label_ShuffleIntoWaitlist.Name = "label_ShuffleIntoWaitlist";
            this.label_ShuffleIntoWaitlist.Size = new System.Drawing.Size(107, 20);
            this.label_ShuffleIntoWaitlist.TabIndex = 3;
            this.label_ShuffleIntoWaitlist.Text = "Shuffle Into Waitlist";
            this.label_ShuffleIntoWaitlist.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // textBox_ShuffleIntoWaitlist
            // 
            this.textBox_ShuffleIntoWaitlist.Anchor = ((System.Windows.Forms.AnchorStyles) ((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.textBox_ShuffleIntoWaitlist.Location = new System.Drawing.Point(125, 130);
            this.textBox_ShuffleIntoWaitlist.Name = "textBox_ShuffleIntoWaitlist";
            this.textBox_ShuffleIntoWaitlist.ReadOnly = true;
            this.textBox_ShuffleIntoWaitlist.Size = new System.Drawing.Size(198, 20);
            this.textBox_ShuffleIntoWaitlist.TabIndex = 4;
            this.textBox_ShuffleIntoWaitlist.KeyDown += new System.Windows.Forms.KeyEventHandler(this.textBox_ShuffleIntoWaitlist_KeyDown);
            // 
            // ConfigHotkeyDialog
            // 
            this.AcceptButton = this.buttonOK;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(335, 256);
            this.Controls.Add(this.textBox_ShuffleIntoWaitlist);
            this.Controls.Add(this.textBox_ClearAllLists);
            this.Controls.Add(this.textBox_SelectRandomUser);
            this.Controls.Add(this.label_ShuffleIntoWaitlist);
            this.Controls.Add(this.label_ClearAllLists);
            this.Controls.Add(this.label_SelectRandom);
            this.Controls.Add(this.buttonCancel);
            this.Controls.Add(this.buttonOK);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ConfigHotkeyDialog";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "ConfigHotkeyDialog";
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        private System.Windows.Forms.Button buttonCancel;
        private System.Windows.Forms.Button buttonOK;
        private System.Windows.Forms.Label label_ClearAllLists;
        private System.Windows.Forms.Label label_SelectRandom;
        private System.Windows.Forms.Label label_ShuffleIntoWaitlist;
        private System.Windows.Forms.TextBox textBox_ClearAllLists;
        private System.Windows.Forms.TextBox textBox_SelectRandomUser;
        private System.Windows.Forms.TextBox textBox_ShuffleIntoWaitlist;

        #endregion
    }
}