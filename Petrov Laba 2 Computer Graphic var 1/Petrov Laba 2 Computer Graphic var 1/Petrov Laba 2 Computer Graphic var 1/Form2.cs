using System;
using System.Drawing;
using System.Windows.Forms;
using System.Timers;

namespace Petrov_Laba_2_Computer_Graphic_var_1
{
    public partial class Form2 : Form
    {
        private static System.Timers.Timer aTimer;
        Graphics g;
        private const int imageWidth = 1000, imageHeight = 500;
        private Bitmap bitmap;
        private Point circle = new Point(31, 81), spokeWheel1 = new Point(31,50),
            spokeWheel2 = new Point(31, 112), spokeWheel3 = new Point(0, 81),
            spokeWheel4 = new Point(62, 81);
        private float radius = 31;
        public Form2()
        {
            InitializeComponent();
            bitmap = new Bitmap(imageWidth, imageHeight);
            SetTimer();
        }

        private void SetTimer()
        {
            aTimer = new System.Timers.Timer(200);
            aTimer.Elapsed += OnTimedEvent;
            aTimer.AutoReset = true;
            aTimer.Enabled = true;
        }

        private void OnTimedEvent(Object source, ElapsedEventArgs e)
        {
            DrawFigure();
            if (circle.X >= 810)
            {
                aTimer.Stop();
                aTimer.Dispose();
            }
        }

        private void DrawFigure()
        {
            pictureBox1.Image = null;
            g = Graphics.FromImage(bitmap);
            g.Clear(Color.White);
            Pen pen = new Pen(Color.Black);
            g.DrawLine(pen, 0, 100, 800, 500);
            g.DrawEllipse(pen, circle.X - radius, circle.Y - radius, radius*2, radius * 2);
            g.DrawLine(pen, spokeWheel1.X, spokeWheel1.Y, spokeWheel2.X, spokeWheel2.Y);
            g.DrawLine(pen, spokeWheel3.X, spokeWheel3.Y, spokeWheel4.X, spokeWheel4.Y);
            MoveFigure(10, 5);
            rotateSpokeWheels();
            pictureBox1.Image = bitmap;
        }

        private void rotateSpokeWheels()
        {
            float[,] matrix = new float[3, 3] { { (float)Math.Cos(20.6640739), -(float)Math.Sin(20.6640739), 0 },
                                                { (float)Math.Sin(20.6640739), (float)Math.Cos(20.6640739), 0 },
                                                { 0, 0, 1 } };
            Point point = new Point(circle.X, circle.Y);
            MoveFigure(-circle.X , -circle.Y);
            spokeWheel1 = MatrixMultiplyPoint(matrix, spokeWheel1);
            spokeWheel2 = MatrixMultiplyPoint(matrix, spokeWheel2);
            spokeWheel3 = MatrixMultiplyPoint(matrix, spokeWheel3);
            spokeWheel4 = MatrixMultiplyPoint(matrix, spokeWheel4);
            MoveFigure(point.X, point.Y);
        }

        private void MoveFigure(float xMove, float yMove)
        {
            float[,] matrix = new float[3, 3] { { 1, 0, xMove }, { 0, 1, yMove }, { 0, 0, 1 } };
            circle = MatrixMultiplyPoint(matrix, circle);
            spokeWheel1 = MatrixMultiplyPoint(matrix, spokeWheel1);
            spokeWheel2 = MatrixMultiplyPoint(matrix, spokeWheel2);
            spokeWheel3 = MatrixMultiplyPoint(matrix, spokeWheel3);
            spokeWheel4 = MatrixMultiplyPoint(matrix, spokeWheel4);
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
    }
}
