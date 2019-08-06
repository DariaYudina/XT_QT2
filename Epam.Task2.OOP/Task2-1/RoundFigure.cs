using System;
namespace Epam.Task2.Task2_3.OOP
{
    public abstract class RoundFigure
    {
        protected double _x ;
        protected double _y;
        protected double _radius;
        public abstract double X { get; set; }
        public abstract double Y { get; set; }
        public double Radius
        {
            get { return _radius; }
            set{
                if (value > 0) { _radius = value; }
                else{ throw new ArgumentOutOfRangeException("Radius's value can't be neagitive or zero", "radius"); }
            }
        }

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
