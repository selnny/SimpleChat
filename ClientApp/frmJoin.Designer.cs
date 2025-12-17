namespace ClientApp
{
    partial class frmJoin
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            btnJoin = new Button();
            label1 = new Label();
            txtUsername = new TextBox();
            SuspendLayout();
            // 
            // btnJoin
            // 
            btnJoin.Font = new Font("Segoe UI", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 204);
            btnJoin.Location = new Point(348, 85);
            btnJoin.Name = "btnJoin";
            btnJoin.Size = new Size(104, 33);
            btnJoin.TabIndex = 0;
            btnJoin.Text = "Continue";
            btnJoin.UseVisualStyleBackColor = true;
            btnJoin.Click += btnJoin_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 204);
            label1.Location = new Point(12, 34);
            label1.Name = "label1";
            label1.Size = new Size(101, 25);
            label1.TabIndex = 1;
            label1.Text = "Username:";
            label1.Click += label1_Click;
            // 
            // txtUsername
            // 
            txtUsername.Font = new Font("Segoe UI", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 204);
            txtUsername.Location = new Point(133, 34);
            txtUsername.Name = "txtUsername";
            txtUsername.Size = new Size(319, 33);
            txtUsername.TabIndex = 2;
            // 
            // frmJoin
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(492, 130);
            Controls.Add(txtUsername);
            Controls.Add(label1);
            Controls.Add(btnJoin);
            Name = "frmJoin";
            Text = "Form1";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button btnJoin;
        private Label label1;
        private TextBox txtUsername;
    }
}
