using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace recite
{
    public partial class Form1 : Form
    {
        string path;
        string filename;
        List<string> En = new List<string>();
        List<string> Ch = new List<string>();
        bool addin = false; //是否完成导入
        int index = -1; //表示第几个单词
        bool show_english = false;
        bool show_chinese = false;

        public Form1()
        {
            InitializeComponent();
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (timer1.Enabled == true)
                timer1.Enabled = false;
            else
            {
                timer1.Enabled = true;
                
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            next_btn_Click(sender, e);
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void leadingin_Click(object sender, EventArgs e)
        {
            //定义一个文件打开控件
            OpenFileDialog ofd = new OpenFileDialog();
            //设置打开对话框的初始目录，默认目录为exe运行文件所在的路径
            ofd.InitialDirectory = Application.StartupPath;
            //设置打开对话框的标题
            ofd.Title = "请选择要打开的文件";
            //设置打开对话框可以多选
            ofd.Multiselect = true;
            //设置对话框打开的文件类型
            ofd.Filter = "文本文件|*.txt|所有文件|*.*";
            //设置文件对话框当前选定的筛选器的索引
            ofd.FilterIndex = 1;
            //设置对话框是否记忆之前打开的目录
            ofd.RestoreDirectory = true;
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                En.Clear();
                Ch.Clear();
                //获取用户选择的文件完整路径
                string filePath = ofd.FileName;
                //获取对话框中所选文件的文件名和扩展名，文件名不包括路径
                string fileName = ofd.SafeFileName;
                this.path = filePath;
                this.Name = fileName;
                Console.WriteLine("用户选择的文件目录为:" + filePath);

                Console.WriteLine("用户选择的文件名称为:" + fileName);

                //Console.WriteLine("**************选中文件的内容**************");
                FileStream fsRead = new FileStream(filePath, FileMode.Open, FileAccess.Read);
                StreamReader Read = new StreamReader(fsRead, System.Text.Encoding.Default);
                try
                {
                    string s = Read.ReadLine();
                    while (s != null)
                    {
                        string[] temp = s.Trim().Split('\t');
                        this.En.Add(temp[0]);
                        this.Ch.Add(temp[1]);
                        s = Read.ReadLine();
                    }
                    this.addin = true;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("数据出现问题:" + ex.Message);
                    this.addin = false;
                    En.Clear();
                    Ch.Clear();
                }
                finally
                {
                    Read.Close();
                }
                //{
                //    //定义二进制数组
                //    byte[] buffer = new byte[1024 * 1024 * 5];
                //    //从流中读取字节
                //    int r = fsRead.Read(buffer, 0, buffer.Length);
                //    Console.WriteLine(Encoding.Default.GetString(buffer, 0, r));
                //}
            }
        }

        private void next_btn_Click(object sender, EventArgs e)
        {
            if (addin == false)
            {
                MessageBox.Show("请先导入词库");
                return;
            }
            show_word(this.show_english, this.show_chinese, ++this.index);
        }
        
        private void show_word(bool show_english, bool show_chinese, int index)
        {
            if(addin == false)
            {
        //        MessageBox.Show("请先导入词库");
                return;
            }
            if(index < 0)
            {
                MessageBox.Show("已经是第一个单词了");
                this.index = 0;
                return;
            }
            if(index >= En.Count)
            {
                MessageBox.Show("已经是最后一个单词了");
                this.index = En.Count - 1;
                return;
            }
            if (show_english == true)
            {
                richTextBox1.Text = En[index];
            }
            else
                richTextBox1.Text = "点击文本框以显示英文";

            if (show_chinese == true)
            {
                richTextBox2.Text = Ch[index];
            }
            else
                richTextBox2.Text = "点击文本框以显示中文";
        }

        private void last_btn_Click(object sender, EventArgs e)
        {
            if (addin == false)
            {
                MessageBox.Show("请先导入词库");
                return;
            }
            show_word(this.show_english, this.show_chinese, --this.index);
        }

        private void richTextBox1_Click(object sender, EventArgs e)
        {
            if(this.show_english == false)
                show_word(true, this.show_chinese, this.index);
        }

        private void richTextBox2_Click(object sender, EventArgs e)
        {
            if (this.show_chinese == false)
                show_word(this.show_english, true, this.index);
        }

        private void showEng_btn_Click(object sender, EventArgs e)
        {
            if (show_english == false)
            {
                show_english = true;
                this.showEng_btn.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            }
            else
            {
                show_english = false;
                this.showEng_btn.BackColor = System.Drawing.SystemColors.Control;
            }
            show_word(this.show_english, this.show_chinese, this.index);
        }

        private void showChinese_btn_Click(object sender, EventArgs e)
        {
            if (show_chinese == false)
            {
                show_chinese = true;
                this.showChinese_btn.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            }
            else
            {
                show_chinese = false;
                this.showChinese_btn.BackColor = System.Drawing.SystemColors.Control;
            }
            show_word(this.show_english, this.show_chinese, this.index);
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            try
            {
                double t = Double.Parse(textBox1.Text);
                Console.WriteLine(t);
                timer1.Interval = ((int)t) * 1000;
            }
            catch
            {
                timer1.Interval = 3000;
            }
        }
    }

}
