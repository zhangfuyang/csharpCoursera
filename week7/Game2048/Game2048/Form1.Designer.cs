namespace Game2048
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
            this.pnlBoard = new System.Windows.Forms.Panel();
            this.score_panel = new System.Windows.Forms.Panel();
            this.score_label = new System.Windows.Forms.Label();
            this.score_textBox = new System.Windows.Forms.TextBox();
            this.mode_panel = new System.Windows.Forms.Panel();
            this.mode_groupBox = new System.Windows.Forms.GroupBox();
            this.mode4 = new System.Windows.Forms.RadioButton();
            this.mode3 = new System.Windows.Forms.RadioButton();
            this.mode2 = new System.Windows.Forms.RadioButton();
            this.mode1 = new System.Windows.Forms.RadioButton();
            this.highest_panel = new System.Windows.Forms.Panel();
            this.highest_label = new System.Windows.Forms.Label();
            this.hightpoint = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.up = new System.Windows.Forms.Button();
            this.left = new System.Windows.Forms.Button();
            this.right = new System.Windows.Forms.Button();
            this.down = new System.Windows.Forms.Button();
            this.score_panel.SuspendLayout();
            this.mode_panel.SuspendLayout();
            this.mode_groupBox.SuspendLayout();
            this.highest_panel.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlBoard
            // 
            this.pnlBoard.Location = new System.Drawing.Point(30, 232);
            this.pnlBoard.Margin = new System.Windows.Forms.Padding(8);
            this.pnlBoard.Name = "pnlBoard";
            this.pnlBoard.Size = new System.Drawing.Size(690, 682);
            this.pnlBoard.TabIndex = 0;
            // 
            // score_panel
            // 
            this.score_panel.Controls.Add(this.score_label);
            this.score_panel.Controls.Add(this.score_textBox);
            this.score_panel.Location = new System.Drawing.Point(749, 33);
            this.score_panel.Name = "score_panel";
            this.score_panel.Size = new System.Drawing.Size(229, 171);
            this.score_panel.TabIndex = 1;
            // 
            // score_label
            // 
            this.score_label.AutoSize = true;
            this.score_label.Font = new System.Drawing.Font("宋体", 21.9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.score_label.Location = new System.Drawing.Point(23, 7);
            this.score_label.Name = "score_label";
            this.score_label.Size = new System.Drawing.Size(178, 73);
            this.score_label.TabIndex = 1;
            this.score_label.Text = "得分";
            // 
            // score_textBox
            // 
            this.score_textBox.Font = new System.Drawing.Font("宋体", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.score_textBox.Location = new System.Drawing.Point(22, 83);
            this.score_textBox.Name = "score_textBox";
            this.score_textBox.Size = new System.Drawing.Size(179, 76);
            this.score_textBox.TabIndex = 0;
            this.score_textBox.Text = "0";
            // 
            // mode_panel
            // 
            this.mode_panel.Controls.Add(this.mode_groupBox);
            this.mode_panel.Location = new System.Drawing.Point(30, 33);
            this.mode_panel.Name = "mode_panel";
            this.mode_panel.Size = new System.Drawing.Size(328, 171);
            this.mode_panel.TabIndex = 2;
            // 
            // mode_groupBox
            // 
            this.mode_groupBox.Controls.Add(this.mode4);
            this.mode_groupBox.Controls.Add(this.mode3);
            this.mode_groupBox.Controls.Add(this.mode2);
            this.mode_groupBox.Controls.Add(this.mode1);
            this.mode_groupBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.mode_groupBox.Font = new System.Drawing.Font("宋体", 14.1F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.mode_groupBox.Location = new System.Drawing.Point(0, 0);
            this.mode_groupBox.Name = "mode_groupBox";
            this.mode_groupBox.Size = new System.Drawing.Size(328, 171);
            this.mode_groupBox.TabIndex = 2;
            this.mode_groupBox.TabStop = false;
            this.mode_groupBox.Text = "模式";
            // 
            // mode4
            // 
            this.mode4.AutoSize = true;
            this.mode4.Font = new System.Drawing.Font("宋体", 14.1F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.mode4.Location = new System.Drawing.Point(165, 120);
            this.mode4.Name = "mode4";
            this.mode4.Size = new System.Drawing.Size(153, 52);
            this.mode4.TabIndex = 3;
            this.mode4.Text = "军衔";
            this.mode4.UseVisualStyleBackColor = true;
            this.mode4.CheckedChanged += new System.EventHandler(this.mode_CheckedChanged);
            // 
            // mode3
            // 
            this.mode3.AutoSize = true;
            this.mode3.Font = new System.Drawing.Font("宋体", 14.1F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.mode3.Location = new System.Drawing.Point(6, 120);
            this.mode3.Name = "mode3";
            this.mode3.Size = new System.Drawing.Size(153, 52);
            this.mode3.TabIndex = 2;
            this.mode3.Text = "官衔";
            this.mode3.UseVisualStyleBackColor = true;
            this.mode3.CheckedChanged += new System.EventHandler(this.mode_CheckedChanged);
            // 
            // mode2
            // 
            this.mode2.AutoSize = true;
            this.mode2.Font = new System.Drawing.Font("宋体", 14.1F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.mode2.Location = new System.Drawing.Point(165, 62);
            this.mode2.Name = "mode2";
            this.mode2.Size = new System.Drawing.Size(153, 52);
            this.mode2.TabIndex = 1;
            this.mode2.Text = "朝代";
            this.mode2.UseVisualStyleBackColor = true;
            this.mode2.CheckedChanged += new System.EventHandler(this.mode_CheckedChanged);
            // 
            // mode1
            // 
            this.mode1.AutoSize = true;
            this.mode1.Checked = true;
            this.mode1.Font = new System.Drawing.Font("宋体", 14.1F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.mode1.Location = new System.Drawing.Point(6, 62);
            this.mode1.Name = "mode1";
            this.mode1.Size = new System.Drawing.Size(153, 52);
            this.mode1.TabIndex = 0;
            this.mode1.TabStop = true;
            this.mode1.Text = "传统";
            this.mode1.UseVisualStyleBackColor = true;
            this.mode1.CheckedChanged += new System.EventHandler(this.mode_CheckedChanged);
            // 
            // highest_panel
            // 
            this.highest_panel.Controls.Add(this.hightpoint);
            this.highest_panel.Location = new System.Drawing.Point(491, 33);
            this.highest_panel.Name = "highest_panel";
            this.highest_panel.Size = new System.Drawing.Size(229, 171);
            this.highest_panel.TabIndex = 2;
            // 
            // highest_label
            // 
            this.highest_label.AutoSize = true;
            this.highest_label.Font = new System.Drawing.Font("宋体", 21.9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.highest_label.Location = new System.Drawing.Point(478, 40);
            this.highest_label.Name = "highest_label";
            this.highest_label.Size = new System.Drawing.Size(251, 73);
            this.highest_label.TabIndex = 1;
            this.highest_label.Text = "最高分";
            // 
            // hightpoint
            // 
            this.hightpoint.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)));
            this.hightpoint.AutoSize = true;
            this.hightpoint.Font = new System.Drawing.Font("宋体", 21.9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.hightpoint.Location = new System.Drawing.Point(3, 86);
            this.hightpoint.Name = "hightpoint";
            this.hightpoint.Size = new System.Drawing.Size(69, 73);
            this.hightpoint.TabIndex = 3;
            this.hightpoint.Text = "0";
            // 
            // button1
            // 
            this.button1.Font = new System.Drawing.Font("宋体", 15.9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.button1.Location = new System.Drawing.Point(731, 265);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(266, 189);
            this.button1.TabIndex = 3;
            this.button1.Text = "重新开始";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // up
            // 
            this.up.Location = new System.Drawing.Point(819, 514);
            this.up.Name = "up";
            this.up.Size = new System.Drawing.Size(87, 75);
            this.up.TabIndex = 4;
            this.up.Text = "上";
            this.up.UseVisualStyleBackColor = true;
            this.up.Click += new System.EventHandler(this.up_Click);
            // 
            // left
            // 
            this.left.Location = new System.Drawing.Point(731, 602);
            this.left.Name = "left";
            this.left.Size = new System.Drawing.Size(87, 75);
            this.left.TabIndex = 5;
            this.left.Text = "左";
            this.left.UseVisualStyleBackColor = true;
            this.left.Click += new System.EventHandler(this.left_Click);
            // 
            // right
            // 
            this.right.Location = new System.Drawing.Point(910, 602);
            this.right.Name = "right";
            this.right.Size = new System.Drawing.Size(87, 75);
            this.right.TabIndex = 6;
            this.right.Text = "右";
            this.right.UseVisualStyleBackColor = true;
            this.right.Click += new System.EventHandler(this.right_Click);
            // 
            // down
            // 
            this.down.Location = new System.Drawing.Point(819, 693);
            this.down.Name = "down";
            this.down.Size = new System.Drawing.Size(87, 75);
            this.down.TabIndex = 7;
            this.down.Text = "下";
            this.down.UseVisualStyleBackColor = true;
            this.down.Click += new System.EventHandler(this.down_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(15F, 30F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.ClientSize = new System.Drawing.Size(1026, 1145);
            this.Controls.Add(this.down);
            this.Controls.Add(this.right);
            this.Controls.Add(this.left);
            this.Controls.Add(this.up);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.highest_label);
            this.Controls.Add(this.highest_panel);
            this.Controls.Add(this.mode_panel);
            this.Controls.Add(this.score_panel);
            this.Controls.Add(this.pnlBoard);
            this.Margin = new System.Windows.Forms.Padding(8);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.score_panel.ResumeLayout(false);
            this.score_panel.PerformLayout();
            this.mode_panel.ResumeLayout(false);
            this.mode_groupBox.ResumeLayout(false);
            this.mode_groupBox.PerformLayout();
            this.highest_panel.ResumeLayout(false);
            this.highest_panel.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel pnlBoard;
        private System.Windows.Forms.Panel score_panel;
        private System.Windows.Forms.Label score_label;
        private System.Windows.Forms.TextBox score_textBox;
        private System.Windows.Forms.Panel mode_panel;
        private System.Windows.Forms.GroupBox mode_groupBox;
        private System.Windows.Forms.RadioButton mode4;
        private System.Windows.Forms.RadioButton mode3;
        private System.Windows.Forms.RadioButton mode2;
        private System.Windows.Forms.RadioButton mode1;
        private System.Windows.Forms.Panel highest_panel;
        private System.Windows.Forms.Label hightpoint;
        private System.Windows.Forms.Label highest_label;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button up;
        private System.Windows.Forms.Button left;
        private System.Windows.Forms.Button right;
        private System.Windows.Forms.Button down;
    }
}

