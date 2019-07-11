using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using 1_Round;

namespace Task2_6
{
    public class Ring : Round
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
