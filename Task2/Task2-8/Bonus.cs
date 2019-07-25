using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Timers;

namespace Task2_8
{
        class Bonus : Subject
        {
            public enum BonusTypes
            {
                Apple,
                StrawBerry,
                Pear,
            }

            BonusTypes type;
            double speed;
            Timer timeToAffect;

            public BonusTypes Type
            {
                get
                {
                    return type;
                }
            }

            public double Speed
            {
                get
                {
                    return speed;
                }
            }

            public double Interval
            {
                get
                {
                    return timeToAffect.Interval;
                }
                set
                {
                    if (value <= 0)
                    {
                        throw new ArgumentOutOfRangeException();
                    }
                    timeToAffect.Interval = value;
                }
            }

            public Bonus(BonusTypes type, double x, double y)
                : base(x, y)
            {
                if (!Enum.IsDefined(type.GetType(), type))
                {
                    throw new ArgumentOutOfRangeException();
                }
                this.type = type;
                switch (this.type)
                {
                    case BonusTypes.Apple:
                        speed = 1;
                        break;
                    case BonusTypes.Pear:
                        speed = 3;
                        break;
                    case BonusTypes.StrawBerry:
                        speed = -1;
                        break;
                    default:
                        break;
                }
            }

            void Collect(Creature creature)
            {
                creature.MaxSpeed += this.speed;
            }
        }
    
}
