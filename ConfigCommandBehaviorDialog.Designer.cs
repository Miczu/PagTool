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
            this.SuspendLayout();
            // 
            // buttonOK
            // 
            this.buttonOK.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.buttonOK.Location = new System.Drawing.Point(12, 395);
            this.buttonOK.Name = "buttonOK";
            this.buttonOK.Size = new System.Drawing.Size(224, 43);
            this.buttonOK.TabIndex = 0;
            this.buttonOK.Text = "OK";
            this.buttonOK.UseVisualStyleBackColor = true;
            // 
            // buttonCancel
            // 
            this.buttonCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.buttonCancel.Location = new System.Drawing.Point(366, 395);
            this.buttonCancel.Name = "buttonCancel";
            this.buttonCancel.Size = new System.Drawing.Size(188, 43);
            this.buttonCancel.TabIndex = 1;
            this.buttonCancel.Text = "Cancel";
            this.buttonCancel.UseVisualStyleBackColor = true;
            // 
            // labelCmdAddName
            // 
            this.labelCmdAddName.Location = new System.Drawing.Point(12, 15);
            this.labelCmdAddName.Name = "labelCmdAddName";
            this.labelCmdAddName.Size = new System.Drawing.Size(59, 15);
            this.labelCmdAddName.TabIndex = 2;
            this.labelCmdAddName.Text = "Add Name";
            // 
            // textBox_ResponseCmdAddName
            // 
            this.textBox_ResponseCmdAddName.Location = new System.Drawing.Point(76, 12);
            this.textBox_ResponseCmdAddName.Name = "textBox_ResponseCmdAddName";
            this.textBox_ResponseCmdAddName.Size = new System.Drawing.Size(478, 20);
            this.textBox_ResponseCmdAddName.TabIndex = 3;
            // 
            // ConfigCommandBehaviorDialog
            // 
            this.AcceptButton = this.buttonOK;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.buttonCancel;
            this.ClientSize = new System.Drawing.Size(566, 450);
            this.Controls.Add(this.textBox_ResponseCmdAddName);
            this.Controls.Add(this.labelCmdAddName);
            this.Controls.Add(this.buttonCancel);
            this.Controls.Add(this.buttonOK);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Name = "ConfigCommandBehaviorDialog";
            this.Text = "ConfigCommandBehaviorDialog";
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        private System.Windows.Forms.Button buttonCancel;
        private System.Windows.Forms.Button buttonOK;
        private System.Windows.Forms.Label labelCmdAddName;
        private System.Windows.Forms.TextBox textBox_ResponseCmdAddName;

        #endregion
    }
}