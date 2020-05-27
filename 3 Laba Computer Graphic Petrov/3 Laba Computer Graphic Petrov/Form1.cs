using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _3_Laba_Computer_Graphic_Petrov
{
    public enum ProgrammMode
    {
        Circle,
        Segment,
        Undefined
    }
    public partial class Form1 : Form
    {
        Bitmap bitmap;
        private const int imageWidth = 800, imageHeight = 600;
        private Point coordinateGridCenter = new Point(imageWidth / 2, imageHeight / 2);
        private List<Point> SegmentAlgoPoints = new List<Point>(), CircleAlgoPoints = new List<Point>();
        private Point startPoint = new Point(), endPoint = new Point();
        private Graphics g;
        private List<float> gridX = new List<float>();
        private List<float> gridY = new List<float>();
        private float Ox, Oy, R;
        ProgrammMode Mode = ProgrammMode.Undefined;
        public Form1()
        {
            InitializeComponent();
            bitmap = new Bitmap(imageWidth, imageHeight);
            pictureBox1.Image = bitmap;
            Go();
        }
        private void DrawCoordinateGrid()
        {
            InitializeCoordinateGrid();
            Pen pencil = new Pen(System.Drawing.Color.LightGray);
            for (int i = 0; i < gridX.Count; i++)
            {
                g.DrawLine(pencil, gridX[i], 0, gridX[i], imageHeight);
            }
            for (int i = 0; i < gridY.Count; i++)
            {
                g.DrawLine(pencil, 0, gridY[i], imageWidth, gridY[i]);
            }
            pencil.Color = Color.Black;
            pencil.Width = 1;
            g.DrawLine(pencil, coordinateGridCenter.X, imageHeight, coordinateGridCenter.X, 0);
            g.DrawLine(pencil, 0, coordinateGridCenter.Y, imageWidth, coordinateGridCenter.Y);
        }
        private void InitializeCoordinateGrid()
        {
            for (float i = 0; i <= imageWidth; i += 20)
                gridX.Add(i);
            for (float i = 0; i <= imageHeight; i += 20)
                gridY.Add(i);
        }

        private void BuildCircleButton_Click(object sender, EventArgs e)
        {
            R = float.Parse(RTextBox.Text);
            Ox = float.Parse(OxTextBox.Text);
            Oy = float.Parse(OyTextBox.Text);
            Mode = ProgrammMode.Circle;
            Go();
        }

        private void AlgorithmButton_Click(object sender, EventArgs e)
        {
            var steep = Math.Abs(endPoint.Y - startPoint.Y) > Math.Abs(endPoint.X - startPoint.X);
            float tmp;
            if (steep)
            {
                tmp = startPoint.X;
                startPoint.X = startPoint.Y;
                startPoint.Y = tmp;

                tmp = endPoint.X;
                endPoint.X = endPoint.Y;
                endPoint.Y = tmp;
            }

            if (startPoint.X > endPoint.X)
            {
                tmp = startPoint.X;
                startPoint.X = endPoint.X;
                endPoint.X = tmp;

                tmp = startPoint.Y;
                startPoint.Y = endPoint.Y;
                endPoint.Y = tmp;
            }
            float dx = endPoint.X - startPoint.X;
            float dy = Math.Abs(endPoint.Y - startPoint.Y);
            float error = dx;
            float ystep = (startPoint.Y < endPoint.Y) ? 1 : -1;
            float y = startPoint.Y;
            for (var x = startPoint.X; x <= endPoint.X; x++)
            {
                SegmentAlgoPoints.Add(new Point(steep ? y : x, steep ? x : y));
                error -= 2 * dy;
                if (error < 0)
                {
                    y += ystep;
                    error += 2 * dx;
                }
            }
            if (steep)
            {
                tmp = startPoint.X;
                startPoint.X = startPoint.Y;
                startPoint.Y = tmp;

                tmp = endPoint.X;
                endPoint.X = endPoint.Y;
                endPoint.Y = tmp;
            }
            if (startPoint.X < endPoint.X)
            {
                tmp = startPoint.X;
                startPoint.X = endPoint.X;
                endPoint.X = tmp;

                tmp = startPoint.Y;
                startPoint.Y = endPoint.Y;
                endPoint.Y = tmp;
            }
            Go();
        }

        private void CircleAlgoButton_Click(object sender, EventArgs e)
        {
            var x = 0;
            var y = R;
            var d = 3 - 2 * R;
            DrawCircle(Ox, Oy, x, y);
            while (y >= x)
            {
                x++;
                if (d > 0)
                {
                    y--;
                    d += 2 * (x - y) + 5;
                }
                else
                    d += 2 * x + 3;
                DrawCircle(Ox, Oy, x, y);
            }
            Go();
        }

        private void DrawCircle(float Ox, float Oy, int x, float y)
        {
            CircleAlgoPoints.Add(new Point(Ox + x, Oy + y));
            CircleAlgoPoints.Add(new Point(Ox - x, Oy + y));
            CircleAlgoPoints.Add(new Point(Ox + x, Oy - y));
            CircleAlgoPoints.Add(new Point(Ox - x, Oy - y));
            CircleAlgoPoints.Add(new Point(Ox + y, Oy + x));
            CircleAlgoPoints.Add(new Point(Ox - y, Oy + x));
            CircleAlgoPoints.Add(new Point(Ox + y, Oy - x));
            CircleAlgoPoints.Add(new Point(Ox - y, Oy - x));
        }

        private void BuildSegmentButton_Click(object sender, EventArgs e)
        {
            startPoint.X = float.Parse(x1TextBox.Text);
            startPoint.Y = float.Parse(y1TextBox.Text);
            endPoint.X = float.Parse(x2TextBox.Text);
            endPoint.Y = float.Parse(y2TextBox.Text);
            Mode = ProgrammMode.Segment;
            Go();
        }
        private void Go()
        {
            g = Graphics.FromImage(bitmap);
            g.Clear(Color.White);
            DrawCoordinateGrid();
            Pen pencil = new Pen(System.Drawing.Color.Black);
            if (Mode == ProgrammMode.Segment)
            {
                g.DrawLine(pencil, startPoint.X * 20 + coordinateGridCenter.X, -startPoint.Y * 20 + coordinateGridCenter.Y,
                                    endPoint.X * 20 + coordinateGridCenter.X, -endPoint.Y * 20 + coordinateGridCenter.Y);
                foreach (var i in SegmentAlgoPoints)
                {
                    g.FillEllipse(new SolidBrush(Color.Red), i.X * 20 + coordinateGridCenter.X, -i.Y * 20 + coordinateGridCenter.Y, 3, 3);
                }
                SegmentAlgoPoints.Clear();
            }
            else if (Mode == ProgrammMode.Circle)
            {
                g.DrawEllipse(new Pen(Color.Black), coordinateGridCenter.X + Ox * 20 - R * 20, coordinateGridCenter.Y - Oy * 20 - R * 20, R * 40, R * 40);
                foreach (var i in CircleAlgoPoints)
                {
                    g.FillEllipse(new SolidBrush(Color.Red), i.X * 20 + coordinateGridCenter.X, -i.Y * 20 + coordinateGridCenter.Y, 3, 3);
                }
                CircleAlgoPoints.Clear();
            }
            pictureBox1.Image = bitmap;
        }
    }

    class Point
    {
        private float x, y;
        public float X
        {
            get { return x; }
            set { x = value; }
        }
        public float Y
        {
            get { return y; }
            set { y = value; }
        }

        public Point(float _x, float _y)
        {
            x = _x;
            y = _y;
        }
        public Point()
        {
            x = 0;
            y = 0;
        }
    }
}
