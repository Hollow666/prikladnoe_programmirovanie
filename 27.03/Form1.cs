using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace домик
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            box.Width = 600;
            box.Height = 600;
            Bitmap bitmap = new Bitmap(box.Width, box.Height);
            Graphics img = Graphics.FromImage(bitmap);
            img.Clear(System.Drawing.Color.Blue);
            
            Point[] points = new Point[3] {new Point(150, 200), new Point(450, 200), new Point(300, 50)};
            
            //img.DrawLine(myPen, 150, 200, 300, 50);
            //img.DrawLine(myPen, 300, 50, 450, 200);


            SolidBrush brush = new SolidBrush(System.Drawing.Color.Red);
            img.FillRectangle(brush, new Rectangle(150, 200, 300, 250));
            brush.Color = System.Drawing.Color.Green;
            img.FillRectangle(brush, new Rectangle(250, 300, 100, 150));
            brush.Color = System.Drawing.Color.Yellow;
            img.FillPolygon(brush, points);
            brush.Color = System.Drawing.Color.LightBlue;
            img.FillEllipse(brush, new Rectangle(250, 90, 100, 100));

            System.Drawing.Pen myPen = new System.Drawing.Pen(System.Drawing.Color.Black);
            img.DrawRectangle(myPen, new Rectangle(150, 200, 300, 250));
            img.DrawRectangle(myPen, new Rectangle(250, 300, 100, 150));
            img.DrawEllipse(myPen, new Rectangle(250, 90, 100, 100));
            img.DrawPolygon(myPen, points);

            myPen.Dispose();
            brush.Dispose();
            img.Dispose();
            box.Image = bitmap;
        }
    }
}
