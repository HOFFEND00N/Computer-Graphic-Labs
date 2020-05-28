using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace Petrov_Laba_2_Computer_Graphic_var_1
{
    public partial class Form1 : Form
    {
        private Point coordinateGridCenter = new Point(imageWidth / 2, imageHeight / 2, 1);
        private Graphics g;
        private List<float> gridX = new List<float>();
        private List<float> gridY = new List<float>();
        private float transformX = 400, transformY = 300;
        private Bitmap bitmap;
        private const int imageWidth = 800, imageHeight = 600;
        private Point circle = new Point(0, 0),
            rectangle1 = new Point(-150, -150), rectangle2 = new Point(-150, 150),
            rectangle3 = new Point(150, 150), rectangle4 = new Point(150, -150),
            rhomb1 = new Point(-200, 0), rhomb2 = new Point(0, -200),
            rhomb3 = new Point(0, 200), rhomb4 = new Point(200, 0), pointRotate = new Point();
        private float circleWidth = 200, circleHeight = 200;
        private float OxMove = 0, OyMove = 0, rotateAngle = 0;

        private void ZoomOxMinusButton_Click(object sender, EventArgs e)
        {
            float[,] matrix = new float[3, 3] { { 0.8F, 0, 0 }, { 0, 1, 0 }, { 0, 0, 1 } };
            circle.X = circle.X + circleWidth - circleWidth * 0.9F;
            circleWidth *= 0.8F;
            rectangle1 = MatrixMultiplyPoint(matrix, rectangle1);
            rectangle2 = MatrixMultiplyPoint(matrix, rectangle2);
            rectangle3 = MatrixMultiplyPoint(matrix, rectangle3);
            rectangle4 = MatrixMultiplyPoint(matrix, rectangle4);
            rhomb1 = MatrixMultiplyPoint(matrix, rhomb1);
            rhomb2 = MatrixMultiplyPoint(matrix, rhomb2);
            rhomb3 = MatrixMultiplyPoint(matrix, rhomb3);
            rhomb4 = MatrixMultiplyPoint(matrix, rhomb4);
            DrawFigure();
        }

        private void ZoomOxPlusButton_Click(object sender, EventArgs e)
        {
            float[,] matrix = new float[3, 3] { { 1.2F, 0, 0 }, { 0, 1, 0 }, { 0, 0, 1 } };
            circle.X = circle.X + circleWidth - circleWidth * 1.1F;
            circleWidth *= 1.2F;
            rectangle1 = MatrixMultiplyPoint(matrix, rectangle1);
            rectangle2 = MatrixMultiplyPoint(matrix, rectangle2);
            rectangle3 = MatrixMultiplyPoint(matrix, rectangle3);
            rectangle4 = MatrixMultiplyPoint(matrix, rectangle4);
            rhomb1 = MatrixMultiplyPoint(matrix, rhomb1);
            rhomb2 = MatrixMultiplyPoint(matrix, rhomb2);
            rhomb3 = MatrixMultiplyPoint(matrix, rhomb3);
            rhomb4 = MatrixMultiplyPoint(matrix, rhomb4);
            DrawFigure();
        }

        private void InititalizeData()
        {
            circle = new Point(0, 0);
            rectangle1 = new Point(-150, -150);
            rectangle2 = new Point(-150, 150);
            rectangle3 = new Point(150, 150);
            rectangle4 = new Point(150, -150);
            rhomb1 = new Point(-200, 0);
            rhomb2 = new Point(0, -200);
            rhomb3 = new Point(0, 200);
            rhomb4 = new Point(200, 0);
            circleWidth= 200;
            circleHeight = 200;
        }

        private void ZoomOyPlusButton_Click(object sender, EventArgs e)
        {
            float[,] matrix = new float[3, 3] { { 1, 0, 0 }, { 0, 1.2F, 0 }, { 0, 0, 1 } };
            circle.Y = circle.Y - circleHeight + circleHeight * 1.1F;
            circleHeight *= 1.2F;
            rectangle1 = MatrixMultiplyPoint(matrix, rectangle1);
            rectangle2 = MatrixMultiplyPoint(matrix, rectangle2);
            rectangle3 = MatrixMultiplyPoint(matrix, rectangle3);
            rectangle4 = MatrixMultiplyPoint(matrix, rectangle4);
            rhomb1 = MatrixMultiplyPoint(matrix, rhomb1);
            rhomb2 = MatrixMultiplyPoint(matrix, rhomb2);
            rhomb3 = MatrixMultiplyPoint(matrix, rhomb3);
            rhomb4 = MatrixMultiplyPoint(matrix, rhomb4);
            DrawFigure();
        }

        private void ZoomOyMinusButton_Click(object sender, EventArgs e)
        {
            float[,] matrix = new float[3, 3] { { 1, 0, 0 }, { 0, 0.8F, 0 }, { 0, 0, 1 } };
            circle.Y = circle.Y - circleHeight + circleHeight * 0.9F;
            circleHeight *= 0.8F;
            rectangle1 = MatrixMultiplyPoint(matrix, rectangle1);
            rectangle2 = MatrixMultiplyPoint(matrix, rectangle2);
            rectangle3 = MatrixMultiplyPoint(matrix, rectangle3);
            rectangle4 = MatrixMultiplyPoint(matrix, rectangle4);
            rhomb1 = MatrixMultiplyPoint(matrix, rhomb1);
            rhomb2 = MatrixMultiplyPoint(matrix, rhomb2);
            rhomb3 = MatrixMultiplyPoint(matrix, rhomb3);
            rhomb4 = MatrixMultiplyPoint(matrix, rhomb4);
            DrawFigure();
        }

        private void rotateFigureAboutPointButton_Click(object sender, EventArgs e)
        {
            rotateAngle = float.Parse(rotateFigureAboutCenterTextBox.Text);
            pointRotate.X = float.Parse(rotatePointXTextBox.Text);
            pointRotate.Y = float.Parse(rotatePointYTextBox.Text);
            Point point = new Point(pointRotate.X, pointRotate.Y);
            MoveFigure(pointRotate.X, pointRotate.Y);
            rotateFigureAboutCenterButton_Click(sender, e);
            MoveFigure(-point.X, -point.Y);
            DrawFigure();
        }

        private void ShowNewFormButton_Click(object sender, EventArgs e)
        {
            var form2 = new Form2();
            form2.Show();
        }

        private void MoveFigure(float xMove, float yMove)
        {
            float[,] matrix = new float[3, 3] { { 1, 0, xMove }, { 0, 1, yMove }, { 0, 0, 1 } };
            circle = MatrixMultiplyPoint(matrix, circle);
            rectangle1 = MatrixMultiplyPoint(matrix, rectangle1);
            rectangle2 = MatrixMultiplyPoint(matrix, rectangle2);
            rectangle3 = MatrixMultiplyPoint(matrix, rectangle3);
            rectangle4 = MatrixMultiplyPoint(matrix, rectangle4);
            rhomb1 = MatrixMultiplyPoint(matrix, rhomb1);
            rhomb2 = MatrixMultiplyPoint(matrix, rhomb2);
            rhomb3 = MatrixMultiplyPoint(matrix, rhomb3);
            rhomb4 = MatrixMultiplyPoint(matrix, rhomb4);
        }

        private void rotateFigureAboutCenterButton_Click(object sender, EventArgs e)
        {
            rotateAngle = float.Parse(rotateFigureAboutCenterTextBox.Text);
            float[,] matrix = new float[3, 3] { { (float)Math.Cos(rotateAngle * 180 / Math.PI), (float)Math.Sin(rotateAngle * 180 / Math.PI), 0 }, 
                                                {-(float)Math.Sin(rotateAngle * 180 / Math.PI), (float)Math.Cos(rotateAngle * 180 / Math.PI), 0 }, 
                                                { 0, 0, 1 } };
            circle = MatrixMultiplyPoint(matrix, circle);
            float tmp = circleWidth;
            circleWidth = circleHeight;
            circleHeight = tmp;
            rectangle1 = MatrixMultiplyPoint(matrix, rectangle1);
            rectangle2 = MatrixMultiplyPoint(matrix, rectangle2);
            rectangle3 = MatrixMultiplyPoint(matrix, rectangle3);
            rectangle4 = MatrixMultiplyPoint(matrix, rectangle4);
            rhomb1 = MatrixMultiplyPoint(matrix, rhomb1);
            rhomb2 = MatrixMultiplyPoint(matrix, rhomb2);
            rhomb3 = MatrixMultiplyPoint(matrix, rhomb3);
            rhomb4 = MatrixMultiplyPoint(matrix, rhomb4);
            DrawFigure();
        }

        private Point MatrixMultiplyPoint(float[,] matrix, Point point)
        {
            Point tmpPoint = new Point(point.X, point.Y);
            tmpPoint.X = matrix[0, 0] * point.X + matrix[0, 1] * point.Y + matrix[0, 2] * point.Z;
            tmpPoint.Y = matrix[1, 0] * point.X + matrix[1, 1] * point.Y + matrix[1, 2] * point.Z;
            tmpPoint.Z = matrix[2, 0] * point.X + matrix[2, 1] * point.Y + matrix[2, 2] * point.Z;
            point.X = tmpPoint.X;
            point.Y = tmpPoint.Y;
            point.Z = tmpPoint.Z;
            return point;
        }

        private void YeqXReflectionButton_Click(object sender, EventArgs e)
        {
            float[,] matrix = new float[3, 3] { { 0, 1, 0 }, { 1, 0, 0 }, { 0, 0, 1 } };
            circle = MatrixMultiplyPoint(matrix, circle);
            var tmp = circleWidth;
            circleWidth = circleHeight;
            circleHeight = tmp;
            rectangle1 = MatrixMultiplyPoint(matrix, rectangle1);
            rectangle2 = MatrixMultiplyPoint(matrix, rectangle2);
            rectangle3 = MatrixMultiplyPoint(matrix, rectangle3);
            rectangle4 = MatrixMultiplyPoint(matrix, rectangle4);
            rhomb1 = MatrixMultiplyPoint(matrix, rhomb1);
            rhomb2 = MatrixMultiplyPoint(matrix, rhomb2);
            rhomb3 = MatrixMultiplyPoint(matrix, rhomb3);
            rhomb4 = MatrixMultiplyPoint(matrix, rhomb4);
            DrawFigure();
        }

        private void OxMoveButton_Click(object sender, EventArgs e)
        {
            OxMove = float.Parse(OxMoveTextBox.Text);
            float[,] matrix = new float[3, 3] { { 1, 0, OxMove }, { 0, 1, 0 }, { 0, 0, 1 } };
            circle = MatrixMultiplyPoint(matrix, circle);
            rectangle1 = MatrixMultiplyPoint(matrix, rectangle1);
            rectangle2 = MatrixMultiplyPoint(matrix, rectangle2);
            rectangle3 = MatrixMultiplyPoint(matrix, rectangle3);
            rectangle4 = MatrixMultiplyPoint(matrix, rectangle4);
            rhomb1 = MatrixMultiplyPoint(matrix, rhomb1);
            rhomb2 = MatrixMultiplyPoint(matrix, rhomb2);
            rhomb3 = MatrixMultiplyPoint(matrix, rhomb3);
            rhomb4 = MatrixMultiplyPoint(matrix, rhomb4);
            DrawFigure();
        }

        private void startingPositionButton_Click(object sender, EventArgs e)
        {
            InititalizeData();
            DrawFigure();
        }

        private void OyMoveButton_Click(object sender, EventArgs e)
        {
            OyMove = float.Parse(OyMoveTextBox.Text);
            float[,] matrix = new float[3, 3] { { 1, 0, 0 }, { 0, 1, OyMove }, { 0, 0, 1 } };
            circle = MatrixMultiplyPoint(matrix, circle);
            rectangle1 = MatrixMultiplyPoint(matrix, rectangle1);
            rectangle2 = MatrixMultiplyPoint(matrix, rectangle2);
            rectangle3 = MatrixMultiplyPoint(matrix, rectangle3);
            rectangle4 = MatrixMultiplyPoint(matrix, rectangle4);
            rhomb1 = MatrixMultiplyPoint(matrix, rhomb1);
            rhomb2 = MatrixMultiplyPoint(matrix, rhomb2);
            rhomb3 = MatrixMultiplyPoint(matrix, rhomb3);
            rhomb4 = MatrixMultiplyPoint(matrix, rhomb4);
            DrawFigure();
        }

        private void OxReflectionButton_Click(object sender, EventArgs e)
        {
            float[,] matrix = new float[3, 3] { { 1, 0, 0 }, { 0, -1, 0 }, { 0, 0, 1 } };
            circle = MatrixMultiplyPoint(matrix, circle);
            rectangle1 = MatrixMultiplyPoint(matrix, rectangle1);
            rectangle2 = MatrixMultiplyPoint(matrix, rectangle2);
            rectangle3 = MatrixMultiplyPoint(matrix, rectangle3);
            rectangle4 = MatrixMultiplyPoint(matrix, rectangle4);
            rhomb1 = MatrixMultiplyPoint(matrix, rhomb1);
            rhomb2 = MatrixMultiplyPoint(matrix, rhomb2);
            rhomb3 = MatrixMultiplyPoint(matrix, rhomb3);
            rhomb4 = MatrixMultiplyPoint(matrix, rhomb4);
            DrawFigure();
        }

        private void OyReflectionButton_Click(object sender, EventArgs e)
        {
            float[,] matrix = new float[3, 3] { { -1, 0, 0 }, { 0, 1, 0 }, { 0, 0, 1 } };
            circle = MatrixMultiplyPoint(matrix, circle);
            rectangle1 = MatrixMultiplyPoint(matrix, rectangle1);
            rectangle2 = MatrixMultiplyPoint(matrix, rectangle2);
            rectangle3 = MatrixMultiplyPoint(matrix, rectangle3);
            rectangle4 = MatrixMultiplyPoint(matrix, rectangle4);
            rhomb1 = MatrixMultiplyPoint(matrix, rhomb1);
            rhomb2 = MatrixMultiplyPoint(matrix, rhomb2);
            rhomb3 = MatrixMultiplyPoint(matrix, rhomb3);
            rhomb4 = MatrixMultiplyPoint(matrix, rhomb4);
            DrawFigure();
        }

        public Form1()
        {
            InitializeComponent();
            bitmap = new Bitmap(imageWidth, imageHeight);
            //InitializeCoordinateGrid();
            //DrawCoordinateGrid();
            DrawFigure();
        }
        private void InitializeCoordinateGrid()
        {
            for (float i = 0; i <= imageWidth; i += 20)
            {
                gridX.Add(i);
            }
            for (float i = 0; i <= imageHeight; i += 20)
            {
                gridY.Add(i);
            }
        }

        private void DrawCoordinateGrid()
        {
            g = Graphics.FromImage(bitmap);
            Pen pencil = new Pen(System.Drawing.Color.LightGray);
            for (int i = 0; i < gridX.Count; i++)
                g.DrawLine(pencil, gridX[i], 0, gridX[i], imageHeight);
            for (int i = 0; i < gridY.Count; i++)
                g.DrawLine(pencil, 0, gridY[i], imageWidth, gridY[i]);
            pencil.Color = Color.Black;
            pencil.Width = 1;
            g.DrawLine(pencil, coordinateGridCenter.X, imageHeight, coordinateGridCenter.X, 0);
            g.DrawLine(pencil, 0, coordinateGridCenter.Y, imageWidth, coordinateGridCenter.Y);
        }

        private void DrawFigure()
        {
            pictureBox1.Image = null;
            g = Graphics.FromImage(bitmap);
            g.Clear(Color.White);
            Pen pen = new Pen(System.Drawing.Color.LightGray);
            g.DrawLine(pen, coordinateGridCenter.X, imageHeight, coordinateGridCenter.X, 0);
            g.DrawLine(pen, 0, coordinateGridCenter.Y, imageWidth, coordinateGridCenter.Y);
            pen.Color = Color.Black;

            g.DrawEllipse(pen, circle.X + transformX - 100, -circle.Y + transformY - 100, circleWidth, circleHeight);

            g.DrawLine(pen, rectangle1.X + transformX, -rectangle1.Y + transformY, rectangle2.X + transformX, -rectangle2.Y + transformY);
            g.DrawLine(pen, rectangle1.X + transformX, -rectangle1.Y + transformY, rectangle4.X + transformX, -rectangle4.Y + transformY);
            g.DrawLine(pen, rectangle3.X + transformX, -rectangle3.Y + transformY, rectangle2.X + transformX, -rectangle2.Y + transformY);
            g.DrawLine(pen, rectangle3.X + transformX, -rectangle3.Y + transformY, rectangle4.X + transformX, -rectangle4.Y + transformY);

            g.DrawLine(pen, rhomb1.X + transformX, -rhomb1.Y + transformY, rhomb2.X + transformX, -rhomb2.Y + transformY);
            g.DrawLine(pen, rhomb1.X + transformX, -rhomb1.Y + transformY, rhomb3.X + transformX, -rhomb3.Y + transformY);
            g.DrawLine(pen, rhomb4.X + transformX, -rhomb4.Y + transformY, rhomb2.X + transformX, -rhomb2.Y + transformY);
            g.DrawLine(pen, rhomb4.X + transformX, -rhomb4.Y + transformY, rhomb3.X + transformX, -rhomb3.Y + transformY);
            pictureBox1.Image = bitmap;
            transformX = 400;
            transformY = 300;
        }
    }
    class Point
    {
        private float x, y, z;
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
        public float Z
        {
            get { return z; }
            set { z = value; }
        }

        public Point(float a, float b)
        {
            x = a;
            y = b;
            z = 1;
        }
        public Point()
        {
            x = 0;
            y = 0;
            z = 1;
        }
        public Point(float a, float b, float c)
        {
            x = a;
            y = b;
            z = c;
        }
    }
}
