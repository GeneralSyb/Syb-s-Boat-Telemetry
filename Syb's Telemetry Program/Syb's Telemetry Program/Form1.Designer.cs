
namespace Syb_s_Telemetry_Program
{
    partial class SybsTelemetry
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

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
            this.richTextBox1 = new System.Windows.Forms.RichTextBox();
            this.StartSessionButton = new System.Windows.Forms.Button();
            this.EndSessionButton = new System.Windows.Forms.Button();
            this.ComListBox = new System.Windows.Forms.ListBox();
            this.SelectFolder = new System.Windows.Forms.FolderBrowserDialog();
            this.SuspendLayout();
            // 
            // richTextBox1
            // 
            this.richTextBox1.Location = new System.Drawing.Point(488, 12);
            this.richTextBox1.Name = "richTextBox1";
            this.richTextBox1.Size = new System.Drawing.Size(300, 426);
            this.richTextBox1.TabIndex = 0;
            this.richTextBox1.Text = "";
            this.richTextBox1.TextChanged += new System.EventHandler(this.richTextBox1_TextChanged);
            // 
            // StartSessionButton
            // 
            this.StartSessionButton.Location = new System.Drawing.Point(488, 418);
            this.StartSessionButton.Name = "StartSessionButton";
            this.StartSessionButton.Size = new System.Drawing.Size(150, 20);
            this.StartSessionButton.TabIndex = 1;
            this.StartSessionButton.Text = "Start session";
            this.StartSessionButton.UseVisualStyleBackColor = true;
            this.StartSessionButton.Click += new System.EventHandler(this.StartSessionButton_Click);
            // 
            // EndSessionButton
            // 
            this.EndSessionButton.Location = new System.Drawing.Point(638, 418);
            this.EndSessionButton.Name = "EndSessionButton";
            this.EndSessionButton.Size = new System.Drawing.Size(150, 20);
            this.EndSessionButton.TabIndex = 2;
            this.EndSessionButton.Text = "End/Save session";
            this.EndSessionButton.UseVisualStyleBackColor = true;
            // 
            // ComListBox
            // 
            this.ComListBox.FormattingEnabled = true;
            this.ComListBox.Items.AddRange(new object[] {
            "COM1",
            "COM2",
            "COM3"});
            this.ComListBox.Location = new System.Drawing.Point(362, 343);
            this.ComListBox.Name = "ComListBox";
            this.ComListBox.Size = new System.Drawing.Size(120, 95);
            this.ComListBox.TabIndex = 3;
            // 
            // SybsTelemetry
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.ComListBox);
            this.Controls.Add(this.EndSessionButton);
            this.Controls.Add(this.StartSessionButton);
            this.Controls.Add(this.richTextBox1);
            this.Name = "SybsTelemetry";
            this.Text = "Syb\'s Telemetry Program";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.RichTextBox richTextBox1;
        private System.Windows.Forms.Button StartSessionButton;
        private System.Windows.Forms.Button EndSessionButton;
        private System.Windows.Forms.ListBox ComListBox;
        private System.Windows.Forms.FolderBrowserDialog SelectFolder;
    }
}

