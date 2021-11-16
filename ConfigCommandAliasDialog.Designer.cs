using System.ComponentModel;

namespace PagTool
{
    partial class ConfigCommandAliasDialog
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
            this.checkBox_DoCmdNameAdd = new System.Windows.Forms.CheckBox();
            this.buttonCancel = new System.Windows.Forms.Button();
            this.textBox_AliasDoCmdNameAdd = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.textBox_AliasDoCmdCheckStatus = new System.Windows.Forms.TextBox();
            this.checkBox_DoCmdCheckStatus = new System.Windows.Forms.CheckBox();
            this.checkBox_DoCmdMoveToDead = new System.Windows.Forms.CheckBox();
            this.textBox_AliasDoCmdMoveToDead = new System.Windows.Forms.TextBox();
            this.checkBox_DoCmdHelp = new System.Windows.Forms.CheckBox();
            this.textBox_AliasDoCmdHelp = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // buttonOK
            // 
            this.buttonOK.Anchor = ((System.Windows.Forms.AnchorStyles) ((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.buttonOK.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.buttonOK.Location = new System.Drawing.Point(12, 217);
            this.buttonOK.Name = "buttonOK";
            this.buttonOK.Size = new System.Drawing.Size(200, 40);
            this.buttonOK.TabIndex = 0;
            this.buttonOK.Text = "OK";
            this.buttonOK.UseVisualStyleBackColor = true;
            // 
            // checkBox_DoCmdNameAdd
            // 
            this.checkBox_DoCmdNameAdd.Anchor = ((System.Windows.Forms.AnchorStyles) ((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.checkBox_DoCmdNameAdd.Location = new System.Drawing.Point(12, 191);
            this.checkBox_DoCmdNameAdd.Name = "checkBox_DoCmdNameAdd";
            this.checkBox_DoCmdNameAdd.Size = new System.Drawing.Size(80, 20);
            this.checkBox_DoCmdNameAdd.TabIndex = 1;
            this.checkBox_DoCmdNameAdd.Text = "Add Name";
            this.checkBox_DoCmdNameAdd.UseVisualStyleBackColor = true;
            // 
            // buttonCancel
            // 
            this.buttonCancel.Anchor = ((System.Windows.Forms.AnchorStyles) ((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.buttonCancel.Location = new System.Drawing.Point(343, 217);
            this.buttonCancel.Name = "buttonCancel";
            this.buttonCancel.Size = new System.Drawing.Size(200, 40);
            this.buttonCancel.TabIndex = 2;
            this.buttonCancel.Text = "Cancel";
            this.buttonCancel.UseVisualStyleBackColor = true;
            // 
            // textBox_AliasDoCmdNameAdd
            // 
            this.textBox_AliasDoCmdNameAdd.Anchor = ((System.Windows.Forms.AnchorStyles) ((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.textBox_AliasDoCmdNameAdd.Location = new System.Drawing.Point(106, 191);
            this.textBox_AliasDoCmdNameAdd.Name = "textBox_AliasDoCmdNameAdd";
            this.textBox_AliasDoCmdNameAdd.Size = new System.Drawing.Size(437, 20);
            this.textBox_AliasDoCmdNameAdd.TabIndex = 5;
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles) ((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label2.Location = new System.Drawing.Point(340, 9);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(203, 16);
            this.label2.TabIndex = 6;
            this.label2.Text = "Command Aliases (Space Seperated List)";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label3
            // 
            this.label3.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.label3.Location = new System.Drawing.Point(12, 9);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(67, 17);
            this.label3.TabIndex = 7;
            this.label3.Text = "ON/OFF";
            // 
            // textBox_AliasDoCmdCheckStatus
            // 
            this.textBox_AliasDoCmdCheckStatus.Anchor = ((System.Windows.Forms.AnchorStyles) ((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.textBox_AliasDoCmdCheckStatus.Location = new System.Drawing.Point(106, 165);
            this.textBox_AliasDoCmdCheckStatus.Name = "textBox_AliasDoCmdCheckStatus";
            this.textBox_AliasDoCmdCheckStatus.Size = new System.Drawing.Size(437, 20);
            this.textBox_AliasDoCmdCheckStatus.TabIndex = 9;
            // 
            // checkBox_DoCmdCheckStatus
            // 
            this.checkBox_DoCmdCheckStatus.Anchor = ((System.Windows.Forms.AnchorStyles) ((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.checkBox_DoCmdCheckStatus.Location = new System.Drawing.Point(12, 165);
            this.checkBox_DoCmdCheckStatus.Name = "checkBox_DoCmdCheckStatus";
            this.checkBox_DoCmdCheckStatus.Size = new System.Drawing.Size(91, 20);
            this.checkBox_DoCmdCheckStatus.TabIndex = 8;
            this.checkBox_DoCmdCheckStatus.Text = "Check Status";
            this.checkBox_DoCmdCheckStatus.UseVisualStyleBackColor = true;
            // 
            // checkBox_DoCmdMoveToDead
            // 
            this.checkBox_DoCmdMoveToDead.Anchor = ((System.Windows.Forms.AnchorStyles) ((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.checkBox_DoCmdMoveToDead.Location = new System.Drawing.Point(12, 139);
            this.checkBox_DoCmdMoveToDead.Name = "checkBox_DoCmdMoveToDead";
            this.checkBox_DoCmdMoveToDead.Size = new System.Drawing.Size(102, 20);
            this.checkBox_DoCmdMoveToDead.TabIndex = 8;
            this.checkBox_DoCmdMoveToDead.Text = "Move To Dead";
            this.checkBox_DoCmdMoveToDead.UseVisualStyleBackColor = true;
            // 
            // textBox_AliasDoCmdMoveToDead
            // 
            this.textBox_AliasDoCmdMoveToDead.Anchor = ((System.Windows.Forms.AnchorStyles) ((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.textBox_AliasDoCmdMoveToDead.Location = new System.Drawing.Point(106, 139);
            this.textBox_AliasDoCmdMoveToDead.Name = "textBox_AliasDoCmdMoveToDead";
            this.textBox_AliasDoCmdMoveToDead.Size = new System.Drawing.Size(437, 20);
            this.textBox_AliasDoCmdMoveToDead.TabIndex = 9;
            // 
            // checkBox_DoCmdHelp
            // 
            this.checkBox_DoCmdHelp.Anchor = ((System.Windows.Forms.AnchorStyles) ((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.checkBox_DoCmdHelp.Location = new System.Drawing.Point(12, 113);
            this.checkBox_DoCmdHelp.Name = "checkBox_DoCmdHelp";
            this.checkBox_DoCmdHelp.Size = new System.Drawing.Size(91, 20);
            this.checkBox_DoCmdHelp.TabIndex = 8;
            this.checkBox_DoCmdHelp.Text = "Show Help";
            this.checkBox_DoCmdHelp.UseVisualStyleBackColor = true;
            // 
            // textBox_AliasDoCmdHelp
            // 
            this.textBox_AliasDoCmdHelp.Anchor = ((System.Windows.Forms.AnchorStyles) ((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.textBox_AliasDoCmdHelp.Location = new System.Drawing.Point(106, 113);
            this.textBox_AliasDoCmdHelp.Name = "textBox_AliasDoCmdHelp";
            this.textBox_AliasDoCmdHelp.Size = new System.Drawing.Size(437, 20);
            this.textBox_AliasDoCmdHelp.TabIndex = 9;
            // 
            // ConfigCommandAliasDialog
            // 
            this.AcceptButton = this.buttonOK;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.buttonCancel;
            this.ClientSize = new System.Drawing.Size(555, 269);
            this.Controls.Add(this.textBox_AliasDoCmdHelp);
            this.Controls.Add(this.textBox_AliasDoCmdMoveToDead);
            this.Controls.Add(this.textBox_AliasDoCmdCheckStatus);
            this.Controls.Add(this.checkBox_DoCmdHelp);
            this.Controls.Add(this.checkBox_DoCmdMoveToDead);
            this.Controls.Add(this.checkBox_DoCmdCheckStatus);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.textBox_AliasDoCmdNameAdd);
            this.Controls.Add(this.buttonCancel);
            this.Controls.Add(this.checkBox_DoCmdNameAdd);
            this.Controls.Add(this.buttonOK);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ConfigCommandAliasDialog";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "ConfigCommandAliasDialog";
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        private System.Windows.Forms.Button buttonCancel;
        private System.Windows.Forms.Button buttonOK;
        private System.Windows.Forms.CheckBox checkBox_DoCmdCheckStatus;
        private System.Windows.Forms.CheckBox checkBox_DoCmdHelp;
        private System.Windows.Forms.CheckBox checkBox_DoCmdMoveToDead;
        private System.Windows.Forms.CheckBox checkBox_DoCmdNameAdd;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox textBox_AliasDoCmdCheckStatus;
        private System.Windows.Forms.TextBox textBox_AliasDoCmdHelp;
        private System.Windows.Forms.TextBox textBox_AliasDoCmdMoveToDead;
        private System.Windows.Forms.TextBox textBox_AliasDoCmdNameAdd;

        #endregion
    }
}