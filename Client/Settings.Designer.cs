namespace SneakyChat.Client
{
    partial class Settings
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Settings));
            this.containerPanel = new System.Windows.Forms.Panel();
            this.generalButton = new SneakyChat.Client.CustomButton();
            this.SuspendLayout();
            // 
            // containerPanel
            // 
            this.containerPanel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.containerPanel.Location = new System.Drawing.Point(1, 45);
            this.containerPanel.Name = "containerPanel";
            this.containerPanel.Size = new System.Drawing.Size(590, 326);
            this.containerPanel.TabIndex = 1;
            // 
            // generalButton
            // 
            this.generalButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.generalButton.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.generalButton.BorderColor = System.Drawing.Color.PaleVioletRed;
            this.generalButton.BorderRadius = 0;
            this.generalButton.BorderSize = 0;
            this.generalButton.FlatAppearance.BorderSize = 0;
            this.generalButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.generalButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.generalButton.ForeColor = System.Drawing.Color.White;
            this.generalButton.Location = new System.Drawing.Point(1, 1);
            this.generalButton.Name = "generalButton";
            this.generalButton.Size = new System.Drawing.Size(131, 44);
            this.generalButton.TabIndex = 0;
            this.generalButton.Text = "General";
            this.generalButton.TextColor = System.Drawing.Color.White;
            this.generalButton.UseVisualStyleBackColor = false;
            // 
            // Settings
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.ClientSize = new System.Drawing.Size(591, 369);
            this.Controls.Add(this.containerPanel);
            this.Controls.Add(this.generalButton);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Settings";
            this.Text = "Settings";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Settings_FormClosing);
            this.Load += new System.EventHandler(this.Settings_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private CustomButton generalButton;
        private System.Windows.Forms.Panel containerPanel;
    }
}