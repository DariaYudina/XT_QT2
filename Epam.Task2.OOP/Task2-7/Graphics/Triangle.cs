using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task2_7
{
    class Triangle 
    {
        double a, b, c;

        public double A
        {
            get { return a; }
            set
            {
                if (!IsStateCorrect(value, b, c))
                {
                    throw new InvalidOperationException("Each side must be less than sum of other sides");
                }
                a = value;
            }
        }

        public double B
        {
            get { return b; }
            set
            {
                if (!IsStateCorrect(a, value, c))
                {
                    throw new InvalidOperationException("Each side must be less than sum of other sides");
                }
                b = value;
            }
        }

        public double C
        {
            get { return c; }
            set
            {
                if (!IsStateCorrect(a, b, value))
                {
                    throw new InvalidOperationException("Each side must be less than sum of other sides");
                }
                c = value;
            }
        }

        public double Perimeter
        {
            get { return a + b + c; }
        }

        public double Area
        {
            get
            {
                double halfP = Perimeter / 2;
                return Math.Sqrt(halfP * (halfP - a) * (halfP - b) * (halfP - c));     // Geron's formula
            }
        }

        public Triangle(double a, double b, double c)
        {
            SetSides(a, b, c);
        }

        public void SetSides(double a, double b, double c)
        {
            this.A = a;
            this.B = b;
            this.C = c;
        }

        private bool IsStateCorrect(double a, double b, double c)
        {
            return a + b > c && a + c > b && b + c > a;
        }

        public string GetName()
        {
            return "Triangle";
        }
    }
}
