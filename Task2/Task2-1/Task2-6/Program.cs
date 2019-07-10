using System;
using Task2_1;
namespace Task2_6
{
    class Program
    {
        static void Main(string[] args)
        {

        }
    }
    class Ring : Round
    {
        private double _innerRadius = 0;
        public Ring(double x, double y, double radius, double innerRadius) : base(x, y, radius)
        {
            _innerRadius = innerRadius;
        }
        public double InnerRarius
        {
            get { return _innerRadius; }
            set
            {
                if (value >= this.GetRadius())
                {
                    throw new ArgumentOutOfRangeException("innerR", "innerR must be less than outer radius");
                }
                _innerRadius = value;
            }
        }
    }

}
