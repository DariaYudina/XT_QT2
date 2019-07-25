using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task2_7.Graphics
{
    class Ring : Round
    {
        double innerR;

        public double InnerR
        {
            get { return innerR; }
            set
            {
                if (value >= R)
                {
                    throw new ArgumentOutOfRangeException("innerR", "innerR must be less than outer radius");
                }
                innerR = value;
            }
        }

        public override double Length
        {
            get
            {
                return 2 * Math.PI * innerR + base.Length;
            }
        }

        public override double Area
        {
            get
            {
                return base.Area - Math.PI * Math.Pow(innerR, 2);
            }
        }

        public Ring(double r, double innerR)
            : this(0, 0, r, innerR)
        {
        }

        public Ring(double x, double y, double r, double innerR)
            : base(x, y, r)
        {
            this.InnerR = innerR;
        }

        public override string GetName()
        {
            return "Ring";
        }

        public void SetRadius(double innerR, double r)
        {
            if (innerR <= 0 || innerR >= r)
            {
                throw new ArgumentOutOfRangeException("innerR", "innerR must be greater than 0 and less than r");
            }
            this.R = r;
            this.innerR = innerR;
        }

        public override void draw()
        {
            base.draw();
            Console.WriteLine("Inner radius: " + innerR);
        }
    }
}

