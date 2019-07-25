using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task2_7.Graphics
{
    class Circle : Figure
    {
        Point center;
        double r;

        public double X
        {
            get { return center.X; }
            set { center.X = value; }
        }

        public double Y
        {
            get { return center.Y; }
            set { center.Y = value; }
        }

        public double R
        {
            get { return r; }
            set
            {
                if (value <= 0)
                {
                    throw new ArgumentOutOfRangeException("R", "R must be greater than 0");
                }
                r = value;
            }
        }

        public virtual double Length
        {
            get
            {
                return 2 * Math.PI * r;
            }
        }

        public Circle(double r)
            : this(0, 0, r)
        {
        }

        public Circle(double x, double y, double r)
        {
            this.center = new Point(x, y);
            this.R = r;
        }

        public virtual string GetName()
        {
            return "Circle";
        }

        public override string ToString()
        {
            return GetName();
        }

        public void SetPosition(double x, double y)
        {
            center.X = x;
            center.Y = y;
        }

        public void SetPostion(Point p)
        {
            center = p;
        }

        public override void draw()
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Figure: " + GetName());
            Console.ForegroundColor = ConsoleColor.Gray;
            Console.WriteLine("Center coordinates: (" + X + ", " + Y + ")");
            Console.WriteLine("Radius: " + R);
            Console.WriteLine("Length: " + Length);
        }
    }
}
