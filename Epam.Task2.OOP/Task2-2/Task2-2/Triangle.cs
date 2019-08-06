using System;
namespace Epam.Task2.Task2_2.OOP
{
    public class Triangle
    {
        private double _a = 0, _b = 0, _c = 0;
        public Triangle(double a, double b, double c)
        {
            if (a >= 0 && b >= 0 && c >= 0 && a < b + c && b < a + c && c < a + b)
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
        public double A
        {
            get { return _a; }
            set { if (value > 0 && value < _b + _c) { _a = value; } }
        }
        public double B
        {
            get { return _b; }
            set { if (value > 0 && value < _a + _c) { _b = value; } }
        }
        public double C
        {
            get { return _c; }
            set { if (value > 0 && value < _b + _a) { _c = value; } }
        }
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
