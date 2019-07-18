using System;
namespace Task2_1
{
    public abstract class RoundFigure
    {
        protected double _x;
        protected double _y;
        protected double _radius;
        public abstract double X { get; set; }
        public abstract double Y { get; set; }
        public abstract double Radius { get; set; }

        public RoundFigure(double x, double y, double radius)
        {
            if (radius > 0)
            {
                _x = x;
                _y = y;
                _radius = radius;
            }
            else
            {
                throw new ArgumentOutOfRangeException("Radius's value can't be neagitive or zero", "radius");
            }
        }

        abstract public double GetArea { get; }
        abstract public double GetLength { get; }
    }

}
