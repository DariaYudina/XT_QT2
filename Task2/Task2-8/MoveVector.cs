using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task2_8
{
    struct MoveVector
    {
        double axisX;
        double axisY;

        public double AxisX
        {
            get
            {
                return axisX;
            }
            set
            {
                axisX = value;
            }
        }

        public double AxisY
        {
            get
            {
                return axisY;
            }
            set
            {
                axisY = value;
            }
        }

        public MoveVector(double axisX, double axisY)
        {
            this.axisX = axisX;
            this.axisY = axisY;
        }

        public MoveVector Normalize()
        {
            double length = Math.Sqrt(Math.Pow(axisX, 2) + Math.Pow(axisY, 2));
            double speedX = axisX / length;
            double speedY = axisY / length;
            return new MoveVector { axisX = speedX, axisY = speedY };
        }
    }
}
