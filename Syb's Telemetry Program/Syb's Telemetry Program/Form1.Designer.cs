
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
            this.ConsoleWindow = new System.Windows.Forms.RichTextBox();
            this.StartSessionButton = new System.Windows.Forms.Button();
            this.EndSessionButton = new System.Windows.Forms.Button();
            this.ComListBox = new System.Windows.Forms.ListBox();
            this.SelectFolder = new System.Windows.Forms.FolderBrowserDialog();
            this.AutoScrollButton = new System.Windows.Forms.CheckBox();
            this.TimeStampButton = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // ConsoleWindow
            // 
            this.ConsoleWindow.Location = new System.Drawing.Point(648, 12);
            this.ConsoleWindow.Name = "ConsoleWindow";
            this.ConsoleWindow.Size = new System.Drawing.Size(300, 475);
            this.ConsoleWindow.TabIndex = 4;
            this.ConsoleWindow.Text = "";
            this.ConsoleWindow.TextChanged += new System.EventHandler(this.ConsoleWindow_TextChanged);
            // 
            // StartSessionButton
            // 
            this.StartSessionButton.Location = new System.Drawing.Point(648, 493);
            this.StartSessionButton.Name = "StartSessionButton";
            this.StartSessionButton.Size = new System.Drawing.Size(150, 20);
            this.StartSessionButton.TabIndex = 1;
            this.StartSessionButton.Text = "Start session";
            this.StartSessionButton.UseVisualStyleBackColor = true;
            this.StartSessionButton.Click += new System.EventHandler(this.StartSessionButton_Click);
            // 
            // EndSessionButton
            // 
            this.EndSessionButton.Location = new System.Drawing.Point(798, 493);
            this.EndSessionButton.Name = "EndSessionButton";
            this.EndSessionButton.Size = new System.Drawing.Size(150, 20);
            this.EndSessionButton.TabIndex = 2;
            this.EndSessionButton.Text = "End/Save session";
            this.EndSessionButton.UseVisualStyleBackColor = true;
            // 
            // ComListBox
            // 
            this.ComListBox.FormattingEnabled = true;
            this.ComListBox.Location = new System.Drawing.Point(522, 418);
            this.ComListBox.Name = "ComListBox";
            this.ComListBox.Size = new System.Drawing.Size(120, 95);
            this.ComListBox.TabIndex = 3;
            // 
            // AutoScrollButton
            // 
            this.AutoScrollButton.AutoSize = true;
            this.AutoScrollButton.Location = new System.Drawing.Point(562, 395);
            this.AutoScrollButton.Name = "AutoScrollButton";
            this.AutoScrollButton.Size = new System.Drawing.Size(77, 17);
            this.AutoScrollButton.TabIndex = 5;
            this.AutoScrollButton.Text = "Auto Scroll";
            this.AutoScrollButton.UseVisualStyleBackColor = true;
            // 
            // TimeStampButton
            // 
            this.TimeStampButton.AutoSize = true;
            this.TimeStampButton.Location = new System.Drawing.Point(562, 372);
            this.TimeStampButton.Name = "TimeStampButton";
            this.TimeStampButton.Size = new System.Drawing.Size(77, 17);
            this.TimeStampButton.TabIndex = 6;
            this.TimeStampButton.Text = "Timestamp";
            this.TimeStampButton.UseVisualStyleBackColor = true;
            // 
            // SybsTelemetry
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(960, 525);
            this.Controls.Add(this.TimeStampButton);
            this.Controls.Add(this.AutoScrollButton);
            this.Controls.Add(this.ComListBox);
            this.Controls.Add(this.EndSessionButton);
            this.Controls.Add(this.StartSessionButton);
            this.Controls.Add(this.ConsoleWindow);
            this.Name = "SybsTelemetry";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Syb\'s Telemetry Program";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.RichTextBox ConsoleWindow;
        private System.Windows.Forms.Button StartSessionButton;
        private System.Windows.Forms.Button EndSessionButton;
        private System.Windows.Forms.ListBox ComListBox;
        private System.Windows.Forms.FolderBrowserDialog SelectFolder;
        private System.Windows.Forms.CheckBox AutoScrollButton;
        private System.Windows.Forms.CheckBox TimeStampButton;
    }
}

