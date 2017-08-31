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
    public partial class Add : Form
    {
        string task;
        bool check;
        public Add()
        {
            SystemConfig.New = false;
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            task = textBox1.Text;
            if (radioButton1.Checked)
                check = true;
            if (radioButton2.Checked)
                check = false;
            SystemConfig.check = this.check;
            SystemConfig.Task = this.task;
            SystemConfig.New = true;
            this.DialogResult = DialogResult.OK;
        }
    }
}
