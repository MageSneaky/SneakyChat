namespace SneakyChat.Client
{
    partial class Main
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Main));
            this.sendButton = new System.Windows.Forms.Button();
            this.connectionLabel = new System.Windows.Forms.Label();
            this.messageText = new System.Windows.Forms.RichTextBox();
            this.usernameLabel = new System.Windows.Forms.Label();
            this.messagesLayout = new System.Windows.Forms.TableLayoutPanel();
            this.aboutButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // sendButton
            // 
            this.sendButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.sendButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(60)))), ((int)(((byte)(60)))));
            this.sendButton.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.sendButton.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(70)))), ((int)(((byte)(70)))), ((int)(((byte)(70)))));
            this.sendButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.sendButton.Location = new System.Drawing.Point(594, 314);
            this.sendButton.Name = "sendButton";
            this.sendButton.Size = new System.Drawing.Size(98, 45);
            this.sendButton.TabIndex = 1;
            this.sendButton.Text = "Send";
            this.sendButton.UseVisualStyleBackColor = false;
            this.sendButton.Click += new System.EventHandler(this.sendButton_Click);
            // 
            // connectionLabel
            // 
            this.connectionLabel.AutoSize = true;
            this.connectionLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.connectionLabel.ForeColor = System.Drawing.Color.Red;
            this.connectionLabel.Location = new System.Drawing.Point(12, 9);
            this.connectionLabel.Name = "connectionLabel";
            this.connectionLabel.Size = new System.Drawing.Size(107, 20);
            this.connectionLabel.TabIndex = 2;
            this.connectionLabel.Text = "Disconnected";
            // 
            // messageText
            // 
            this.messageText.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.messageText.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(60)))), ((int)(((byte)(60)))));
            this.messageText.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.messageText.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.messageText.ForeColor = System.Drawing.Color.White;
            this.messageText.Location = new System.Drawing.Point(12, 314);
            this.messageText.Name = "messageText";
            this.messageText.Size = new System.Drawing.Size(576, 45);
            this.messageText.TabIndex = 3;
            this.messageText.Text = "";
            this.messageText.KeyDown += new System.Windows.Forms.KeyEventHandler(this.messageText_KeyDown);
            // 
            // usernameLabel
            // 
            this.usernameLabel.BackColor = System.Drawing.Color.Transparent;
            this.usernameLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.usernameLabel.Location = new System.Drawing.Point(96, 10);
            this.usernameLabel.Name = "usernameLabel";
            this.usernameLabel.Size = new System.Drawing.Size(491, 20);
            this.usernameLabel.TabIndex = 4;
            // 
            // messagesLayout
            // 
            this.messagesLayout.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
            | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.messagesLayout.AutoScroll = true;
            this.messagesLayout.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.messagesLayout.ColumnCount = 1;
            this.messagesLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.messagesLayout.Location = new System.Drawing.Point(16, 33);
            this.messagesLayout.Name = "messagesLayout";
            this.messagesLayout.RowCount = 1;
            this.messagesLayout.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.messagesLayout.Size = new System.Drawing.Size(676, 275);
            this.messagesLayout.TabIndex = 5;
            // 
            // aboutButton
            // 
            this.aboutButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.aboutButton.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("aboutButton.BackgroundImage")));
            this.aboutButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.aboutButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.aboutButton.FlatAppearance.BorderSize = 0;
            this.aboutButton.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(80)))), ((int)(((byte)(80)))), ((int)(((byte)(80)))));
            this.aboutButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.aboutButton.Location = new System.Drawing.Point(662, 3);
            this.aboutButton.Name = "aboutButton";
            this.aboutButton.Size = new System.Drawing.Size(30, 30);
            this.aboutButton.TabIndex = 7;
            this.aboutButton.UseVisualStyleBackColor = true;
            this.aboutButton.Click += new System.EventHandler(this.aboutButton_Click);
            // 
            // Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.ClientSize = new System.Drawing.Size(704, 369);
            this.Controls.Add(this.aboutButton);
            this.Controls.Add(this.messagesLayout);
            this.Controls.Add(this.connectionLabel);
            this.Controls.Add(this.usernameLabel);
            this.Controls.Add(this.messageText);
            this.Controls.Add(this.sendButton);
            this.ForeColor = System.Drawing.Color.White;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MinimumSize = new System.Drawing.Size(720, 408);
            this.Name = "Main";
            this.Text = "Chat";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Main_FormClosing);
            this.Load += new System.EventHandler(this.Main_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button sendButton;
        private System.Windows.Forms.Label connectionLabel;
        private System.Windows.Forms.RichTextBox messageText;
        private System.Windows.Forms.Label usernameLabel;
        private System.Windows.Forms.TableLayoutPanel messagesLayout;
        private System.Windows.Forms.Button aboutButton;
    }
}

