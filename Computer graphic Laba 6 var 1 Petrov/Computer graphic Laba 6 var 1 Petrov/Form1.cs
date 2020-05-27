using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Computer_graphic_Laba_6_var_1_Petrov
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
        private List<dotType> dotTypeList = new List<dotType>();
        private List<Point> outsideTrianglePointList = new List<Point>();
        private int globalI = 1, globalJ = 1;
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
            DrawConvexHull();
            DrawPolygon();
            pictureBox1.Image = bitmap;
        }

        private void DrawConvexHull()
        {
            if (outsideTrianglePointList.Count > 0)
            {
                for (int i = 0; i < outsideTrianglePointList.Count - 1; i++)
                    g.DrawLine(pencil, outsideTrianglePointList[i].X * 20 + coordinateGridCenter.X,
                        -outsideTrianglePointList[i].Y * 20 + coordinateGridCenter.Y,
                        outsideTrianglePointList[i + 1].X * 20 + coordinateGridCenter.X,
                        -outsideTrianglePointList[i + 1].Y * 20 + coordinateGridCenter.Y);
                g.DrawLine(pencil, outsideTrianglePointList[0].X * 20 + coordinateGridCenter.X,
                    -outsideTrianglePointList[0].Y * 20 + coordinateGridCenter.Y,
                    outsideTrianglePointList[outsideTrianglePointList.Count - 1].X * 20 + coordinateGridCenter.X,
                    -outsideTrianglePointList[outsideTrianglePointList.Count - 1].Y * 20 + coordinateGridCenter.Y);
            }
        }

        private void BuildButton_Click(object sender, EventArgs e)
        {
            ClearData();
            FormPolygonList();
            FormDotTypeList();
            Go();
        }

        private void FormDotTypeList()
        {
            for (int i = 0; i < 9; i++)
                dotTypeList.Add(dotType.undefined);
        }

        private void DrawPolygon()
        {
            if (polygonPointList.Count != 0)
            {
                pencil.Color = Color.Red;
                for (int i = 0; i < cntDotsToUse; i++)
                {
                    g.DrawEllipse(pencil, polygonPointList[i].X * 20 + coordinateGridCenter.X - 1,
                        -polygonPointList[i].Y * 20 + coordinateGridCenter.Y - 1, 2, 2);
                }
                pencil.Color = Color.Black;
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
            polygonPointList.Add(new Point(float.Parse(V7xTextBox.Text), float.Parse(V7yTextBox.Text)));
            polygonPointList.Add(new Point(float.Parse(V8xTextBox.Text), float.Parse(V8yTextBox.Text)));
            polygonPointList.Add(new Point(float.Parse(V9xTextBox.Text), float.Parse(V9yTextBox.Text)));
        }

        private void ClearData()
        {
            polygonPointList.Clear();
            dotTypeList.Clear();
            outsideTrianglePointList.Clear();
            globalI = 1;
            globalJ = 1;
        }

        private void StartButton_Click(object sender, EventArgs e)
        {
            if (outsideTrianglePointList.Count == 0)
                CalculateDotTypes();
            var startPoint = outsideTrianglePointList[0];
            for (int i = globalI; i < outsideTrianglePointList.Count; i++)
            {
                for (int j = globalJ; j < outsideTrianglePointList.Count; j++)
                {
                    var v1 = MakeVector(startPoint, outsideTrianglePointList[i]);
                    var v2 = MakeVector(startPoint, outsideTrianglePointList[j]);
                    if (PseudoScalarProduct(v1, v2) < 0)
                    {
                        var tmp = outsideTrianglePointList[i].X;
                        outsideTrianglePointList[i].X = outsideTrianglePointList[j].X;
                        outsideTrianglePointList[j].X = tmp;

                        tmp = outsideTrianglePointList[i].Y;
                        outsideTrianglePointList[i].Y = outsideTrianglePointList[j].Y;
                        outsideTrianglePointList[j].Y = tmp;

                        globalI = i;
                        globalJ = j;
                        Go();
                        return;
                    }
                }
            }

            globalI = outsideTrianglePointList.Count;
            globalJ = outsideTrianglePointList.Count;
        }

        private void CalculateDotTypes()
        {
            for (int i = 0; i < cntDotsToUse; i++)
                for (int j = 0; j < cntDotsToUse; j++)
                    for (int k = 0; k < cntDotsToUse; k++)
                    {
                        for (int dot = 0; dot < cntDotsToUse; dot++)
                        {
                            if (dot != i && dot != j && dot != k && i != j && i != k && j != k)
                            {
                                if (CheckPointInsideTriangle(polygonPointList[dot], polygonPointList[i],
                                    polygonPointList[j], polygonPointList[k]))
                                    dotTypeList[dot] = dotType.inside;
                            }
                        }
                    }
            for (int i = 0; i < cntDotsToUse; i++)
                if (dotTypeList[i] != dotType.inside)
                {
                    dotTypeList[i] = dotType.outside;
                    outsideTrianglePointList.Add(polygonPointList[i]);
                }
        }

        private bool CheckPointInsideTriangle(Point s, Point a, Point b, Point c)
        {
            float d1, d2, d3;
            bool has_neg, has_pos;
            d1 = sign(s, a, b);
            d2 = sign(s, b, c);
            d3 = sign(s, c, a);
            has_neg = (d1 < 0) || (d2 < 0) || (d3 < 0);
            has_pos = (d1 > 0) || (d2 > 0) || (d3 > 0);
            if (d1 == d2 && d2 == d3 && d3 == 0)
                return false;
            return !(has_neg && has_pos);
        }

        private float sign(Point p1, Point p2, Point p3)
        {
            return (p1.X - p3.X) * (p2.Y - p3.Y) - (p2.X - p3.X) * (p1.Y - p3.Y);
        }

        private float PseudoScalarProduct(Tuple<float, float> vectorA, Tuple<float, float> vectorB)
        {
            return vectorA.Item1 * vectorB.Item2 - vectorA.Item2 * vectorB.Item1;
        }
        public Tuple<float, float> MakeVector(Point start, Point end)
        {
            return new Tuple<float, float>(end.X - start.X, end.Y - start.Y);
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

    public enum dotType
    {
        undefined,
        inside,
        outside
    }

}
