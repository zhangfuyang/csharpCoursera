namespace Get利用百度搜索引擎
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
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txtKeyword = new System.Windows.Forms.TextBox();
            this.btnBaiduSearch = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.webBrowserContent = new System.Windows.Forms.WebBrowser();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.richTextBoxCode = new System.Windows.Forms.RichTextBox();
            this.btnGoogleSearch = new System.Windows.Forms.Button();
            this.groupBox2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(230, 33);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(137, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "利用百度搜索需要的信息";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 71);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(89, 12);
            this.label2.TabIndex = 1;
            this.label2.Text = "输入搜索关键字";
            // 
            // txtKeyword
            // 
            this.txtKeyword.Location = new System.Drawing.Point(107, 68);
            this.txtKeyword.Name = "txtKeyword";
            this.txtKeyword.Size = new System.Drawing.Size(613, 21);
            this.txtKeyword.TabIndex = 2;
            this.txtKeyword.Text = "图片";
            // 
            // btnBaiduSearch
            // 
            this.btnBaiduSearch.Location = new System.Drawing.Point(436, 28);
            this.btnBaiduSearch.Name = "btnBaiduSearch";
            this.btnBaiduSearch.Size = new System.Drawing.Size(75, 23);
            this.btnBaiduSearch.TabIndex = 3;
            this.btnBaiduSearch.Text = "百度搜索";
            this.btnBaiduSearch.UseVisualStyleBackColor = true;
            this.btnBaiduSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.webBrowserContent);
            this.groupBox2.Location = new System.Drawing.Point(334, 95);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(522, 342);
            this.groupBox2.TabIndex = 5;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "网页内容";
            // 
            // webBrowserContent
            // 
            this.webBrowserContent.Dock = System.Windows.Forms.DockStyle.Fill;
            this.webBrowserContent.Location = new System.Drawing.Point(3, 17);
            this.webBrowserContent.MinimumSize = new System.Drawing.Size(20, 20);
            this.webBrowserContent.Name = "webBrowserContent";
            this.webBrowserContent.Size = new System.Drawing.Size(516, 322);
            this.webBrowserContent.TabIndex = 0;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.richTextBoxCode);
            this.groupBox1.Location = new System.Drawing.Point(15, 95);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(274, 306);
            this.groupBox1.TabIndex = 6;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "返回的源代码";
            // 
            // richTextBoxCode
            // 
            this.richTextBoxCode.Location = new System.Drawing.Point(3, 17);
            this.richTextBoxCode.Name = "richTextBoxCode";
            this.richTextBoxCode.Size = new System.Drawing.Size(300, 322);
            this.richTextBoxCode.TabIndex = 0;
            this.richTextBoxCode.Text = "";
            // 
            // btnGoogleSearch
            // 
            this.btnGoogleSearch.Location = new System.Drawing.Point(560, 28);
            this.btnGoogleSearch.Name = "btnGoogleSearch";
            this.btnGoogleSearch.Size = new System.Drawing.Size(75, 23);
            this.btnGoogleSearch.TabIndex = 7;
            this.btnGoogleSearch.Text = "谷歌搜索";
            this.btnGoogleSearch.UseVisualStyleBackColor = true;
            this.btnGoogleSearch.Click += new System.EventHandler(this.btnGoogleSearch_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(868, 438);
            this.Controls.Add(this.btnGoogleSearch);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.btnBaiduSearch);
            this.Controls.Add(this.txtKeyword);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "Form1";
            this.Text = "Get请求示例";
            this.groupBox2.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtKeyword;
        private System.Windows.Forms.Button btnBaiduSearch;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.WebBrowser webBrowserContent;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RichTextBox richTextBoxCode;
        private System.Windows.Forms.Button btnGoogleSearch;
    }
}

