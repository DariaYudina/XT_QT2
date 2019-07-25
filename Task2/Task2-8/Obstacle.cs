using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task2_8
{
    class Obstacle : Subject
    {
        public enum ObstacleTypes
        {
            Tree,
            Stone,
            Water,
        }

        ObstacleTypes type;

        public Obstacle(Obstacle.ObstacleTypes type, double x, double y)
            : base(x, y)
        {
            if (!Enum.IsDefined(type.GetType(), type))
            {
                throw new ArgumentOutOfRangeException();
            }
            this.type = type;
        }
    }
}
