using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _25._03
{
    public partial class Form1 : Form
    {
        private int viNumButton = 0;
        private int viNumInRg = 20;
        private string[,] rgsValues = null;
        public Form1()
        {
            InitializeComponent();
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            
        }
        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {

        }
        private void vCreateRg()
        {
            Random rnd = new Random(DateTime.Now.Millisecond);
            Random rnd1 = new Random(DateTime.Now.Millisecond + 5);
            rgsValues = new string[viNumInRg, 2];
            for (int i = 0; i < viNumInRg; i++)
            {
                rgsValues[i, 0] = Convert.ToString(((float)(rnd.Next(0, 10) * 100) +
                                              (float)rnd1.Next(0, 99)) / (float)100);
                rgsValues[i, 1] = "I-" + Convert.ToString(i + 1);
            }
        }
        private void vCreateLinGr()
        {
            vCreateRg();
            graph clPaint = new graph(pictureBox1.Width, pictureBox1.Height);
            clPaint.vSetBackground(Color.White);
            clPaint.vDravAxis(50, 50, 30, Color.Red, 2, true);
            clPaint.vSetPenWidthLine(1);
            clPaint.vSetPenColorLine(Color.Silver);
            clPaint.MaxRg = 20;
            clPaint.vDravGrid();
            clPaint.vSetPenWidthLine(2);
            clPaint.vSetPenColorLine(Color.Green);
            clPaint.RgValue = rgsValues;
            clPaint.vDrawGraphLines();
            Font objFont = new Font("Arial", 7, FontStyle.Bold | FontStyle.Italic);
            clPaint.font = objFont;
            clPaint.brush = Brushes.Blue;
            clPaint.vDrawTextAxXNumber(false);
            clPaint.vDrawTextAxYValues();
            clPaint.vDrawTextAxYValuesPoint(true, false);
            pictureBox1.Image = clPaint.Bmp;
        }
        private void button1_Click(object sender, EventArgs e)
        {
            viNumButton = 1;
            vCreateLinGr();
        }
    }
}
