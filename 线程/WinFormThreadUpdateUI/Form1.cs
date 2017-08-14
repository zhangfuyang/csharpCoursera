using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;

using System.Threading;

namespace WinFormThreadUpdateUI
{
	/// <summary>
	/// Form1 ��ժҪ˵����
	/// </summary>
	public class Form1 : System.Windows.Forms.Form
	{
		private System.Windows.Forms.ListBox lstMsg;
		private System.Windows.Forms.Button btnAddThread;
		private System.Windows.Forms.Label lblMsg;
		/// <summary>
		/// ����������������
		/// </summary>
		private System.ComponentModel.Container components = null;

		public Form1()
		{
			//
			// Windows ���������֧���������
			//
			InitializeComponent();

			//
			// TODO: �� InitializeComponent ���ú�����κι��캯������
			//
		}

		/// <summary>
		/// ������������ʹ�õ���Դ��
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

		#region Windows ������������ɵĴ���
		/// <summary>
		/// �����֧������ķ��� - ��Ҫʹ�ô���༭���޸�
		/// �˷��������ݡ�
		/// </summary>
		private void InitializeComponent()
		{
            this.lstMsg = new System.Windows.Forms.ListBox();
            this.btnAddThread = new System.Windows.Forms.Button();
            this.lblMsg = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // lstMsg
            // 
            this.lstMsg.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.lstMsg.ItemHeight = 30;
            this.lstMsg.Location = new System.Drawing.Point(0, -178);
            this.lstMsg.Name = "lstMsg";
            this.lstMsg.Size = new System.Drawing.Size(488, 604);
            this.lstMsg.TabIndex = 0;
            // 
            // btnAddThread
            // 
            this.btnAddThread.Location = new System.Drawing.Point(235, 100);
            this.btnAddThread.Name = "btnAddThread";
            this.btnAddThread.Size = new System.Drawing.Size(277, 80);
            this.btnAddThread.TabIndex = 1;
            this.btnAddThread.Text = "��һ���߳�";
            this.btnAddThread.Click += new System.EventHandler(this.btnAddThread_Click);
            // 
            // lblMsg
            // 
            this.lblMsg.Location = new System.Drawing.Point(85, 240);
            this.lblMsg.Name = "lblMsg";
            this.lblMsg.Size = new System.Drawing.Size(1046, 58);
            this.lblMsg.TabIndex = 2;
            this.lblMsg.Text = "label1";
            // 
            // Form1
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(16, 35);
            this.ClientSize = new System.Drawing.Size(488, 426);
            this.Controls.Add(this.lblMsg);
            this.Controls.Add(this.btnAddThread);
            this.Controls.Add(this.lstMsg);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);

		}
		#endregion

		/// <summary>
		/// Ӧ�ó��������ڵ㡣
		/// </summary>
		[STAThread]
		static void Main() 
		{
			Application.Run(new Form1());
		}




		private void btnAddThread_Click(object sender, System.EventArgs e)
		{
			Thread thread = new Thread( new ThreadStart( MyFun ) );
			thread.Name = (++id).ToString();
			thread.IsBackground = true;
			thread.Start();
		}
		int id =0;

		Random rnd = new Random();
		private void MyFun()
		{
			while( true )
			{
				//Thread.Sleep( rnd.Next(4000) );
				string msg = DateTime.Now + " " + Thread.CurrentThread.Name;
				//AddMsgFun( msg ); //�������� //VS.net 2005 ���ϵİ汾���׳��쳣
				ShowMsg( msg ); //�����Ϻ�
			}
		}




		private void ShowMsg( string msg )
		{
			if(this.InvokeRequired )//�����ж�
			{
				this.BeginInvoke( new AddMsg(this.AddMsgFun), new object[]{ msg } ); //��ʾ��������
			}
			else
			{
				AddMsgFun( msg );
			}
		}

		private delegate void AddMsg( string msg );
		private void AddMsgFun( string msg )
		{
			this.lstMsg.Items.Insert(0, msg );
			this.lstMsg.SelectedIndex=0;

			this.lblMsg.Text = msg;
		}

	}
}
