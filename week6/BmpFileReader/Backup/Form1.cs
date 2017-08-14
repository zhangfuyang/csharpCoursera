using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;

using System.IO;
using System.Runtime.InteropServices;

namespace BmpFileReader
{
	/// <summary>
	/// Form1 ��ժҪ˵����
	/// </summary>
	public class Form1 : System.Windows.Forms.Form
	{
		private System.Windows.Forms.Button button1;
		private System.Windows.Forms.PictureBox pictureBox1;
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
			this.button1 = new System.Windows.Forms.Button();
			this.pictureBox1 = new System.Windows.Forms.PictureBox();
			this.SuspendLayout();
			// 
			// button1
			// 
			this.button1.Location = new System.Drawing.Point(240, 16);
			this.button1.Name = "button1";
			this.button1.Size = new System.Drawing.Size(56, 24);
			this.button1.TabIndex = 0;
			this.button1.Text = "button1";
			this.button1.Click += new System.EventHandler(this.button1_Click);
			// 
			// pictureBox1
			// 
			this.pictureBox1.Location = new System.Drawing.Point(248, 184);
			this.pictureBox1.Name = "pictureBox1";
			this.pictureBox1.Size = new System.Drawing.Size(216, 200);
			this.pictureBox1.TabIndex = 1;
			this.pictureBox1.TabStop = false;
			// 
			// Form1
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(6, 14);
			this.ClientSize = new System.Drawing.Size(320, 273);
			this.Controls.Add(this.pictureBox1);
			this.Controls.Add(this.button1);
			this.Name = "Form1";
			this.Text = "Form1";
			this.Load += new System.EventHandler(this.Form1_Load);
			this.Paint += new System.Windows.Forms.PaintEventHandler(this.Form1_Paint);
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


		string fileName = "..\\..\\test2.bmp";
		Stream stream = null;

		private void button1_Click(object sender, System.EventArgs e)
		{
			ReadAndShowBitmap(this.CreateGraphics());
		}

		private void Form1_Load(object sender, System.EventArgs e)
		{
		
		}

		private void Form1_Paint(object sender, System.Windows.Forms.PaintEventArgs e)
		{
			//e.Graphics.DrawLine( new Pen(Color.Red,1), 50, 100, 50+1, 100+1);
			ReadAndShowBitmap( e.Graphics );
		}

		private void ReadAndShowBitmap(Graphics graph)
		{
			stream = new FileStream( fileName, FileMode.Open, FileAccess.Read );

			BITMAPFILEHEADER fileHeader = ReadFileHeader_UseBinaryReader(); //�ļ�ͷ
			//BITMAPFILEHEADER fileHeader = ReadFileHeader(); //�ļ�ͷ

			BITMAPINFOHEADER bmpInfo = ReadInfo(); //��Ϣͷ

			if( bmpInfo.biBitCount != 24 )
			{
				MessageBox.Show( "������ֻ�ܴ���24λλͼ" );
				stream.Close();
				return;
			}
    
			int w = bmpInfo.biWidth;
			int h = bmpInfo.biHeight;
    
			stream.Seek( fileHeader.bfOffBits, SeekOrigin.Begin );//��ȥһЩ�ֽڣ���λ��ͼ�����ݴ�
    
			int LineSize = w * 3;
			if( LineSize%4 != 0 ) LineSize +=  4 - (LineSize % 4) ; //ÿ��ͼ���ռ3���ֽڡ���һ�в���4�ı���,����
    
    
			for( int i=1; i<=h; i++ ) //����
			{
				for( int j=1; j<=w; j++ ) //����
				{
					RGBTRIPLE point = ReadPixel();
					Color color = Color.FromArgb(point.rgbtRed, point.rgbtGreen, point.rgbtBlue);
					graph.DrawLine( new Pen(color,1), j, h - i, j, h - i+1);//ע��ͼ������������Ƿ���,���⣬�ߵĳ���Ϊ1�����ܻ�������
				}
				if( w * 3 % 4 != 0 )//ÿ�в���4�ı���,�Գ����ֽ�
				{     
					//stream.Seek( fileHeader.bfOffBits + LineSize * i, SeekOrigin.Begin );
					stream.Seek( 4- w * 3 % 4, SeekOrigin.Current );
				}       
			}
			stream.Close();	
		}


		private BITMAPFILEHEADER ReadFileHeader_UseBinaryReader( )//ʹ��BinaryReader���ж�
		{
			BinaryReader br = new BinaryReader( stream ); 

			BITMAPFILEHEADER x = new BITMAPFILEHEADER();
			x.bfType = br.ReadInt16();
			x.bfSize = br.ReadInt32();
			x.bfReserved1 = br.ReadInt16();
			x.bfReserved2 = br.ReadInt16();
			x.bfOffBits = br.ReadInt32();

			return x;
		}


		private BITMAPFILEHEADER ReadFileHeader( )//ֱ�Ӷ����ڴ�������
		{
			BITMAPFILEHEADER x = new BITMAPFILEHEADER();
			int c = Marshal.SizeOf( x );
			byte [] buffer  = new byte[c];

			stream.Read( buffer,0, c ); 
			unsafe
			{
				fixed( byte * p = buffer  )
				{
					x = *((BITMAPFILEHEADER *)p);
				}
			}
			return x;
		}


		private BITMAPINFOHEADER ReadInfo( )
		{
			BITMAPINFOHEADER x = new BITMAPINFOHEADER();
			int c = Marshal.SizeOf( x );
			byte [] buffer  = new byte[c];

			stream.Read( buffer,0, c );
			unsafe
			{
				fixed( byte * p = buffer  )
				{
					x = *((BITMAPINFOHEADER *)p);
				}
			}
			return x;
		}


		private RGBTRIPLE ReadPixel( )
		{
			RGBTRIPLE x = new RGBTRIPLE();
			int c = Marshal.SizeOf( x );
			byte [] buffer  = new byte[c];

			stream.Read( buffer,0, c );
			unsafe
			{
				fixed( byte * p = buffer  )
				{
					x = *((RGBTRIPLE *)p);
				}
			}
			return x;
		}


		[StructLayout(LayoutKind.Sequential, Pack=1)]
			public struct BITMAPFILEHEADER 
		{
			public short bfType;
			public int bfSize;
			public short bfReserved1;
			public short bfReserved2;
			public int bfOffBits;
		}

		[StructLayout(LayoutKind.Sequential, Pack=1)]
			public struct BITMAPINFOHEADER 
		{
			public int biSize;
			public int biWidth;
			public int biHeight;
			public short biPlanes;
			public short biBitCount;
			public int biCompression;
			public int biSizeImage;
			public int biXPelsPerMeter;
			public int biYPelsPerMeter;
			public int biClrUsed;
			public int biClrImportant;
		}


		[StructLayout(LayoutKind.Sequential, Pack=1)]
			public struct RGBTRIPLE 
		{
			public byte rgbtBlue;
			public byte rgbtGreen;
			public byte rgbtRed;
		}

	}
}
