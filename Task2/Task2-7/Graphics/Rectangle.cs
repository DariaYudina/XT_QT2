using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task2_7.Graphics
{
    class Rectangle : Figure
    {
        Point coordTopLeft;
        double width, height;
        public double X
        {
            get { return coordTopLeft.X; }
            set { coordTopLeft.X = value; }
        }
        public double Y
        {
            get { return coordTopLeft.Y; }
            set { coordTopLeft.Y = value; }
        }
        public double Width
        {
            get { return width; }
            set
            {
                if (value <= 0)
                {
                    throw new ArgumentOutOfRangeException("width", "width must be greater than 0");
                }
                width = value;
            }
        }
        public double Height
        {
            get { return height; }
            set
            {
                if (value <= 0)
                {
                    throw new ArgumentOutOfRangeException("height", "height must be greater than 0");
                }
                height = value;
            }
        }
        public double Area
        {
            get
            {
                return width * height;
            }
        }
        public Rectangle(double x, double y, double width, double height)
        {
            this.coordTopLeft = new Point(x, y);
            this.Width = width;
            this.Height = height;
        }
        public string GetName()
        {
            return "Rectangle";
        }
        public override void draw()
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Figure: " + GetName());
            Console.ForegroundColor = ConsoleColor.Gray;
            Console.WriteLine("Center coordinates: (" + X + ", " + Y + ")");
            Console.WriteLine("Width: " + Width);
            Console.WriteLine("Height: " + Height);
            Console.WriteLine("Area: " + Area);
        }
    }
}
