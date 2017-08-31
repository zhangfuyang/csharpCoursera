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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            this.Hide();
            Login login = new Login();
            login.ShowDialog();
            this.Show();
            DataLoad();
            //MessageBox.Show(Task_listbox.Size.Height + "," + Task_listbox.Size.Width);
        }

        private void DataLoad()
        {
            string sql = string.Format("select task, checked from [{0}]",SystemConfig.User);
            DataSet ds = AccessDB.GetDataSet(sql);
            foreach (DataRow mDr in ds.Tables[0].Rows)
            {
                //if (mDr[SystemConfig.User + "Checked"].ToString() == "0")
                //    Task_listbox.ForeColor = System.Drawing.Color.Red;
                //else
                //    Task_listbox.ForeColor = System.Drawing.SystemColors.WindowText;
                string text;
                text = mDr["task"].ToString();
                if (text == "")
                    continue;
                if (mDr["checked"].ToString() == "0")
                {
                    text += "\t\t未完成";
                }
                else
                    text += "\t\t已完成";
                Task_listbox.Items.Add(text);
            }
        }

        private void Task_listbox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (Task_listbox.SelectedIndex < 0)
                return;
            string text = this.Task_listbox.SelectedItem.ToString();
            string[] str = text.Trim().Split('\t');
            this.check.Text = str[2];
        }

        private void delete_Click(object sender, EventArgs e)
        {
            string text = this.Task_listbox.SelectedItem.ToString();
            int x;
            int t;
            string[] str = text.Trim().Split('\t');
            if (str[2] == "已完成")
                t = 1;
            else
                t = 0;
            string sql = string.Format("delete from [{0}] where task = '{1}'",
                SystemConfig.User, str[0]);
            x = AccessDB.ExecuteNonQuery(sql);
            Task_listbox.Items.Remove(Task_listbox.SelectedItem);
        }

        private void add_Click(object sender, EventArgs e)
        {
            Add addtask = new Add();
            addtask.ShowDialog(); 
            if(SystemConfig.New)
            {
                string t;
                if (SystemConfig.check)
                {
                    Task_listbox.Items.Add(SystemConfig.Task + "\t\t已完成");
                    t = "1";
                }
                else
                {
                    t = "0";
                    Task_listbox.Items.Add(SystemConfig.Task + "\t\t未完成");
                }
                int x;
                string sql;
                sql = string.Format("insert into [{0}] (task, checked) VALUES ('{1}', '{2}')",SystemConfig.User, SystemConfig.Task, t);
                x = AccessDB.ExecuteNonQuery(sql);
             //   sql = string.Format("insert into [Tip] ({0}, {1}Checked) VALUES ('-1', '-1')", SystemConfig.User, SystemConfig.User);
               // x = AccessDB.ExecuteNonQuery(sql);
            }
        }

        private void edit_Click(object sender, EventArgs e)
        {
            string text = this.Task_listbox.SelectedItem.ToString();
            string ch;
            string text2;
            int x;
            string[] str = text.Trim().Split('\t');
            ch = str[2];
            text2 = str[0];
            Edit edit = new Edit(str[0], str[2]);
            edit.changed += new EventHandler(
                (sender1, e1) =>
                { text2 = edit.task;  ch = edit.check; }
                );
            edit.ShowDialog();
            if(ch != str[2] || text2!=str[0])
            {
                string sql = string.Format("update [{0}] set task = '{1}', checked = '{2}' where task = '{3}'",
                    SystemConfig.User, text2, ((ch == "已完成")?1:0).ToString(), str[0]);
                x = AccessDB.ExecuteNonQuery(sql);
                Task_listbox.Items[this.Task_listbox.SelectedIndex] = text2 + "\t\t" + ch;
            }
        }

        private void moveup_Click(object sender, EventArgs e)
        {
            if (this.Task_listbox.SelectedIndex == 0)
                return;
            string a;
            a = Task_listbox.Items[this.Task_listbox.SelectedIndex].ToString();
            Task_listbox.Items[this.Task_listbox.SelectedIndex] = Task_listbox.Items[this.Task_listbox.SelectedIndex - 1];
            Task_listbox.Items[this.Task_listbox.SelectedIndex - 1] = a;
        }

        private void movedown_Click(object sender, EventArgs e)
        {
            if (this.Task_listbox.SelectedIndex == this.Task_listbox.Items.Count - 1)
                return;
            string a;
            a = Task_listbox.Items[this.Task_listbox.SelectedIndex].ToString();
            Task_listbox.Items[this.Task_listbox.SelectedIndex] = Task_listbox.Items[this.Task_listbox.SelectedIndex + 1];
            Task_listbox.Items[this.Task_listbox.SelectedIndex + 1] = a;
        }
    }
}
