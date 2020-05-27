using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace _4_Laba_Computer_Graphic_Petrov
{
    enum Mode
    {
        SC,
        CB,
        MP,
        Undefined
    }
    public partial class Form1 : Form
    {
        Bitmap bitmap;
        private const int imageWidth = 800, imageHeight = 600;
        private Point coordinateGridCenter = new Point(imageWidth / 2, imageHeight / 2), startAnswerPoint = new Point(),
            endAnswerPoint = new Point();
        private Graphics g;
        private List<float> gridX = new List<float>(), gridY = new List<float>();
        private List<Point> polygonPointList = new List<Point>();
        private Point startSegmentPoint = new Point(), endSegmentPoint = new Point();
        private float cntDotsToUse = 0;
        private Pen pencil = new Pen(System.Drawing.Color.Black, 2F);
        private List<Line> polygonLineList = new List<Line>();
        private List<Tuple<float, float>> normalsList = new List<Tuple<float, float>>();
        private List<float> TList = new List<float>();
        private List<Point> intersectionDotsList = new List<Point>();
        private float PEDot, PlDot;
        private List<float> potentiallyEnteringDots = new List<float>(), potentiallyLeavingDots = new List<float>();
        private const int INSIDE = 0; // 0000 
        private const int LEFT = 1; // 0001 
        private const int RIGHT = 2; // 0010 
        private const int BOTTOM = 4; // 0100 
        private const int TOP = 8; // 1000 
        bool flag = false;
        bool isOut = false;
        Mode programMode = Mode.Undefined;
        private List<Tuple<Point, Point>> answerPointsList = new List<Tuple<Point, Point>>(); 

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

        private void BuildButton_Click(object sender, EventArgs e)
        {
            ClearData();
            FormSegment();
            FormPolygonList();
            Go();
        }

        private void ClearData()
        {
            polygonPointList.Clear();
            polygonLineList.Clear();
            normalsList.Clear();
            TList.Clear();
            answerPointsList.Clear();
            intersectionDotsList.Clear();
            potentiallyEnteringDots.Clear();
            potentiallyLeavingDots.Clear();
            startAnswerPoint = new Point();
            endAnswerPoint = new Point();
            PEDot = 0;
            PlDot = 0;
            flag = false;
            isOut = false;
        }

        private void FormSegment()
        {
            startSegmentPoint.X = float.Parse(AxTextBox.Text);
            startSegmentPoint.Y = float.Parse(AyTextBox.Text);
            endSegmentPoint.X = float.Parse(BxTextBox.Text);
            endSegmentPoint.Y = float.Parse(ByTextBox.Text);
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

        private void DrawBack()
        {
            polygonLineList.Clear();
            normalsList.Clear();
            TList.Clear();
            intersectionDotsList.Clear();
            potentiallyEnteringDots.Clear();
            potentiallyLeavingDots.Clear();
            startAnswerPoint = new Point();
            endAnswerPoint = new Point();
            PEDot = 0;
            PlDot = 0;
        }

        private void DrawIntersectionDots()
        {
            pencil.Color = Color.Red;
            MakeIntersectionDots();
            foreach (var i in intersectionDotsList)
                g.DrawEllipse(pencil, i.X * 20 + coordinateGridCenter.X - 1.5F, -i.Y * 20 + coordinateGridCenter.Y - 1.5F, 3, 3);
        }

        private void MakeIntersectionDots()
        {
            foreach (var i in TList)
                intersectionDotsList.Add(new Point(startSegmentPoint.X + (endSegmentPoint.X - startSegmentPoint.X) * i,
                                                   startSegmentPoint.Y + (endSegmentPoint.Y - startSegmentPoint.Y) * i));
        }

        private void CalculateParamT()
        {
            for (int i = 0; i < (int)cntDotsToUse; i++)
            {
                var numerator = DotProduction(MakeVector(polygonPointList[i], startSegmentPoint), normalsList[i]);
                var denumerator = DotProduction(MakeVector(startSegmentPoint, endSegmentPoint), normalsList[i]);
                var t = -numerator / denumerator;
                TList.Add(t);

                if (denumerator < 0 && denumerator != 0)
                    potentiallyEnteringDots.Add(t);
                else
                    if (denumerator > 0 && denumerator != 0)
                    potentiallyLeavingDots.Add(t);
                if (numerator > 0 && denumerator == 0)
                    isOut = true;
            }
        }

        private void MakeNormals(List<Line> lineList)
        {
            foreach (var i in lineList)
                normalsList.Add(new Tuple<float, float>(i.A, i.B));
        }

        private void BuildPolygonLines()
        {
            for (var i = 0; i < cntDotsToUse - 1; i++)
                polygonLineList.Add(MakeLineEquation(polygonPointList[i + 1], polygonPointList[i]));

            polygonLineList.Add(MakeLineEquation(polygonPointList[0], polygonPointList[(int)cntDotsToUse - 1]));
        }

        private void Go()
        {
            cntDotsToUse = float.Parse(cntDotsToUseTextBox.Text);
            g = Graphics.FromImage(bitmap);
            g.Clear(Color.White);
            pencil.Color = Color.Black;
            DrawCoordinateGrid();
            DrawSegment();
            DrawPolygon();
            if (programMode == Mode.CB)
                DrawIntersectionDots();
            DrawAnswer();
            pictureBox1.Image = bitmap;
        }

        private void DrawAnswer()
        {
            if (programMode == Mode.CB)
                MakeAnswer();
            pencil.Color = Color.Aqua;
            if (programMode == Mode.CB || (programMode == Mode.SC && flag == true))
                g.DrawLine(pencil, startAnswerPoint.X * 20 + coordinateGridCenter.X, -startAnswerPoint.Y * 20 + coordinateGridCenter.Y,
                                    endAnswerPoint.X * 20 + coordinateGridCenter.X, -endAnswerPoint.Y * 20 + coordinateGridCenter.Y);
            if(programMode == Mode.MP)
            {
                foreach(var i in answerPointsList)
                {
                    g.DrawLine(pencil, i.Item1.X * 20 + coordinateGridCenter.X, -i.Item1.Y * 20 + coordinateGridCenter.Y, 
                        i.Item2.X * 20 + coordinateGridCenter.X, -i.Item2.Y * 20 + coordinateGridCenter.Y);
                }
            }
        }

        private void MakeAnswer()
        {
            startAnswerPoint.X = startSegmentPoint.X + (endSegmentPoint.X - startSegmentPoint.X) * PEDot;
            startAnswerPoint.Y = startSegmentPoint.Y + (endSegmentPoint.Y - startSegmentPoint.Y) * PEDot;

            endAnswerPoint.X = startSegmentPoint.X + (endSegmentPoint.X - startSegmentPoint.X) * PlDot;
            endAnswerPoint.Y = startSegmentPoint.Y + (endSegmentPoint.Y - startSegmentPoint.Y) * PlDot;
        }

        private void StartAlgoCBButton_Click(object sender, EventArgs e)
        {
            programMode = Mode.CB;
            BuildPolygonLines();
            MakeNormals(polygonLineList);
            CalculateParamT();
            potentiallyEnteringDots.Add(0F);
            potentiallyLeavingDots.Add(1F);
            PEDot = MaximumInList(potentiallyEnteringDots);
            PlDot = MinimumInList(potentiallyLeavingDots);
            if (PlDot < PEDot || isOut == true)
            {
                DrawBack();
            }
            Go();
        }

        private void StartAlgoSCButton_Click(object sender, EventArgs e)
        {
            programMode = Mode.SC;
            int startSegmentPointCode = CalculateCodeForPoint(startSegmentPoint);
            int endSegmentPointCode = CalculateCodeForPoint(endSegmentPoint);
            while (true)
            {
                if (startSegmentPointCode == 0 && endSegmentPointCode == 0)
                {
                    flag = true;
                    break;
                }
                else if ((startSegmentPointCode & endSegmentPointCode) != 0)
                {
                    break;
                }
                else
                {
                    int pointToMoveCode;
                    float x = 0, y = 0;
                    if (startSegmentPointCode != 0)
                        pointToMoveCode = startSegmentPointCode;
                    else
                        pointToMoveCode = endSegmentPointCode;
                    if ((pointToMoveCode & TOP) != 0)
                    {
                        x = startSegmentPoint.X + (endSegmentPoint.X - startSegmentPoint.X) * (polygonPointList[2].Y - startSegmentPoint.Y) /
                            (endSegmentPoint.Y - startSegmentPoint.Y);
                        y = polygonPointList[2].Y;
                    }
                    else if ((pointToMoveCode & BOTTOM) != 0)
                    {
                        x = startSegmentPoint.X + (endSegmentPoint.X - startSegmentPoint.X) * (polygonPointList[0].Y - startSegmentPoint.Y) /
                            (endSegmentPoint.Y - startSegmentPoint.Y);
                        y = polygonPointList[0].Y;
                    }
                    else if ((pointToMoveCode & RIGHT) != 0)
                    {
                        y = startSegmentPoint.Y + (endSegmentPoint.Y - startSegmentPoint.Y) * (polygonPointList[2].X - startSegmentPoint.X) /
                            (endSegmentPoint.X - startSegmentPoint.X);
                        x = polygonPointList[2].X;
                    }
                    else if ((pointToMoveCode & LEFT) != 0)
                    {
                        y = startSegmentPoint.Y + (endSegmentPoint.Y - startSegmentPoint.Y) * (polygonPointList[0].X - startSegmentPoint.X) /
                            (endSegmentPoint.X - startSegmentPoint.X);
                        x = polygonPointList[0].X;
                    }

                    if (pointToMoveCode == startSegmentPointCode)
                    {
                        startAnswerPoint.X = x;
                        startAnswerPoint.Y = y;
                        startSegmentPointCode = CalculateCodeForPoint(startAnswerPoint);
                    }
                    else
                    {
                        endAnswerPoint.X = x;
                        endAnswerPoint.Y = y;
                        endSegmentPointCode = CalculateCodeForPoint(endAnswerPoint);
                    }
                }
            }
            Go();
        }

        private int CalculateCodeForPoint(Point point)
        {
            int code = INSIDE;
            if (point.X < polygonPointList[0].X)
                code |= LEFT;
            else if (point.X > polygonPointList[2].X)
                code |= RIGHT;
            if (point.Y < polygonPointList[0].Y)
                code |= BOTTOM;
            else if (point.Y > polygonPointList[2].Y)
                code |= TOP;
            return code;
        }

        private void StartAlgoMPButton_Click(object sender, EventArgs e)
        {
            programMode = Mode.MP;
            MPAlgo(startSegmentPoint, endSegmentPoint);
            Go();
        }

        private void MPAlgo(Point A, Point B)
        {
            int startSegmentPointCode = CalculateCodeForPoint(A);
            int endSegmentPointCode = CalculateCodeForPoint(B);
            if (((startSegmentPointCode & endSegmentPointCode) != 0)
            || (DistanceBetweenPoints(A, B) < 0.01))
                return;
            if (startSegmentPointCode == 0 && endSegmentPointCode == 0)
                answerPointsList.Add(Tuple.Create(new Point(A.X, A.Y),new Point(B.X, B.Y)));
            else
            {
                Point C = new Point((A.X + B.X) / 2, (A.Y + B.Y) / 2);
                MPAlgo(A, C);
                MPAlgo(C, B);
            }
        }

        private void DrawSegment()
        {
            g.DrawLine(pencil, startSegmentPoint.X * 20 + coordinateGridCenter.X, -startSegmentPoint.Y * 20 + coordinateGridCenter.Y,
                                    endSegmentPoint.X * 20 + coordinateGridCenter.X, -endSegmentPoint.Y * 20 + coordinateGridCenter.Y);
        }

        private void DrawPolygon()
        {
            if (polygonPointList.Count != 0)
            {
                for (var i = 0; i < cntDotsToUse - 1; i++)
                {
                    g.DrawLine(pencil, polygonPointList[i].X * 20 + coordinateGridCenter.X,
                            -polygonPointList[i].Y * 20 + coordinateGridCenter.Y,
                            polygonPointList[i + 1].X * 20 + coordinateGridCenter.X,
                            -polygonPointList[i + 1].Y * 20 + coordinateGridCenter.Y);
                }
                g.DrawLine(pencil, polygonPointList[0].X * 20 + coordinateGridCenter.X,
                            -polygonPointList[0].Y * 20 + coordinateGridCenter.Y,
                            polygonPointList[(int)cntDotsToUse - 1].X * 20 + coordinateGridCenter.X,
                            -polygonPointList[(int)cntDotsToUse - 1].Y * 20 + coordinateGridCenter.Y);
            }
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

        public Tuple<float, float> MakeVector(Point start, Point end)
        {
            return new Tuple<float, float>(end.X - start.X, end.Y - start.Y);
        }

        public float MaximumInList(List<float> list)
        {
            var tmp = list[0];
            foreach (var item in list)
                if (item > tmp)
                    tmp = item;
            return tmp;
        }
        public float MinimumInList(List<float> list)
        {
            var tmp = list[0];
            foreach (var item in list)
                if (item < tmp)
                    tmp = item;
            return tmp;
        }

        public float DistanceBetweenPoints(Point A, Point B)
        {
            return (float)Math.Sqrt(Math.Pow((A.X - B.X), 2) + Math.Pow((A.Y - B.Y), 2));
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
