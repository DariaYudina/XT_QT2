using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task2_8
{
        abstract class Creature : Subject, IMovable
        {
            private double maxSpeed;
            private MoveVector currentSpeed;

            public double MaxSpeed
            {
                get { return maxSpeed; }
                protected internal set
                {
                    if (value <= 0)
                    {
                        throw new ArgumentOutOfRangeException("MaxSpeed", "MaxSpeed must be greater than 0");
                    }
                    maxSpeed = value;
                }
            }

            protected Creature(double x, double y)
                : this(x, y, 1, 1)
            {
            }

            protected Creature(double x, double y, double width, double height)
                : base(x, y, width, height)
            {
            }

            public void SetPostion(double x, double y)
            {
                this.X = x;
                this.Y = y;
            }

            public void Move()
            {
                MoveVector normal = currentSpeed.Normalize();
                this.X += normal.AxisX * maxSpeed;
                this.Y += normal.AxisY * maxSpeed;
            }
        }
    
}
