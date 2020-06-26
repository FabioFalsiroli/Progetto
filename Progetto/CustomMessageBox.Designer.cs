namespace Progetto
{
    partial class CustomMessageBox
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
            this.panel = new System.Windows.Forms.Panel();
            this.labelCustomBox = new System.Windows.Forms.Label();
            this.buttonCustomBox = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // panel
            // 
            this.panel.BackColor = System.Drawing.SystemColors.MenuHighlight;
            this.panel.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.panel.Location = new System.Drawing.Point(1, 203);
            this.panel.Name = "panel";
            this.panel.Size = new System.Drawing.Size(444, 21);
            this.panel.TabIndex = 0;
            // 
            // labelCustomBox
            // 
            this.labelCustomBox.AutoSize = true;
            this.labelCustomBox.Location = new System.Drawing.Point(110, 63);
            this.labelCustomBox.Name = "labelCustomBox";
            this.labelCustomBox.Size = new System.Drawing.Size(24, 13);
            this.labelCustomBox.TabIndex = 1;
            this.labelCustomBox.Text = "text";
            // 
            // buttonCustomBox
            // 
            this.buttonCustomBox.Font = new System.Drawing.Font("Sitka Banner", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonCustomBox.Location = new System.Drawing.Point(187, 133);
            this.buttonCustomBox.Name = "buttonCustomBox";
            this.buttonCustomBox.Size = new System.Drawing.Size(75, 31);
            this.buttonCustomBox.TabIndex = 2;
            this.buttonCustomBox.Text = "OK";
            this.buttonCustomBox.UseVisualStyleBackColor = true;
            this.buttonCustomBox.Click += new System.EventHandler(this.buttonCustomBox_Click);
            // 
            // CustomMessageBox
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(447, 223);
            this.Controls.Add(this.buttonCustomBox);
            this.Controls.Add(this.labelCustomBox);
            this.Controls.Add(this.panel);
            this.Name = "CustomMessageBox";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "CustomMessageBox";
            this.Load += new System.EventHandler(this.CustomMessageBox_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel;
        private System.Windows.Forms.Label labelCustomBox;
        private System.Windows.Forms.Button buttonCustomBox;
    }
}