namespace homework
{
    partial class Login
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
            this.user_label = new System.Windows.Forms.Label();
            this.passwd_label = new System.Windows.Forms.Label();
            this.user_textBox = new System.Windows.Forms.TextBox();
            this.passwd_textBox = new System.Windows.Forms.TextBox();
            this.login_btn = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // user_label
            // 
            this.user_label.AutoSize = true;
            this.user_label.Font = new System.Drawing.Font("宋体", 14.1F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.user_label.Location = new System.Drawing.Point(389, 244);
            this.user_label.Margin = new System.Windows.Forms.Padding(8, 0, 8, 0);
            this.user_label.Name = "user_label";
            this.user_label.Size = new System.Drawing.Size(164, 48);
            this.user_label.TabIndex = 1;
            this.user_label.Text = "用户名";
            // 
            // passwd_label
            // 
            this.passwd_label.AutoSize = true;
            this.passwd_label.Font = new System.Drawing.Font("宋体", 14.1F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.passwd_label.Location = new System.Drawing.Point(389, 521);
            this.passwd_label.Margin = new System.Windows.Forms.Padding(8, 0, 8, 0);
            this.passwd_label.Name = "passwd_label";
            this.passwd_label.Size = new System.Drawing.Size(164, 48);
            this.passwd_label.TabIndex = 2;
            this.passwd_label.Text = "密  码";
            // 
            // user_textBox
            // 
            this.user_textBox.Font = new System.Drawing.Font("宋体", 14.1F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.user_textBox.Location = new System.Drawing.Point(723, 241);
            this.user_textBox.Name = "user_textBox";
            this.user_textBox.Size = new System.Drawing.Size(476, 61);
            this.user_textBox.TabIndex = 3;
            this.user_textBox.Text = "zfy";
            // 
            // passwd_textBox
            // 
            this.passwd_textBox.Font = new System.Drawing.Font("宋体", 14.1F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.passwd_textBox.Location = new System.Drawing.Point(723, 518);
            this.passwd_textBox.Name = "passwd_textBox";
            this.passwd_textBox.PasswordChar = '*';
            this.passwd_textBox.Size = new System.Drawing.Size(476, 61);
            this.passwd_textBox.TabIndex = 4;
            this.passwd_textBox.Text = "zfy";
            // 
            // login_btn
            // 
            this.login_btn.Font = new System.Drawing.Font("宋体", 15.9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.login_btn.Location = new System.Drawing.Point(591, 685);
            this.login_btn.Name = "login_btn";
            this.login_btn.Size = new System.Drawing.Size(456, 137);
            this.login_btn.TabIndex = 5;
            this.login_btn.Text = "登录";
            this.login_btn.UseVisualStyleBackColor = true;
            this.login_btn.Click += new System.EventHandler(this.login_btn_Click);
            // 
            // Login
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(15F, 30F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1704, 960);
            this.Controls.Add(this.login_btn);
            this.Controls.Add(this.passwd_textBox);
            this.Controls.Add(this.user_textBox);
            this.Controls.Add(this.passwd_label);
            this.Controls.Add(this.user_label);
            this.Name = "Login";
            this.Text = "Login";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Login_FormClosing);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label user_label;
        private System.Windows.Forms.Label passwd_label;
        private System.Windows.Forms.TextBox user_textBox;
        private System.Windows.Forms.TextBox passwd_textBox;
        private System.Windows.Forms.Button login_btn;
    }
}