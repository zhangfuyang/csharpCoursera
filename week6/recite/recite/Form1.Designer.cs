namespace recite
{
    partial class Form1
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.next_btn = new System.Windows.Forms.Button();
            this.last_btn = new System.Windows.Forms.Button();
            this.showEng_btn = new System.Windows.Forms.Button();
            this.showChinese_btn = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.label2 = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.richTextBox2 = new System.Windows.Forms.RichTextBox();
            this.richTextBox1 = new System.Windows.Forms.RichTextBox();
            this.leadingin = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // next_btn
            // 
            this.next_btn.FlatAppearance.BorderSize = 0;
            this.next_btn.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.next_btn.Location = new System.Drawing.Point(112, 594);
            this.next_btn.Name = "next_btn";
            this.next_btn.Size = new System.Drawing.Size(267, 140);
            this.next_btn.TabIndex = 0;
            this.next_btn.Text = "下一个";
            this.next_btn.UseVisualStyleBackColor = true;
            this.next_btn.Click += new System.EventHandler(this.next_btn_Click);
            // 
            // last_btn
            // 
            this.last_btn.FlatAppearance.BorderSize = 0;
            this.last_btn.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.last_btn.Location = new System.Drawing.Point(462, 594);
            this.last_btn.Name = "last_btn";
            this.last_btn.Size = new System.Drawing.Size(267, 140);
            this.last_btn.TabIndex = 1;
            this.last_btn.Text = "上一个";
            this.last_btn.UseVisualStyleBackColor = true;
            this.last_btn.Click += new System.EventHandler(this.last_btn_Click);
            // 
            // showEng_btn
            // 
            this.showEng_btn.BackColor = System.Drawing.SystemColors.Control;
            this.showEng_btn.Cursor = System.Windows.Forms.Cursors.Default;
            this.showEng_btn.FlatAppearance.BorderSize = 0;
            this.showEng_btn.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.showEng_btn.ForeColor = System.Drawing.SystemColors.ControlText;
            this.showEng_btn.Location = new System.Drawing.Point(829, 594);
            this.showEng_btn.Name = "showEng_btn";
            this.showEng_btn.Size = new System.Drawing.Size(267, 140);
            this.showEng_btn.TabIndex = 2;
            this.showEng_btn.Text = "显示英文";
            this.showEng_btn.UseVisualStyleBackColor = false;
            this.showEng_btn.Click += new System.EventHandler(this.showEng_btn_Click);
            // 
            // showChinese_btn
            // 
            this.showChinese_btn.FlatAppearance.BorderSize = 0;
            this.showChinese_btn.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.showChinese_btn.Location = new System.Drawing.Point(1175, 594);
            this.showChinese_btn.Name = "showChinese_btn";
            this.showChinese_btn.Size = new System.Drawing.Size(267, 140);
            this.showChinese_btn.TabIndex = 3;
            this.showChinese_btn.Text = "显示中文";
            this.showChinese_btn.UseVisualStyleBackColor = true;
            this.showChinese_btn.Click += new System.EventHandler(this.showChinese_btn_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(498, 785);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(133, 30);
            this.label1.TabIndex = 4;
            this.label1.Text = "自动浏览";
            // 
            // checkBox1
            // 
            this.checkBox1.AutoSize = true;
            this.checkBox1.Location = new System.Drawing.Point(637, 785);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(34, 33);
            this.checkBox1.TabIndex = 5;
            this.checkBox1.UseVisualStyleBackColor = true;
            this.checkBox1.CheckedChanged += new System.EventHandler(this.checkBox1_CheckedChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(755, 788);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(133, 30);
            this.label2.TabIndex = 6;
            this.label2.Text = "浏览间隔";
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(894, 782);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(100, 42);
            this.textBox1.TabIndex = 7;
            this.textBox1.Text = "3";
            this.textBox1.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(1000, 788);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(43, 30);
            this.label3.TabIndex = 8;
            this.label3.Text = "秒";
            // 
            // timer1
            // 
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(1000, 831);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(673, 30);
            this.label6.TabIndex = 12;
            this.label6.Text = "中文(英文)未显示的情况下，单击文本框可以显示";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("宋体", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label5.Location = new System.Drawing.Point(1182, 41);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(122, 50);
            this.label5.TabIndex = 16;
            this.label5.Text = "中文";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("宋体", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label4.Location = new System.Drawing.Point(365, 41);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(122, 50);
            this.label4.TabIndex = 15;
            this.label4.Text = "英文";
            // 
            // richTextBox2
            // 
            this.richTextBox2.Location = new System.Drawing.Point(870, 117);
            this.richTextBox2.Name = "richTextBox2";
            this.richTextBox2.Size = new System.Drawing.Size(723, 435);
            this.richTextBox2.TabIndex = 14;
            this.richTextBox2.Text = "";
            this.richTextBox2.Click += new System.EventHandler(this.richTextBox2_Click);
            // 
            // richTextBox1
            // 
            this.richTextBox1.Location = new System.Drawing.Point(87, 117);
            this.richTextBox1.Name = "richTextBox1";
            this.richTextBox1.Size = new System.Drawing.Size(723, 435);
            this.richTextBox1.TabIndex = 13;
            this.richTextBox1.Text = "";
            this.richTextBox1.Click += new System.EventHandler(this.richTextBox1_Click);
            // 
            // leadingin
            // 
            this.leadingin.Location = new System.Drawing.Point(12, 12);
            this.leadingin.Name = "leadingin";
            this.leadingin.Size = new System.Drawing.Size(255, 69);
            this.leadingin.TabIndex = 17;
            this.leadingin.Text = "导入词库";
            this.leadingin.UseVisualStyleBackColor = true;
            this.leadingin.Click += new System.EventHandler(this.leadingin_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(15F, 30F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.ClientSize = new System.Drawing.Size(1731, 898);
            this.Controls.Add(this.leadingin);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.richTextBox2);
            this.Controls.Add(this.richTextBox1);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.checkBox1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.showChinese_btn);
            this.Controls.Add(this.showEng_btn);
            this.Controls.Add(this.last_btn);
            this.Controls.Add(this.next_btn);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button next_btn;
        private System.Windows.Forms.Button last_btn;
        private System.Windows.Forms.Button showEng_btn;
        private System.Windows.Forms.Button showChinese_btn;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.CheckBox checkBox1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.RichTextBox richTextBox2;
        private System.Windows.Forms.RichTextBox richTextBox1;
        private System.Windows.Forms.Button leadingin;
    }
}

