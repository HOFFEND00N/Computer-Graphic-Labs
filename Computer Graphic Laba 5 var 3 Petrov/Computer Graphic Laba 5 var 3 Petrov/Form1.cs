using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace Computer_Graphic_Laba_5_var_3_Petrov
{
    public partial class Form1 : Form
    {
        Bitmap bitmap;
        private const int imageWidth = 800, imageHeight = 600;
        private Point coordinateGridCenter = new Point(imageWidth / 2, imageHeight / 2);
        private Graphics g;
        private List<float> gridX = new List<float>(), gridY = new List<float>();
        private List<Point> polygonPointList = new List<Point>();
        private float cntDotsToUse = 0;
        private Pen pencil = new Pen(System.Drawing.Color.Black, 2F);
        private int[,] pixelArray = new int[800, 600];
        private int globalY = 9999;
        public Form1()
        {
            InitializeComponent();
            bitmap = new Bitmap(imageWidth, imageHeight);
            pictureBox1.Image = bitmap;
            Go();
        }

        private void Go()
        {
            cntDotsToUse = float.Parse(cntDotsToUseTextBox.Text);
            g = Graphics.FromImage(bitmap);
            g.Clear(Color.White);
            pencil.Color = Color.Black;
            DrawCoordinateGrid();
            DrawPolygon();
            pictureBox1.Image = bitmap;
        }

        private void BuildButton_Click(object sender, EventArgs e)
        {
            cntDotsToUse = float.Parse(cntDotsToUseTextBox.Text);
            ClearData();
            FormPolygonList();
            for (int i = 0; i < cntDotsToUse - 1; i++)
                StartRasterization(polygonPointList[i], polygonPointList[i + 1]);
            StartRasterization(polygonPointList[(int)cntDotsToUse - 1], polygonPointList[0]);
            for (int i = 0; i < cntDotsToUse; i++)
            {
                Tuple<float, float> vectorA, vectorB;
                Tuple<float, float> horizontal = MakeVector(polygonPointList[i], new Point(polygonPointList[i].X + 1, polygonPointList[i].Y));
                if (i == 0)
                {
                    vectorA = MakeVector(polygonPointList[i], polygonPointList[i + 1]);
                    vectorB = MakeVector(polygonPointList[i], polygonPointList[(int)cntDotsToUse - 1]);
                }
                else if (i == cntDotsToUse - 1)
                {
                    vectorA = MakeVector(polygonPointList[i], polygonPointList[i - 1]);
                    vectorB = MakeVector(polygonPointList[i], polygonPointList[0]);
                }
                else
                {
                    vectorA = MakeVector(polygonPointList[i], polygonPointList[i + 1]);
                    vectorB = MakeVector(polygonPointList[i], polygonPointList[i - 1]);
                }
                var p1 = PseudoScalarProduct(horizontal, vectorA);
                var p2 = PseudoScalarProduct(horizontal, vectorB);
                if ((p1 > 0 && p2 > 0) || (p1 < 0 && p2 < 0))
                    pixelArray[(int)polygonPointList[i].X * 20 + (int)coordinateGridCenter.X + 1,
                            -(int)polygonPointList[i].Y * 20 + (int)coordinateGridCenter.Y] = 1;
            }
            for (int i = 0; i < cntDotsToUse; i++)
            {
                var tmp = -(int)polygonPointList[i].Y * 20 + (int)coordinateGridCenter.Y;
                if (tmp < globalY)
                    globalY = tmp;
            }
            Go();
        }

        private float PseudoScalarProduct(Tuple<float, float> vectorA, Tuple<float, float> vectorB)
        {
            return vectorA.Item1 * vectorB.Item2 - vectorA.Item2 * vectorB.Item1;
        }

        private void StartXORAlgo()
        {
            if (globalY < imageHeight)
            {
                for (int y = globalY; y < imageHeight && y < globalY + 30; y++)
                {
                    for (int x = 1; x < imageWidth; x++)
                    {
                        pixelArray[x, y] = pixelArray[x, y] ^ pixelArray[x - 1, y];
                    }
                }
                globalY += 30;
            }
        }

        private void ClearData()
        {
            polygonPointList.Clear();
            for (int i = 0; i < imageWidth; i++)
                for (int j = 0; j < imageHeight; j++)
                    pixelArray[i, j] = 0;
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

        private void DrawPolygon()
        {
            if (polygonPointList.Count != 0)
            {
                for (int i = 0; i < imageWidth; i++)
                {
                    for (int j = 0; j < imageHeight; j++)
                    {
                        if (pixelArray[i, j] == 1)
                            bitmap.SetPixel(i, j, Color.Black);
                    }
                }
            }
        }
        private void FormPolygonList()
        {
            polygonPointList.Add(new Point(float.Parse(V1xTextBox.Text), float.Parse(V1yTextBox.Text)));
            polygonPointList.Add(new Point(float.Parse(V2xTextBox.Text), float.Parse(V2yTextBox.Text)));
            polygonPointList.Add(new Point(float.Parse(V3xTextBox.Text), float.Parse(V3yTextBox.Text)));
            polygonPointList.Add(new Point(float.Parse(V4xTextBox.Text), float.Parse(V4yTextBox.Text)));
            polygonPointList.Add(new Point(float.Parse(V5xTextBox.Text), float.Parse(V5yTextBox.Text)));
            polygonPointList.Add(new Point(float.Parse(V6xTextBox.Text), float.Parse(V6yTextBox.Text)));
        }

        private void StartRasterization(Point A, Point B)
        {
            Point startPoint = new Point(A.X * 20 + coordinateGridCenter.X, -A.Y * 20 + coordinateGridCenter.Y);
            Point endPoint = new Point(B.X * 20 + coordinateGridCenter.X, -B.Y * 20 + coordinateGridCenter.Y);
            float tmp;
            if (startPoint.Y > endPoint.Y)
            {
                tmp = startPoint.X;
                startPoint.X = endPoint.X;
                endPoint.X = tmp;

                tmp = startPoint.Y;
                startPoint.Y = endPoint.Y;
                endPoint.Y = tmp;
            }
            Line line = MakeLineEquation(startPoint, endPoint);
            for (var y = startPoint.Y; y <= endPoint.Y; y++)
            {
                if (line.A == 0)
                    pixelArray[(int)startPoint.X, (int)y] = 1;
                else
                {
                    var x = -(line.C + line.B * y) / line.A;
                    pixelArray[(int)(x), (int)y] = 1;
                }
            }
            if (startPoint.Y > endPoint.Y)
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

        private void StartButton_Click(object sender, EventArgs e)
        {
            StartXORAlgo();
            if (globalY >= 800)
            {
                for (int i = 0; i < cntDotsToUse - 1; i++)
                    StartRasterization(polygonPointList[i], polygonPointList[i + 1]);
                StartRasterization(polygonPointList[(int)cntDotsToUse - 1], polygonPointList[0]);
            }
            Go();
        }

        public Line MakeLineEquation(Point A, Point B)
        {
            float a = A.Y - B.Y, b = B.X - A.X, c = A.X * B.Y - A.Y * B.X;
            return new Line(a, b, c);
        }

        public float DotProduction(Tuple<float, float> vectorA, Tuple<float, float> vectorB)
        {
            return vectorA.Item1 * vectorB.Item1 + vectorA.Item2 * vectorB.Item2;
        }

        public Tuple<float, float> MakeNormal(Line l)
        {
            return new Tuple<float, float>(l.A, l.B);
        }
        public Tuple<float, float> MakeVector(Point start, Point end)
        {
            return new Tuple<float, float>(end.X - start.X, end.Y - start.Y);
        }
    }
    public class Point
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

    public class Line
    {
        private float a, b, c;
        public float A
        {
            set { a = value; }
            get { return a; }
        }
        public float B
        {
            set { b = value; }
            get { return b; }
        }
        public float C
        {
            set { c = value; }
            get { return c; }
        }

        public Line(float _a, float _b, float _c)
        {
            a = _a;
            b = _b;
            c = _c;
        }
        public Tuple<float, float> GetNormal(Line line)
        {
            return new Tuple<float, float>(line.A, line.B);
        }
    }

}
