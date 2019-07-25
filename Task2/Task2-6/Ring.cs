using System;
using Task2_1;
namespace Task2_6
{
    public class Ring : RoundFigure
    {
        private double _innerRadius = 0;
        public Ring(double x, double y, double radius, double innerRadius) : base(x, y, radius)
        { _innerRadius = innerRadius;}

        public override double GetArea
        { get { return Math.PI * Math.Pow( _radius, 2) - Math.PI * Math.Pow( _innerRadius, 2); } }

        public override double GetLength
        { get { return 2 * Math.PI * _radius + 2 * Math.PI * _innerRadius; } }

        public double InnerRarius
        {
            get { return _innerRadius; }
            set
            {
                if (value >= _radius)
                {
                    throw new ArgumentOutOfRangeException("innerR", "innerR must be less than outer radius");
                }
                _innerRadius = value;
            }
        }
        public override double Radius
        {
            get { return _radius; }
            set
            {
                if (value > 0) { _radius = value; }
                else { throw new ArgumentOutOfRangeException("Radius's value can't be neagitive or zero", "radius"); }
            }
        }
        public override double X
        {
            get { return _x; }
            set { _x = value; }
        }
        public override double Y
        {
            get { return _y; }
            set { _y = value; }
        }
    }
}
