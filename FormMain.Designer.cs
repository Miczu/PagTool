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
            this.richTextBox_ConsoleDebugLog = new System.Windows.Forms.RichTextBox();
            this.SuspendLayout();
            // 
            // richTextBox_ConsoleDebugLog
            // 
            this.richTextBox_ConsoleDebugLog.Location = new System.Drawing.Point(20, 22);
            this.richTextBox_ConsoleDebugLog.Name = "richTextBox_ConsoleDebugLog";
            this.richTextBox_ConsoleDebugLog.Size = new System.Drawing.Size(756, 408);
            this.richTextBox_ConsoleDebugLog.TabIndex = 0;
            this.richTextBox_ConsoleDebugLog.Text = "";
            // 
            // FormMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.richTextBox_ConsoleDebugLog);
            this.Name = "FormMain";
            this.Text = "FormMain";
            this.ResumeLayout(false);
        }

        private System.Windows.Forms.RichTextBox richTextBox_ConsoleDebugLog;

        #endregion
    }
}