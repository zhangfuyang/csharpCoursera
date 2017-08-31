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
    public partial class Edit : Form
    {
        public EventHandler changed;
        public string task
        {
            set
            {
                _task = value;
            }
            get
            {
                return _task;
            }
        }
        public string check
        {
            get
            {
                return _check;
            }
            set
            {
                _task = value;
            }
        }
        private string _task;
        private string _check;
        public Edit(string task, string check)
        {
            this._task = task;
            this._check = check;
            InitializeComponent();
            textBox1.Text = task;
            if (check == "已完成")
            {
                radioButton1.Checked = true;
            }
            else
                radioButton2.Checked = true;
            this.radioButton1.CheckedChanged += new System.EventHandler(this.radioButton_CheckedChanged);
            this.radioButton2.CheckedChanged += new System.EventHandler(this.radioButton_CheckedChanged);
            this.textBox1.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            _task = textBox1.Text;
            changed(this, e);
        }

        private void radioButton_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton1.Checked)
                _check = "已完成";
            else
                _check = "未完成";
            changed(this, e);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
        }
    }
}
