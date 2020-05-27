using System;

namespace Petrov_Laba_1_Computer_Graphic_var_7
{
    class Point
    {
        private double x, y, z;
        public double X
        {
            get { return x; }
            set { x = value; }
        }
        public double Y
        {
            get { return y; }
            set { y = value; }
        }
        public double Z
        {
            get { return z; }
            set { z = value; }
        }

        public void SwapCoordinatesXY()
        {
            double tmp = this.x;
            this.x = this.y;
            this.y = tmp;
        }

        public Point()
        {
            x = 0;
            y = 0;
            z = 0;
        }
        public Point(double a, double b)
        {
            x = a;
            y = b;
        }
        public Point(double a, double b, double c)
        {
            x = a;
            y = b;
            z = c;
        }
    }

    class Program
    {
        public static void A(double a1, double b1, double c1, double a2, double b2, double c2)
        {
            if (a1 / a2 == b1 / b2 && b1 / b2 == c1 / c2)
                Console.WriteLine("L1 is equivalent to L2");
            else
                if (a1 / a2 == b1 / b2 && b1 / b2 != c1 / c2)
                Console.WriteLine("L1 || L2");
            else
                Console.WriteLine("L1 cross L2");
        }

        public static void B(Point A, Point B, Point C, Point D)
        {
            if(A.X == B.X)
            {
                if(A.Y == B.Y)
                {
                    Console.WriteLine("No solutions!");
                    return;
                }
                else
                {
                    A.SwapCoordinatesXY();
                    B.SwapCoordinatesXY();
                    C.SwapCoordinatesXY();
                    D.SwapCoordinatesXY();
                }
            }

            int side = 1;
            bool isIntersection = false;
            if (B.X < A.X)
                side = -1;

            if (C.X * side >= A.X * side)
                isIntersection = true;

            if (D.X * side >= A.X * side)
                isIntersection = true;

            Console.WriteLine(isIntersection ? "Yes" : "No");
        }

        public static void C(Point A, Point B, Point C)
        {
            double a1 = A.X - B.X;
            double a2 = A.Y - B.Y;
            double a3 = A.Z = B.Z;

            double b1 = C.X - B.X;
            double b2 = C.Y - B.Y;
            double b3 = C.Z = B.Z;

            double tmp = Math.Sqrt(a1 * a1 + a2 * a2 + a3 * a3) * Math.Sqrt(b1 * b1 + b2 * b2 + b3 * b3);
            double cosUgla = (a1 * b1 + a2 * b2 + a3 * b3) / tmp;

            if (cosUgla * tmp > 0)
                Console.WriteLine("< 90");
            else
                if (cosUgla * tmp < 0)
                Console.WriteLine("> 90");
            else
                Console.WriteLine("= 90");
        }

        public static void D(Point A, Point B, Point C)
        {
            if((C.X-A.X) / (B.X - A.X) == (C.Y -A.Y) / (B.Y -A.Y) && (C.X - A.X) / (B.X - A.X) == (C.Z - A.Z) / (B.Z - A.Z))
                Console.WriteLine("Yes, 3 points on 1 line");
            else
                Console.WriteLine("No, 3 points not on 1 line");
        }
        static void Main(string[] args)
        {
            Console.WriteLine("Task A");
            
            A(1, 2, 3, 4, 5, 6);
            A(1, 2, 3, 10, 20, 30);
            A(1, 2, 3, 3, 6, 1);
            Console.WriteLine();
            
            Console.WriteLine("Task B");
            
            B(new Point(1, 1), new Point(2, 2), new Point(3, 3), new Point(4, 4));
            B(new Point(2, 2), new Point(1, 1), new Point(2, 2), new Point(3, 3));
            B(new Point(2, 2), new Point(1, 1), new Point(3, 3), new Point(4, 4));
            Console.WriteLine();

            Console.WriteLine("Task C");

            C(new Point(1, 1, 1), new Point(0, 0, 0), new Point(1, 1, 0));
            C(new Point(0, 1, 0), new Point(0, 0, 0), new Point(1, 0, 0));
            Console.WriteLine();

            Console.WriteLine("Task D");

            D(new Point(1, 2, 3), new Point(-4, -5, -6), new Point(7, 8, 9));
            D(new Point(1, 2, 3), new Point(4, 5, 6), new Point(7, 8, 9));
            
            Console.ReadKey();
        }
    }
}
