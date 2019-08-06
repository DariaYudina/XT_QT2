using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task2_7.Graphics
{
    class Line : Figure
    {
        Point p1, p2;

        public Point P1
        {
            get
            {
                return p1;
            }
            set
            {
                if (IsPointsEqual(value, p2))
                {
                    throw new ArgumentException();
                }
                p1 = value;
            }
        }

        public Point P2
        {
            get
            {
                return p2;
            }
            set
            {
                if (IsPointsEqual(p1, value))
                {
                    throw new ArgumentException();
                }
                p2 = value;
            }
        }

        public Line()
        {
            p1 = new Point(0, 0);
            p2 = new Point(1, 1);
        }

        public Line(Point p1, Point p2)
        {
            this.P1 = p1;
            this.P2 = p2;
        }

        public void SetPosition(Point p1, Point p2)
        {
            if (IsPointsEqual(p1, p2))
            {
                throw new ArgumentException();
            }
            this.p1 = p1;
            this.p2 = p2;
        }

        public override string ToString()
        {
            return "Line";
        }

        private bool IsPointsEqual(Point p1, Point p2)
        {
            return p1.X == p2.X && p1.Y == p2.Y;
        }

        public override void draw()
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Figure: " + this.ToString());
            Console.ForegroundColor = ConsoleColor.Gray;
            Console.WriteLine("First point coordinate: (" + p1.X + ", " + p1.Y + ")");
            Console.WriteLine("Second point coordinate: (" + p2.X + ", " + p2.Y + ")");
        }
    }
}

