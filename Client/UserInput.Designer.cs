namespace SneakyChat.Client
{
    partial class UserInput
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(UserInput));
            this.okButton = new System.Windows.Forms.Button();
            this.avatarPictureBox = new System.Windows.Forms.PictureBox();
            this.usernameTextbox = new System.Windows.Forms.RichTextBox();
            this.avatarFileDialog = new System.Windows.Forms.OpenFileDialog();
            ((System.ComponentModel.ISupportInitialize)(this.avatarPictureBox)).BeginInit();
            this.SuspendLayout();
            // 
            // okButton
            // 
            this.okButton.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.okButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.okButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.okButton.Location = new System.Drawing.Point(121, 194);
            this.okButton.Name = "okButton";
            this.okButton.Size = new System.Drawing.Size(105, 28);
            this.okButton.TabIndex = 0;
            this.okButton.Text = "OK";
            this.okButton.UseVisualStyleBackColor = true;
            this.okButton.Click += new System.EventHandler(this.okButton_Click);
            // 
            // avatarPictureBox
            // 
            this.avatarPictureBox.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.avatarPictureBox.Cursor = System.Windows.Forms.Cursors.Hand;
            this.avatarPictureBox.Image = ((System.Drawing.Image)(resources.GetObject("avatarPictureBox.Image")));
            this.avatarPictureBox.Location = new System.Drawing.Point(121, 38);
            this.avatarPictureBox.Name = "avatarPictureBox";
            this.avatarPictureBox.Size = new System.Drawing.Size(100, 100);
            this.avatarPictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.avatarPictureBox.TabIndex = 1;
            this.avatarPictureBox.TabStop = false;
            this.avatarPictureBox.Click += new System.EventHandler(this.avatarPictureBox_Click);
            // 
            // usernameTextbox
            // 
            this.usernameTextbox.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.usernameTextbox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.usernameTextbox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.usernameTextbox.DetectUrls = false;
            this.usernameTextbox.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.usernameTextbox.ForeColor = System.Drawing.Color.White;
            this.usernameTextbox.Location = new System.Drawing.Point(72, 153);
            this.usernameTextbox.MaxLength = 15;
            this.usernameTextbox.Multiline = false;
            this.usernameTextbox.Name = "usernameTextbox";
            this.usernameTextbox.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.None;
            this.usernameTextbox.Size = new System.Drawing.Size(198, 24);
            this.usernameTextbox.TabIndex = 2;
            this.usernameTextbox.Text = "";
            // 
            // avatarFileDialog
            // 
            this.avatarFileDialog.DefaultExt = "png, PNG, jpg, jpeg, webp";
            this.avatarFileDialog.InitialDirectory = "MyPictures";
            // 
            // UserInput
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.ClientSize = new System.Drawing.Size(354, 251);
            this.Controls.Add(this.usernameTextbox);
            this.Controls.Add(this.avatarPictureBox);
            this.Controls.Add(this.okButton);
            this.ForeColor = System.Drawing.Color.White;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MinimumSize = new System.Drawing.Size(370, 290);
            this.Name = "UserInput";
            this.Text = "UserInput";
            ((System.ComponentModel.ISupportInitialize)(this.avatarPictureBox)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button okButton;
        private System.Windows.Forms.PictureBox avatarPictureBox;
        private System.Windows.Forms.RichTextBox usernameTextbox;
        public System.Windows.Forms.OpenFileDialog avatarFileDialog;
    }
}