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
            this.textBox_ArgsDoCmdNameAdd = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.textBox_AliasDoCmdNameAdd = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // buttonOK
            // 
            this.buttonOK.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.buttonOK.Location = new System.Drawing.Point(12, 421);
            this.buttonOK.Name = "buttonOK";
            this.buttonOK.Size = new System.Drawing.Size(158, 31);
            this.buttonOK.TabIndex = 0;
            this.buttonOK.Text = "OK";
            this.buttonOK.UseVisualStyleBackColor = true;
            // 
            // checkBox_DoCmdNameAdd
            // 
            this.checkBox_DoCmdNameAdd.Location = new System.Drawing.Point(12, 30);
            this.checkBox_DoCmdNameAdd.Name = "checkBox_DoCmdNameAdd";
            this.checkBox_DoCmdNameAdd.Size = new System.Drawing.Size(81, 16);
            this.checkBox_DoCmdNameAdd.TabIndex = 1;
            this.checkBox_DoCmdNameAdd.Text = "Add Name";
            this.checkBox_DoCmdNameAdd.UseVisualStyleBackColor = true;
            // 
            // buttonCancel
            // 
            this.buttonCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.buttonCancel.Location = new System.Drawing.Point(386, 421);
            this.buttonCancel.Name = "buttonCancel";
            this.buttonCancel.Size = new System.Drawing.Size(171, 31);
            this.buttonCancel.TabIndex = 2;
            this.buttonCancel.Text = "Cancel";
            this.buttonCancel.UseVisualStyleBackColor = true;
            // 
            // textBox_ArgsDoCmdNameAdd
            // 
            this.textBox_ArgsDoCmdNameAdd.Location = new System.Drawing.Point(99, 28);
            this.textBox_ArgsDoCmdNameAdd.Name = "textBox_ArgsDoCmdNameAdd";
            this.textBox_ArgsDoCmdNameAdd.Size = new System.Drawing.Size(119, 20);
            this.textBox_ArgsDoCmdNameAdd.TabIndex = 3;
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(114, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(92, 16);
            this.label1.TabIndex = 4;
            this.label1.Text = "Primary Command";
            // 
            // textBox_AliasDoCmdNameAdd
            // 
            this.textBox_AliasDoCmdNameAdd.Location = new System.Drawing.Point(224, 28);
            this.textBox_AliasDoCmdNameAdd.Name = "textBox_AliasDoCmdNameAdd";
            this.textBox_AliasDoCmdNameAdd.Size = new System.Drawing.Size(333, 20);
            this.textBox_AliasDoCmdNameAdd.TabIndex = 5;
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(267, 9);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(254, 16);
            this.label2.TabIndex = 6;
            this.label2.Text = "Additional Command Aliases (Space Seperated List)";
            // 
            // label3
            // 
            this.label3.Location = new System.Drawing.Point(28, 9);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(49, 13);
            this.label3.TabIndex = 7;
            this.label3.Text = "ON/OFF";
            // 
            // ConfigCommandAliasDialog
            // 
            this.AcceptButton = this.buttonOK;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.buttonCancel;
            this.ClientSize = new System.Drawing.Size(569, 464);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.textBox_AliasDoCmdNameAdd);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.textBox_ArgsDoCmdNameAdd);
            this.Controls.Add(this.buttonCancel);
            this.Controls.Add(this.checkBox_DoCmdNameAdd);
            this.Controls.Add(this.buttonOK);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ConfigCommandAliasDialog";
            this.Text = "ConfigCommandAliasDialog";
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        private System.Windows.Forms.Button buttonCancel;
        private System.Windows.Forms.Button buttonOK;
        private System.Windows.Forms.CheckBox checkBox_DoCmdNameAdd;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox textBox_AliasDoCmdNameAdd;
        private System.Windows.Forms.TextBox textBox_ArgsDoCmdNameAdd;

        #endregion
    }
}