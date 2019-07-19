using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task2_7.Graphics
{
    class Round : Circle
    {
        public virtual double Area
        {
            get
            {
                return Math.PI * Math.Pow(R, 2);
            }
        }

        public Round(double r)
            : base(r)
        {
        }


        public Round(double x, double y, double r)
            : base(x, y, r)
        {
        }

        public override string GetName()
        {
            return "Round";
        }

        public override void draw()
        {
            base.draw();
            Console.WriteLine("Area: " + Area.ToString());
        }
    }
}
