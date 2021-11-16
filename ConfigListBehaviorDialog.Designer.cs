using System.ComponentModel;

namespace PagTool
{
    partial class ConfigListBehaviorDialog
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
            this.label_LineageMode = new System.Windows.Forms.Label();
            this.comboBox_LineageMode = new System.Windows.Forms.ComboBox();
            this.checkBox_DoOmitFirstLineage = new System.Windows.Forms.CheckBox();
            this.checkBox_DoAutoRecycleFromDead = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            this.buttonOK.Anchor = ((System.Windows.Forms.AnchorStyles) ((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.buttonOK.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.buttonOK.Location = new System.Drawing.Point(12, 237);
            this.buttonOK.Name = "buttonOK";
            this.buttonOK.Size = new System.Drawing.Size(200, 40);
            this.buttonOK.TabIndex = 0;
            this.buttonOK.Text = "OK";
            this.buttonOK.UseVisualStyleBackColor = true;
            this.buttonCancel.Anchor = ((System.Windows.Forms.AnchorStyles) ((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.buttonCancel.Location = new System.Drawing.Point(218, 237);
            this.buttonCancel.Name = "buttonCancel";
            this.buttonCancel.Size = new System.Drawing.Size(200, 40);
            this.buttonCancel.TabIndex = 1;
            this.buttonCancel.Text = "Cancel";
            this.buttonCancel.UseVisualStyleBackColor = true;
            this.label_LineageMode.Location = new System.Drawing.Point(12, 9);
            this.label_LineageMode.Name = "label_LineageMode";
            this.label_LineageMode.Size = new System.Drawing.Size(80, 20);
            this.label_LineageMode.TabIndex = 2;
            this.label_LineageMode.Text = "Lineage Mode:";
            this.comboBox_LineageMode.FormattingEnabled = true;
            this.comboBox_LineageMode.Items.AddRange(new object[] {"None", "Numerals (1, 2, 3, etc)", "Words (the First, the Second, etc)", "Roman Numerals (I, II, III, etc)"});
            this.comboBox_LineageMode.Location = new System.Drawing.Point(98, 6);
            this.comboBox_LineageMode.Name = "comboBox_LineageMode";
            this.comboBox_LineageMode.Size = new System.Drawing.Size(320, 21);
            this.comboBox_LineageMode.TabIndex = 3;
            this.comboBox_LineageMode.SelectedIndexChanged += new System.EventHandler(this.comboBox_LineageMode_SelectedIndexChanged);
            this.checkBox_DoOmitFirstLineage.Location = new System.Drawing.Point(12, 33);
            this.checkBox_DoOmitFirstLineage.Name = "checkBox_DoOmitFirstLineage";
            this.checkBox_DoOmitFirstLineage.Size = new System.Drawing.Size(111, 20);
            this.checkBox_DoOmitFirstLineage.TabIndex = 4;
            this.checkBox_DoOmitFirstLineage.Text = "Omit First Lineage";
            this.checkBox_DoOmitFirstLineage.UseVisualStyleBackColor = true;
            this.checkBox_DoAutoRecycleFromDead.Location = new System.Drawing.Point(213, 33);
            this.checkBox_DoAutoRecycleFromDead.Name = "checkBox_DoAutoRecycleFromDead";
            this.checkBox_DoAutoRecycleFromDead.Size = new System.Drawing.Size(205, 20);
            this.checkBox_DoAutoRecycleFromDead.TabIndex = 4;
            this.checkBox_DoAutoRecycleFromDead.Text = "Auto Recycle From Dead Into Waiting";
            this.checkBox_DoAutoRecycleFromDead.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.checkBox_DoAutoRecycleFromDead.UseVisualStyleBackColor = true;
            this.AcceptButton = this.buttonOK;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.buttonCancel;
            this.ClientSize = new System.Drawing.Size(430, 289);
            this.Controls.Add(this.checkBox_DoAutoRecycleFromDead);
            this.Controls.Add(this.checkBox_DoOmitFirstLineage);
            this.Controls.Add(this.comboBox_LineageMode);
            this.Controls.Add(this.label_LineageMode);
            this.Controls.Add(this.buttonCancel);
            this.Controls.Add(this.buttonOK);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ConfigListBehaviorDialog";
            this.Text = "ConfigListBehaviorDialog";
            this.ResumeLayout(false);
        }

        private System.Windows.Forms.Button buttonCancel;
        private System.Windows.Forms.Button buttonOK;
        private System.Windows.Forms.CheckBox checkBox_DoAutoRecycleFromDead;
        private System.Windows.Forms.CheckBox checkBox_DoOmitFirstLineage;
        private System.Windows.Forms.ComboBox comboBox_LineageMode;
        private System.Windows.Forms.Label label_LineageMode;

        #endregion
    }
}