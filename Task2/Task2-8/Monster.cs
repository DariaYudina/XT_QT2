using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task2_8
{
    class Monster : Creature
    {
        public enum MonsterTypes
        {
            Wolf,
            Bear,
            Eagle,
        }

        MonsterTypes type;

        public MonsterTypes Type
        {
            get
            {
                return type;
            }
        }

        public Monster(MonsterTypes type, double x, double y)
            : base(x, y)
        {
            if (!Enum.IsDefined(type.GetType(), type))
            {
                throw new ArgumentOutOfRangeException();
            }
            this.type = type;
            SetStat(this.type);
        }

        void SetStat(MonsterTypes type)
        {
            switch (this.type)
            {
                case MonsterTypes.Bear:
                    MaxSpeed = 1;
                    break;
                case MonsterTypes.Wolf:
                    MaxSpeed = 2;
                    break;
                case MonsterTypes.Eagle:
                    MaxSpeed = 3;
                    break;
                default:
                    throw new ArgumentException("Unknown type: " + type, "type");
            }
        }
    }
}
