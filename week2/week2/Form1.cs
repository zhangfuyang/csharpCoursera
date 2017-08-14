using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;

namespace week2
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        private int select = -1;
        private int auto = 0;
        private int autoanswer = 0;
        private int x, y;
        private int answer;
        private int result = 2;
        private static int noanswer = 3;
        private static int wrong = 2;
        private static int right = 1;
        private void Form1_Load(object sender, EventArgs e)
        {
            checkBox1.Tag = 0;
            checkBox2.Tag = 0;
            checkBox3.Tag = 0;
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            CheckBox T = (CheckBox)sender;
            if (select == -1)
            {
                checkBox2.Enabled = false;
                checkBox3.Enabled = false;
                select = 1;
            }
            else if (select == 1)
            {
                checkBox2.Enabled = true;
                checkBox3.Enabled = true;
                select = -1;
            }
        }

        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {
            CheckBox T = (CheckBox)sender;
            if (select == -1)
            {
                checkBox1.Enabled = false;
                checkBox3.Enabled = false;
                select = 2;
            }
            else if (select == 2)
            {
                checkBox1.Enabled = true;
                checkBox3.Enabled = true;
                select = -1;
            }
        }

        private void checkBox3_CheckedChanged(object sender, EventArgs e)
        {
            CheckBox T = (CheckBox)sender;
            if (select == -1)
            {
                checkBox1.Enabled = false;
                checkBox2.Enabled = false;
                select = 3;
            }
            else if (select == 3)
            {
                checkBox1.Enabled = true;
                checkBox2.Enabled = true;
                select = -1;
            }
        }

        private void checkBox4_CheckedChanged(object sender, EventArgs e)
        {
            this.auto = 1 - this.auto;
            if(auto == 0)//不是自动下一题
            {
                timer1.Enabled = false;
            }
            if (auto == 1) //自动下一题
            {
                timer1.Enabled = true;
            }
        }

        private void checkBox5_CheckedChanged(object sender, EventArgs e)
        {
            this.autoanswer = 1 - this.autoanswer;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if(timer1.Interval > 1500)
            {
                timer1.Interval -= 300;
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if(timer1.Interval < 5000)
            {
                timer1.Interval += 300;
            }
        }

        private void button1_Click(object sender, EventArgs e) //下一题按钮
        {
            next();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (autoanswer == 1)
            {
              //  Thread.Sleep(1000);
            }
            if (result == noanswer)
            {
                label3.Text = "太慢了";
                result = wrong;
                if (autoanswer == 1)
                {
                    textBox1.Text = answer + "";
                }
                return;
                
            }
            next();
            result = noanswer;
        }

        private void button4_Click(object sender, EventArgs e) //确认回答
        {
            if(autoanswer == 1)
            {
               // Thread.Sleep(1000);
            }
            try
            {
                if (Convert.ToInt32(textBox1.Text) == answer)
                {
                    label3.Text = "对了";
                    result = right;
                }
                else
                {
                    label3.Text = "错了";
                    result = wrong;
                }
                if (autoanswer == 1)
                {
                    textBox1.Text = "答案是" + answer;              
                }
            }
            catch
            {
                MessageBox.Show("输入有误");
            }
        }

        private void next()  //下一题
        {
            textBox1.Text = "";
            label3.Text = "";
            Random rand = new Random();
            if(select == -1)
            {
                MessageBox.Show("请选择出题类型!");
            }
            if(select == 1) //10以内加减法
            {
                int mode;
                mode = rand.Next(2);
                if (mode == 0) // +
                {
                    answer = rand.Next(10);
                    x = rand.Next(answer);
                    y = answer - x;
                    label2.Text = x + "+" + y + "=";
                }
                else //-
                {
                    x = rand.Next(10);
                    answer = rand.Next(x);
                    y = x - answer;
                    label2.Text = x + "-" + y + "=";
                }
            }
            if(select == 2) //20以内
            {
                int mode;
                mode = rand.Next(2);
                if (mode == 0) // +
                {
                    answer = rand.Next(20);
                    x = rand.Next(answer);
                    y = answer - x;
                    label2.Text = x + "+" + y + "=";
                }
                else //-
                {
                    x = rand.Next(20);
                    answer = rand.Next(x);
                    y = x - answer;
                    label2.Text = x + "-" + y + "=";
                }
            }
            if (select == 3) //乘法
            {
                x = rand.Next(10);
                y = rand.Next(10);
                answer = x * y;
                label2.Text = x + "*" + y + "=";
            }
        }
    }
}
