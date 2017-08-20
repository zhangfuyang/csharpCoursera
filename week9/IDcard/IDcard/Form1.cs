using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Text.RegularExpressions;

namespace IDcard
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string pattern = @"^(?<num>[\d]{17})(?<id>[xX\d]$)";
            Regex rx = new Regex(pattern);
            Match m = rx.Match(textBox1.Text);
            if(!m.Success)
            {
                MessageBox.Show("无效身份证号码");
                return;
            }
            int[] nums = new int[18];
            for (int i = 17; i > 0; i--)
            {
                nums[i] = m.Result("${num}")[17-i]-'0';
            }
            int[] xishu = { -1, 2, 4, 8, 5, 10, 9, 7, 3, 6, 1, 2, 4, 8, 5, 10, 9, 7};
            int sum = 0;
            for (int i = 1; i <=17; i++)
            {
                sum += nums[i] * xishu[i];
            }
            sum = sum % 11;
            sum = (12 - sum) % 11;
            if(sum == 10)
            {
                if(m.Result("${id}") == "X" || m.Result("${id}") == "x")
                {
                    MessageBox.Show("身份证号码有效!");
                }
                else
                    MessageBox.Show("无效身份证号码");
            }
            else
            {
                if(sum.ToString() == m.Result("${id}"))
                    MessageBox.Show("身份证号码有效!");
                else
                    MessageBox.Show("无效身份证号码");
            }
        }
    }
}
