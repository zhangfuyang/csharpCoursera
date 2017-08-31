namespace homework
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
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.Task_listbox = new System.Windows.Forms.ListBox();
            this.add = new System.Windows.Forms.Button();
            this.edit = new System.Windows.Forms.Button();
            this.movedown = new System.Windows.Forms.Button();
            this.moveup = new System.Windows.Forms.Button();
            this.delete = new System.Windows.Forms.Button();
            this.check = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.SuspendLayout();
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.Task_listbox);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.add);
            this.splitContainer1.Panel2.Controls.Add(this.edit);
            this.splitContainer1.Panel2.Controls.Add(this.movedown);
            this.splitContainer1.Panel2.Controls.Add(this.moveup);
            this.splitContainer1.Panel2.Controls.Add(this.delete);
            this.splitContainer1.Panel2.Controls.Add(this.check);
            this.splitContainer1.Size = new System.Drawing.Size(2321, 1334);
            this.splitContainer1.SplitterDistance = 1071;
            this.splitContainer1.TabIndex = 2;
            // 
            // Task_listbox
            // 
            this.Task_listbox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Task_listbox.Font = new System.Drawing.Font("宋体", 21.9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Task_listbox.FormattingEnabled = true;
            this.Task_listbox.HorizontalScrollbar = true;
            this.Task_listbox.ItemHeight = 73;
            this.Task_listbox.Location = new System.Drawing.Point(0, 0);
            this.Task_listbox.Name = "Task_listbox";
            this.Task_listbox.Size = new System.Drawing.Size(1071, 1334);
            this.Task_listbox.TabIndex = 2;
            this.Task_listbox.SelectedIndexChanged += new System.EventHandler(this.Task_listbox_SelectedIndexChanged);
            // 
            // add
            // 
            this.add.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.add.Location = new System.Drawing.Point(3, 487);
            this.add.Name = "add";
            this.add.Size = new System.Drawing.Size(483, 236);
            this.add.TabIndex = 5;
            this.add.Text = "增加";
            this.add.UseVisualStyleBackColor = true;
            this.add.Click += new System.EventHandler(this.add_Click);
            // 
            // edit
            // 
            this.edit.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.edit.Location = new System.Drawing.Point(2, 729);
            this.edit.Name = "edit";
            this.edit.Size = new System.Drawing.Size(483, 236);
            this.edit.TabIndex = 4;
            this.edit.Text = "编辑";
            this.edit.UseVisualStyleBackColor = true;
            this.edit.Click += new System.EventHandler(this.edit_Click);
            // 
            // movedown
            // 
            this.movedown.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.movedown.Location = new System.Drawing.Point(2, 1213);
            this.movedown.Name = "movedown";
            this.movedown.Size = new System.Drawing.Size(483, 236);
            this.movedown.TabIndex = 3;
            this.movedown.Text = "下移";
            this.movedown.UseVisualStyleBackColor = true;
            this.movedown.Click += new System.EventHandler(this.movedown_Click);
            // 
            // moveup
            // 
            this.moveup.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.moveup.Location = new System.Drawing.Point(3, 971);
            this.moveup.Name = "moveup";
            this.moveup.Size = new System.Drawing.Size(483, 236);
            this.moveup.TabIndex = 2;
            this.moveup.Text = "上移";
            this.moveup.UseVisualStyleBackColor = true;
            this.moveup.Click += new System.EventHandler(this.moveup_Click);
            // 
            // delete
            // 
            this.delete.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.delete.Location = new System.Drawing.Point(3, 245);
            this.delete.Name = "delete";
            this.delete.Size = new System.Drawing.Size(483, 236);
            this.delete.TabIndex = 1;
            this.delete.Text = "删除";
            this.delete.UseVisualStyleBackColor = true;
            this.delete.Click += new System.EventHandler(this.delete_Click);
            // 
            // check
            // 
            this.check.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.check.Location = new System.Drawing.Point(3, 3);
            this.check.Name = "check";
            this.check.Size = new System.Drawing.Size(483, 236);
            this.check.TabIndex = 0;
            this.check.Text = "button1";
            this.check.UseVisualStyleBackColor = true;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(15F, 30F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.ClientSize = new System.Drawing.Size(2321, 1334);
            this.Controls.Add(this.splitContainer1);
            this.DoubleBuffered = true;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.ListBox Task_listbox;
        private System.Windows.Forms.Button add;
        private System.Windows.Forms.Button edit;
        private System.Windows.Forms.Button movedown;
        private System.Windows.Forms.Button moveup;
        private System.Windows.Forms.Button delete;
        private System.Windows.Forms.Button check;
    }
}

