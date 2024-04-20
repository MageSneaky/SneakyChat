namespace SneakyChat.Client
{
    partial class Bubble
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.timeDateLabel = new System.Windows.Forms.Label();
            this.usernameLabel = new System.Windows.Forms.Label();
            this.avatarPictureBox = new System.Windows.Forms.PictureBox();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.messageText = new System.Windows.Forms.RichTextBox();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.avatarPictureBox)).BeginInit();
            this.flowLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // timeDateLabel
            // 
            this.timeDateLabel.AutoSize = true;
            this.timeDateLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.timeDateLabel.ForeColor = System.Drawing.Color.White;
            this.timeDateLabel.Location = new System.Drawing.Point(58, 0);
            this.timeDateLabel.Margin = new System.Windows.Forms.Padding(0);
            this.timeDateLabel.Name = "timeDateLabel";
            this.timeDateLabel.Padding = new System.Windows.Forms.Padding(0, 3, 0, 0);
            this.timeDateLabel.Size = new System.Drawing.Size(60, 18);
            this.timeDateLabel.TabIndex = 1;
            this.timeDateLabel.Text = "10:40 PM";
            this.timeDateLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // usernameLabel
            // 
            this.usernameLabel.AutoSize = true;
            this.usernameLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.usernameLabel.ForeColor = System.Drawing.Color.White;
            this.usernameLabel.Location = new System.Drawing.Point(3, 0);
            this.usernameLabel.Margin = new System.Windows.Forms.Padding(3, 0, 0, 0);
            this.usernameLabel.Name = "usernameLabel";
            this.usernameLabel.Padding = new System.Windows.Forms.Padding(0, 2, 0, 0);
            this.usernameLabel.Size = new System.Drawing.Size(55, 19);
            this.usernameLabel.TabIndex = 2;
            this.usernameLabel.Text = "Sneaky";
            // 
            // avatarPictureBox
            // 
            this.avatarPictureBox.Location = new System.Drawing.Point(0, 0);
            this.avatarPictureBox.Name = "avatarPictureBox";
            this.avatarPictureBox.Size = new System.Drawing.Size(50, 50);
            this.avatarPictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.avatarPictureBox.TabIndex = 3;
            this.avatarPictureBox.TabStop = false;
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.flowLayoutPanel1.BackColor = System.Drawing.Color.Transparent;
            this.flowLayoutPanel1.Controls.Add(this.usernameLabel);
            this.flowLayoutPanel1.Controls.Add(this.timeDateLabel);
            this.flowLayoutPanel1.ForeColor = System.Drawing.Color.White;
            this.flowLayoutPanel1.Location = new System.Drawing.Point(56, 0);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(600, 24);
            this.flowLayoutPanel1.TabIndex = 5;
            this.flowLayoutPanel1.WrapContents = false;
            // 
            // messageText
            // 
            this.messageText.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.messageText.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(45)))));
            this.messageText.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.messageText.Cursor = System.Windows.Forms.Cursors.Default;
            this.messageText.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.messageText.ForeColor = System.Drawing.Color.White;
            this.messageText.Location = new System.Drawing.Point(56, 31);
            this.messageText.Name = "messageText";
            this.messageText.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.Vertical;
            this.messageText.Size = new System.Drawing.Size(600, 40);
            this.messageText.TabIndex = 6;
            this.messageText.TabStop = false;
            this.messageText.Text = "Cat\nmeow\ncat\nmeow\nPog\nDog\nMeow";
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(61, 4);
            // 
            // Bubble
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(45)))));
            this.Controls.Add(this.messageText);
            this.Controls.Add(this.flowLayoutPanel1);
            this.Controls.Add(this.avatarPictureBox);
            this.MinimumSize = new System.Drawing.Size(250, 70);
            this.Name = "Bubble";
            this.Size = new System.Drawing.Size(656, 70);
            ((System.ComponentModel.ISupportInitialize)(this.avatarPictureBox)).EndInit();
            this.flowLayoutPanel1.ResumeLayout(false);
            this.flowLayoutPanel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        public System.Windows.Forms.Label timeDateLabel;
        public System.Windows.Forms.PictureBox avatarPictureBox;
        public System.Windows.Forms.Label usernameLabel;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        public System.Windows.Forms.RichTextBox messageText;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
    }
}
