using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Drawing.Drawing2D;


namespace _25._03
{
    class graph
    {
        private Bitmap bmp = null;
        private Graphics graph1 = null;
        private Font objFont = new Font("Arial", 8, FontStyle.Bold);
        private Brush objBrush = Brushes.Black;
        private Pen objPenLine = new Pen(Color.Black, 1);
        private int viX = 200;
        private int viY = 100;
        private int viDeltaaxisL = 50;
        private int viDeltaaxisR = 50;
        private int viDeltaaxisH = 20;
        private int viMaxRg = 20;
        private string[,] rgsValues = null;
        public string[,] RgValue
        {
            set { rgsValues = value; }
        }
        public Brush brush
        {
            set { objBrush = value; }
        }
        public Font font
        {
            set { objFont = value; }
        }
        public graph()
        {

        }
        public graph(int a, int b)
        {
            bmp = new Bitmap(a, b); 
            graph1 = Graphics.FromImage(bmp);
            viX = a;
            viY = b;
        }
        public void vSetBackground(Color bcl)
        {
            graph1.Clear(bcl);
        }
        public Bitmap Bmp
        {
            get { return bmp; }
        }
        public void vSetPenColorLine(Color pcl)
        {
            if (objPenLine == null)
            {
                objPenLine = new Pen(Color.Black, 1);
            }
            objPenLine.Color = pcl;
        }       
        public void vSetPenWidthLine(int penwidth)
        {
            if (objPenLine == null)
            {
                objPenLine = new Pen(Color.Black, 1);
            }
            objPenLine.Width = penwidth;
        }
        public void vDravAxis(int deltaaxisL, int deltaaxisR, int deltaaxisH, Color colorpenaxis, int widthpen, bool fArrow)
        {                    
            viDeltaaxisL = deltaaxisL;
            viDeltaaxisR = deltaaxisR;
            viDeltaaxisH = deltaaxisH;
            vSetPenColorLine(colorpenaxis);
            if (widthpen > 0) vSetPenWidthLine(widthpen);         
            int x = deltaaxisL;
            int y = viY - deltaaxisH;
            int x1 = viX - deltaaxisR;
            int y1 = deltaaxisH;
            int d = 0;
            if (fArrow) d = widthpen * 10;
            graph1.DrawLine(objPenLine, x, y, x1 + d, y);
            graph1.DrawLine(objPenLine, x, y, x, y1 - d);
            if (fArrow)
            {
                int a = 10 * (int)objPenLine.Width;
                int b = 2 * (int)objPenLine.Width;
                int x2 = x1 - a;
                int y2 = y + b;
                graph1.DrawLine(objPenLine, x1 + 20, y, x2 + d, y2);
                y2 = y - b;
                graph1.DrawLine(objPenLine, x1 + 20, y, x2 + d, y2);
                x2 = x - b;
                y2 = y1 + a;
                graph1.DrawLine(objPenLine, x, y1 - d, x2, y2 - d);
                x2 = x + b;
                graph1.DrawLine(objPenLine, x, y1 - d, x2, y2 - d);
            }
        }
        public int MaxRg
        {
            set { viMaxRg = value; }
        }
        public void vDravGrid()
        {
            float x = viDeltaaxisL;
            float y = viY - viDeltaaxisH;
            float x1 = viX - viDeltaaxisR;
            float y1 = viDeltaaxisH;
            float f = (y - y1) / (float)viMaxRg;
            for (int i = 1; i < viMaxRg + 1; i++)
            {
                graph1.DrawLine(objPenLine, x, y - f * i, x1, y - f * i);
            }
            f = (x - x1) / (float)(viMaxRg - 1);
            for (int i = 1; i < viMaxRg; i++)
            {
                graph1.DrawLine(objPenLine, x - f * i, y, x - f * i, y1);
            }
        }
        public void vDrawGraphLines()
        {
            string s = string.Empty;
            string s1 = string.Empty;
            string s2 = string.Empty;
            float f = 0;
            float f1 = 0;
            float x1 = 0;
            float x = viDeltaaxisL;
            float y = viY - viDeltaaxisH;
            float x2 = 0;
            float fMax = float.MinValue;
            for (int i = 0; i < viMaxRg; i++)
            {
                s = rgsValues[i, 0];
                if (fMax < float.Parse(s)) fMax = float.Parse(s);
            }
            float fdeltax = viX - viDeltaaxisL - viDeltaaxisR;
            fdeltax = fdeltax / (float)(viMaxRg - 1);
            float fdeltay = viY - 2 * viDeltaaxisH;
            fdeltay = fdeltay / fMax;
            for (int i = 0; i < viMaxRg; i++)
            {
                if (i == 0)
                {
                    s = rgsValues[i, 0];
                    s2 = rgsValues[i, 1];
                    f = y - (float.Parse(s) * fdeltay);
                    x1 = x;
                }
                else
                {
                    s1 = rgsValues[i, 0];
                    f1 = y - (float.Parse(s1) * fdeltay);
                    x2 = x + (int)(fdeltax * i);
                    graph1.DrawLine(objPenLine, x1, f, x2, f1);
                    s = rgsValues[i, 0];
                    s2 = rgsValues[i, 1];
                    f = f1;
                    x1 = x + (int)(i * fdeltax);
                }
            }
        }
        public void vDrawTextAxXNumber(bool f)
        {
            float fdeltax = viX - viDeltaaxisL - viDeltaaxisR;
            fdeltax = fdeltax / (float)(viMaxRg - 1);
            float x = viDeltaaxisL;
            float y = viY - viDeltaaxisH + objPenLine.Width;
            for (int i = 1; i < viMaxRg + 1; i++)
            {
                if (!f || i % 2 == 0)
                {
                    graph1.DrawString(Convert.ToString(i), objFont, objBrush, x + (i - 1) * fdeltax, y);
                }
                else
                {
                    graph1.DrawString(Convert.ToString(i),
                     objFont, objBrush, x + (i - 1) * fdeltax, y + objFont.Size);
                }
            }
        }
        public void vDrawTextAxXValues(bool f)
        {
            string s = string.Empty;
            float fdeltax = viX - viDeltaaxisL - viDeltaaxisR;
            fdeltax = fdeltax / (float)(viMaxRg - 1);
            float x = viDeltaaxisL;
            float y = viY - viDeltaaxisH;
            for (int i = 0; i < viMaxRg; i++)
            {
                if (!f || i % 2 == 0)
                {
                    graph1.DrawString(rgsValues[i, 1], objFont, objBrush, x + i * fdeltax, y);
                }
                else
                {
                    graph1.DrawString(rgsValues[i, 1], objFont, objBrush, x + i * fdeltax, y + objFont.Size);
                }
            }
        }
        public void vDrawTextAxYValues()
        {
            string s = string.Empty;
            float f = 0;
            float fMax = float.MinValue;
            for (int i = 0; i < viMaxRg; i++)
            {
                s = rgsValues[i, 0];
                if (fMax < float.Parse(s)) fMax = float.Parse(s);
            }
            f = fMax / (float)(viMaxRg - 1);
            float fdeltay = viY - 2 * viDeltaaxisH;
            fdeltay = fdeltay / (float)(viMaxRg - 1);
            float y = viY - viDeltaaxisH - objFont.Size;
            for (int i = 0; i < viMaxRg; i++)
            {
                graph1.DrawString(((float)(i * f)).ToString("0.00"),
                   objFont, objBrush, viDeltaaxisL - (objFont.Size) * 5 - 5, y - i * fdeltay);
            }
        }
        public void vDrawTextAxYValuesPoint(bool a, bool b)
        {
            string s = string.Empty;
            float fMax = float.MinValue;
            float fSum = 0;
            for (int i = 0; i < viMaxRg; i++)
            {
                s = rgsValues[i, 0];
                fSum += float.Parse(s);
                if (fMax < float.Parse(s)) fMax = float.Parse(s);
            }
            float fdeltax = viX - viDeltaaxisL - viDeltaaxisR;
            fdeltax = fdeltax / (float)(viMaxRg - 1);
            float x = viDeltaaxisL;
            float fdeltay = viY - 2 * viDeltaaxisH;
            float y = viY - viDeltaaxisH - objFont.Size;
            fdeltay = fdeltay / fMax;
            float fdelta = 0;
            for (int i = 0; i < viMaxRg; i++)
            {
                if (a)
                {
                    if (i % 2 == 0) fdelta = objFont.Size;
                    else fdelta = 2 * objFont.Size;
                }
                else
                {
                    fdelta = objFont.Size;
                }
                if (b)
                {
                    graph1.DrawString(rgsValues[i, 0], objFont, objBrush, x + i * fdeltax,
                           y - (float.Parse(rgsValues[i, 0]) * fdeltay) - fdelta);
                }
                else
                {
                    float fp = float.Parse(rgsValues[i, 0]);
                    fp = (fp * 100) / fSum;
                    graph1.DrawString(rgsValues[i, 0] + "-" + fp.ToString("0.0") + "%",
                                    objFont, objBrush, x + i * fdeltax,
                                              y - (float.Parse(rgsValues[i, 0]) * fdeltay) - fdelta);
                }
            }
        }
    }
}
