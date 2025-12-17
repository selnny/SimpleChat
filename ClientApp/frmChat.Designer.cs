namespace ClientApp
{
    partial class frmChat
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
            lstUsers = new ListBox();
            rtfLog = new RichTextBox();
            txtMessage = new TextBox();
            btnSend = new Button();
            label1 = new Label();
            SuspendLayout();
            // 
            // lstUsers
            // 
            lstUsers.Font = new Font("Segoe UI", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 204);
            lstUsers.FormattingEnabled = true;
            lstUsers.ItemHeight = 25;
            lstUsers.Location = new Point(12, 36);
            lstUsers.Name = "lstUsers";
            lstUsers.Size = new Size(120, 354);
            lstUsers.TabIndex = 0;
            // 
            // rtfLog
            // 
            rtfLog.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 204);
            rtfLog.Location = new Point(138, 36);
            rtfLog.Name = "rtfLog";
            rtfLog.Size = new Size(650, 365);
            rtfLog.TabIndex = 5;
            rtfLog.Text = "";
            rtfLog.TextChanged += rtfLog_TextChanged;
            // 
            // txtMessage
            // 
            txtMessage.Font = new Font("Segoe UI", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 204);
            txtMessage.Location = new Point(12, 407);
            txtMessage.Name = "txtMessage";
            txtMessage.Size = new Size(741, 33);
            txtMessage.TabIndex = 2;
            txtMessage.TextChanged += txtMessage_TextChanged;
            // 
            // btnSend
            // 
            btnSend.BackgroundImageLayout = ImageLayout.None;
            btnSend.Location = new Point(759, 406);
            btnSend.Name = "btnSend";
            btnSend.Size = new Size(29, 32);
            btnSend.TabIndex = 3;
            btnSend.Text = "->";
            btnSend.UseVisualStyleBackColor = true;
            btnSend.Click += btnSend_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 204);
            label1.Location = new Point(12, 8);
            label1.Name = "label1";
            label1.Size = new Size(58, 25);
            label1.TabIndex = 4;
            label1.Text = "Users";
            label1.Click += label1_Click;
            // 
            // frmChat
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(label1);
            Controls.Add(btnSend);
            Controls.Add(txtMessage);
            Controls.Add(rtfLog);
            Controls.Add(lstUsers);
            Name = "frmChat";
            StartPosition = FormStartPosition.CenterParent;
            Text = "Simple chat";
            Load += frmChat_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private ListBox lstUsers;
        private RichTextBox rtfLog;
        private TextBox txtMessage;
        private Button btnSend;
        private Label label1;
    }
}