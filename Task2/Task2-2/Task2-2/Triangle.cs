using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task2_2
{
    public class Triangle
    {
        private double _a = 0, _b = 0, _c = 0;
        public Triangle(double a, double b, double c)
        {
            if (a >= 0 && b >= 0 && c >= 0)
            {
                _a = a;
                _b = b;
                _c = c;
            }
            else
            {
                throw new ArgumentException("Arguments can't be less than zero");
            }
        }
        public double GetA() { return _a; }
        public double GetB() { return _b; }
        public double GetC() { return _c; }
        public double GetArea()
        {
            double half_perimetr = (_a + _b + _c) / 2;
            return Math.Sqrt(half_perimetr * (half_perimetr - _a) * (half_perimetr - _b) * (half_perimetr - _c));
        }
        public double GetPerimeter() { return _a + _b + _c; }
        public override string ToString()
        {
            return $"Length A: {_a}; Length B: {_b}; Length C: {_c}" + Environment.NewLine + $"Perimetr: { GetPerimeter() }";
        }
    }
}
