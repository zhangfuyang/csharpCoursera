using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;

namespace funnycertificate
{
    public partial class Form1 : Form
    {
        Bitmap m_Bitmap = new Bitmap(1, 1);
        Graphics g;
        public Form1()
        {
            InitializeComponent();
        }

        private void OpenToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = @"Bitmap文件(*.bmp)|*.bmp|Jpeg文件(*.jpg)|*.jpg|所有合适文件(*.bmp;*.jpg)|*.bmp;*.jpg|所有文件(*.*)|*.*";
            openFileDialog.FilterIndex = 2;
            openFileDialog.RestoreDirectory = true;
            if (DialogResult.OK == openFileDialog.ShowDialog())
            {
                m_Bitmap = (Bitmap)Bitmap.FromFile(openFileDialog.FileName, false);
                m_Bitmap = BitmapFilter.Resize(m_Bitmap, 295, 413, true);
                this.AutoScroll = true;
                this.AutoScrollMinSize = new Size(m_Bitmap.Width, m_Bitmap.Height);
                this.Invalidate();
            }
        }

        private void ExitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            if (m_Bitmap == null) return;

            g = e.Graphics;
            g.DrawImage(m_Bitmap, new Rectangle(this.AutoScrollPosition.X+5 , this.AutoScrollPosition.Y+25,
                (int)(m_Bitmap.Width), (int)(m_Bitmap.Height)));

            GraphicsPath gp = new GraphicsPath(FillMode.Winding);
            gp.AddString("    独富的不\n兹特的忽胜\n证的忽悠防\n明忽悠手，\n该悠经段特\n同手验，发\n志法，让此\n具，高人证\n有丰明防。", new FontFamily("方正舒体"), 
                (int)FontStyle.Regular, 40, new PointF(300, 25), new StringFormat());
            Brush brush = new LinearGradientBrush(new PointF(0, 0), new PointF(Width, Height),
                            Color.Red, Color.Yellow);
            Pen pen;
            Point point = new Point(5, 25);
            Size sizeLine = new Size(0, 450);
            Size sizeOff = new Size(530, 0);
 
            pen = new Pen(Color.Red, 5);
            g.DrawLine(pen, point , point + sizeLine);
            g.DrawLine(pen, point + sizeOff, point);
            g.DrawLine(pen, point + sizeOff, point + sizeOff + sizeLine);
            g.DrawLine(pen, point + sizeLine, point + sizeOff + sizeLine);
            pen.DashStyle = DashStyle.Dash;

            e.Graphics.DrawPath(Pens.Black, gp);
            e.Graphics.FillPath(brush, gp);
        }

        private void SaveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Bitmap bit = new Bitmap(this.Width, this.Height);//实例化一个和窗体一样大的bitmap
            Graphics g = Graphics.FromImage(bit);
            g.CompositingQuality = CompositingQuality.HighQuality;//质量设为最高
            g.CopyFromScreen(this.Left, this.Top, 0, 0, new Size(this.Width, this.Height));//保存整个窗体为图片
                                                                                           //g.CopyFromScreen(panel游戏区 .PointToScreen(Point.Empty), Point.Empty, panel游戏区.Size);//只保存某个控件（这里是panel游戏区）
            bit.Save("weiboTemp.png");//默认保存格式为PNG，保存成jpg格式质量不是很好
            SaveFileDialog saveFileDialog = new SaveFileDialog();

            saveFileDialog.InitialDirectory = "c:\\";
            saveFileDialog.Filter = "Bitmap files (*.bmp)|*.bmp|Jpeg files (*.jpg)|*.jpg|All valid files (*.bmp/*.jpg)|*.bmp/*.jpg";
            saveFileDialog.FilterIndex = 1;
            saveFileDialog.RestoreDirectory = true;

            if (DialogResult.OK == saveFileDialog.ShowDialog())
            {
                switch (saveFileDialog.FileName.Substring(saveFileDialog.FileName.Length - 3, 3).ToLower())
                {
                    case "bmp":
                        m_Bitmap.Save(saveFileDialog.FileName, ImageFormat.Bmp);
                        break;
                    case "png":
                        m_Bitmap.Save(saveFileDialog.FileName, ImageFormat.Png);
                        break;
                    case "jpg":
                    case "jpe":
                    case "peg":
                        m_Bitmap.Save(saveFileDialog.FileName, ImageFormat.Jpeg);
                        break;
                    case "tif":
                    case "iff":
                        m_Bitmap.Save(saveFileDialog.FileName, ImageFormat.Tiff);
                        break;
                }
            }
        }
    }
}
