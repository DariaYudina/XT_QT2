using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task2_8
{
    internal abstract class Subject
    {
        private double x;
        private double y;
        private readonly double width;
        private readonly double height;

        public double X
        {
            get { return x; }
            protected set { x = value; }
        }

        public double Y
        {
            get { return y; }
            protected set { y = value; }
        }

        public double Width
        {
            get { return width; }
        }

        public double Height
        {
            get { return height; }
        }

        protected Subject()
            : this(0, 0)
        {
        }

        protected Subject(double x, double y)
            : this(x, y, 1, 1)
        {
        }

        protected Subject(double x, double y, double width, double height)
        {
            if (width <= 0)
            {
                throw new ArgumentOutOfRangeException("width", "width must be greater than 0");
            }
            if (height <= 0)
            {
                throw new ArgumentOutOfRangeException("height", "height must be greater than 0");
            }
            this.x = x;
            this.y = y;
            this.width = width;
            this.height = height;
        }
    }
}
