using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace homework
{
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
           // MessageBox.Show(this.Size.Width + "," + this.Size.Height);
        }

        private void login_btn_Click(object sender, EventArgs e)
        {
            string user = this.user_textBox.Text.Trim();
            string passwd = this.passwd_textBox.Text;
           // MessageBox.Show(this.Size.Width + "," + this.Size.Height);
            if (!CheckUserPasswd(user, passwd))
            {
                MessageBox.Show("密码或用户名不正确!");
                return;
            }
            
            SystemConfig.User = user;
            SystemConfig.Passwd = passwd;
            this.DialogResult = DialogResult.OK;
        }

        private bool CheckUserPasswd(string user, string passwd)
        {
            string sql = string.Format(
                "select count(*) from [User] where UserName='{0}' and Password='{1}'", 
                user, passwd);

            int cnt = Convert.ToInt32(AccessDB.ExecuteScalar(sql));
            return cnt != 0;
        }

        private void Login_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (this.DialogResult != DialogResult.OK)
                System.Environment.Exit(0);
        }
    }
}
