using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;

using System.IO;

namespace MyFileViewerSimple
{
	/// <summary>
	/// Form1 的摘要说明。
	/// </summary>
	public class Form1 : System.Windows.Forms.Form
	{
		private System.Windows.Forms.ListView listView1;
		private System.Windows.Forms.TreeView treeView1;
		private System.Windows.Forms.Splitter splitter1;
		/// <summary>
		/// 必需的设计器变量。
		/// </summary>
		private System.ComponentModel.Container components = null;

		public Form1()
		{
			//
			// Windows 窗体设计器支持所必需的
			//
			InitializeComponent();

			//
			// TODO: 在 InitializeComponent 调用后添加任何构造函数代码
			//
		}

		/// <summary>
		/// 清理所有正在使用的资源。
		/// </summary>
		protected override void Dispose( bool disposing )
		{
			if( disposing )
			{
				if (components != null) 
				{
					components.Dispose();
				}
			}
			base.Dispose( disposing );
		}

		#region Windows 窗体设计器生成的代码
		/// <summary>
		/// 设计器支持所需的方法 - 不要使用代码编辑器修改
		/// 此方法的内容。
		/// </summary>
		private void InitializeComponent()
		{
			this.listView1 = new System.Windows.Forms.ListView();
			this.treeView1 = new System.Windows.Forms.TreeView();
			this.splitter1 = new System.Windows.Forms.Splitter();
			this.SuspendLayout();
			// 
			// listView1
			// 
			this.listView1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.listView1.Location = new System.Drawing.Point(0, 0);
			this.listView1.Name = "listView1";
			this.listView1.Size = new System.Drawing.Size(480, 357);
			this.listView1.TabIndex = 0;
			// 
			// treeView1
			// 
			this.treeView1.Dock = System.Windows.Forms.DockStyle.Left;
			this.treeView1.ImageIndex = -1;
			this.treeView1.Location = new System.Drawing.Point(0, 0);
			this.treeView1.Name = "treeView1";
			this.treeView1.SelectedImageIndex = -1;
			this.treeView1.Size = new System.Drawing.Size(121, 357);
			this.treeView1.TabIndex = 1;
			this.treeView1.AfterExpand += new System.Windows.Forms.TreeViewEventHandler(this.treeView1_AfterExpand);
			this.treeView1.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.treeView1_AfterSelect);
			// 
			// splitter1
			// 
			this.splitter1.Location = new System.Drawing.Point(121, 0);
			this.splitter1.Name = "splitter1";
			this.splitter1.Size = new System.Drawing.Size(3, 357);
			this.splitter1.TabIndex = 2;
			this.splitter1.TabStop = false;
			// 
			// Form1
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(6, 14);
			this.ClientSize = new System.Drawing.Size(480, 357);
			this.Controls.Add(this.splitter1);
			this.Controls.Add(this.treeView1);
			this.Controls.Add(this.listView1);
			this.Name = "Form1";
			this.Text = "Form1";
			this.Load += new System.EventHandler(this.Form1_Load);
			this.ResumeLayout(false);

		}
		#endregion

		/// <summary>
		/// 应用程序的主入口点。
		/// </summary>
		[STAThread]
		static void Main() 
		{
			Application.Run(new Form1());
		}

		private void Form1_Load(object sender, System.EventArgs e)
		{
			//注意，添加TreeView控件，Dock属性设为Left，再添加Splitter控件，同样将Dock属性设为Left。最后添加ListView控件，命名为listView，Dock属性设为Fill。

			FillDrivers();

		}

		private void FillDrivers()
		{
			//获取逻辑驱动器

			string[] LogicDrives=System.IO .Directory .GetLogicalDrives();

			TreeNode[] cRoot =new TreeNode[LogicDrives.Length];

			for (int i=0;i< LogicDrives.Length ;i++)
			{

				TreeNode drivesNode=new TreeNode(LogicDrives[i]);

				treeView1.Nodes .Add (drivesNode);

				if (LogicDrives[i]!="A:\\" && LogicDrives[i]!="B:\\" )
					getSubNode(drivesNode,true);

			}
		}

		private void getSubNode(TreeNode PathName,bool isEnd)
		{
			
			if(!isEnd)
				return; //exit this

			try
			{
				TreeNode curNode;
				DirectoryInfo curDir=new DirectoryInfo (PathName.FullPath);

				DirectoryInfo[] subDir = curDir.GetDirectories();

				foreach(DirectoryInfo d in subDir)
				{
					curNode=new TreeNode(d.Name);
					PathName.Nodes .Add (curNode);

					//getSubNode(curNode,false);
				}
			}
			catch{}

		}

		private void treeView1_AfterExpand(object sender, System.Windows.Forms.TreeViewEventArgs e)
		{
			try
			{
				foreach(TreeNode tn in e.Node .Nodes )
				{
					if (!tn.IsExpanded)
						getSubNode(tn,true);
				}
			}
			catch{}
		}

		private void treeView1_AfterSelect(object sender, System.Windows.Forms.TreeViewEventArgs e)
		{
			listView1.Items.Clear();

			DirectoryInfo selDir=new DirectoryInfo(e.Node.FullPath );

			DirectoryInfo[] listDir;

			FileInfo[] listFile;

			listDir=selDir.GetDirectories();
			listFile=selDir.GetFiles(); 

			foreach (DirectoryInfo d in listDir)
				listView1.Items.Add (d.Name,6);

			foreach (FileInfo d in listFile)
				listView1.Items.Add (d.Name); 

		}

	}

}
