using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;
public class Form1 : Form
{
    public Form1()
    {
        this.AutoScaleBaseSize = new Size(6, 14);
        this.ClientSize = new Size(400, 400);
        this.Paint += new PaintEventHandler(this.Form1_Paint);
        this.Click += new EventHandler(this.Redraw);
        this.th1_text = new TextBox();
        th1_text.Size = new Size(100, 5);
        th1_text.Enabled = true;
        th1_text.Location = new Point(300, 300);
        th1_text.TextChanged += Th1_text_TextChanged;
        this.Controls.Add(this.th1_text);

        this.th2_text = new TextBox();
        th2_text.Size = new Size(100, 5);
        th2_text.Enabled = true;
        th2_text.Location = new Point(300, 325);
        th2_text.TextChanged += Th2_text_TextChanged;
        this.Controls.Add(this.th2_text);

        this.per1_text = new TextBox();
        per1_text.Size = new Size(100, 5);
        per1_text.Enabled = true;
        per1_text.Location = new Point(300, 350);
        per1_text.TextChanged += Per1_text_TextChanged;
        this.Controls.Add(this.per1_text);

        this.per2_text = new TextBox();
        per2_text.Size = new Size(100, 5);
        per2_text.Enabled = true;
        per2_text.Location = new Point(300, 375);
        per2_text.TextChanged += Per2_text_TextChanged;
        this.Controls.Add(this.per2_text);

        this.th1_label = new Label();
        th1_label.Text = "th1";
        th1_label.Enabled = true;
        th1_label.Location = new Point(275, 300);
        this.Controls.Add(this.th1_label);

        this.th2_label = new Label();
        th2_label.Text = "th2";
        th2_label.Enabled = true;
        th2_label.Location = new Point(275, 325);
        this.Controls.Add(this.th2_label);

        this.per1_label = new Label();
        per1_label.Text = "per1";
        per1_label.Enabled = true;
        per1_label.Location = new Point(275, 350);
        this.Controls.Add(this.per1_label);

        this.per2_label = new Label();
        per2_label.Text = "per2";
        per2_label.Enabled = true;
        per2_label.Location = new Point(275, 375);
        this.Controls.Add(this.per2_label);

        th1_text.Text = (35 * Math.PI / 180).ToString("0.00");
        th2_text.Text = (25 * Math.PI / 180).ToString("0.00");
        per1_text.Text = 0.6 + "";
        per2_text.Text = 0.7 + "";
    }
    
    private void Per2_text_TextChanged(object sender, EventArgs e)
    {
        double.TryParse((sender as TextBox).Text, out per2);
    }

    private void Per1_text_TextChanged(object sender, EventArgs e)
    {
        double.TryParse((sender as TextBox).Text, out per1);
    }

    private void Th2_text_TextChanged(object sender, EventArgs e)
    {
        double.TryParse((sender as TextBox).Text, out th2);
    }

    private void Th1_text_TextChanged(object sender, EventArgs e)
    {
        double.TryParse((sender as TextBox).Text, out th1);
        
    }

    static void Main()
    {
        Application.Run(new Form1());
    }

    private void Form1_Paint(object sender, PaintEventArgs e)
    {
        graphics = e.Graphics;
        drawTree(10, 200, 380, 100, 100, -PI / 2);
    }

    private void Redraw(object sender, EventArgs e)
    {
        this.Invalidate();
        Console.WriteLine("th1" + th1 + "th2" + th2 + "per1" + per1 + "per2" + per2);
    }

    private TextBox th1_text;
    private TextBox th2_text;
    private TextBox per1_text;
    private TextBox per2_text;
    private Label th1_label;
    private Label th2_label;
    private Label per1_label;
    private Label per2_label;
    private Graphics graphics;
    const double PI = Math.PI;
    double th1 = 35 * Math.PI / 180;
    double th2 = 25 * Math.PI / 180;
    double per1 = 0.6;
    double per2 = 0.7;
    Random rnd = new Random();

    double rand()
    {
        return rnd.NextDouble();
    }

    void drawTree(int n, double x0, double y0, double leng0, double leng1, double th)
    {
        if (n == 0) return;
        double x1 = x0 + leng0 * Math.Cos(th);
        double y1 = y0 + leng0 * Math.Sin(th);
        double x2 = x0 + leng1 * Math.Cos(th);
        double y2 = y0 + leng1 * Math.Sin(th);
        double leng = leng0 > leng1 ? leng0 : leng1;
        drawLine(x0, y0, x0 + leng * Math.Cos(th), y0 + leng * Math.Sin(th));
        drawTree(n - 1, x1, y1, per1 * leng0 * (0.5 + rand()), per1 * leng0 * (0.5 + rand()), th + th1 * (0.5 + rand()));
        drawTree(n - 1, x2, y2, per2 * leng1 * (0.4 + rand()), per2 * leng1 * (0.4 + rand()), th - th2 * (0.5 + rand()));
        if (rand() > 0.6)
            drawTree(n - 1, x1, y1, per2 * (leng0 + leng1) / 2 * (0.4 + rand()), per2 * (leng0 + leng1) / 2 * (0.4 + rand()), th - th2 * (0.5 + rand()));
    }

    void drawLine(double x0, double y0, double x1, double y1)
    {
        Pen color = Pens.Blue;
        switch (rnd.Next(5))
        {
            case 0: color = Pens.Blue;break;
            case 1: color = Pens.DarkSeaGreen;break;
            case 2: color = Pens.DarkBlue;break;
            case 3: color = Pens.Green;break;
            case 4: color = Pens.Black;break;
        }
        
        graphics.DrawLine(color, (int)x0, (int)y0, (int)x1, (int)y1);
    }
}