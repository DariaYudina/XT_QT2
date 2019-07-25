using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task2_8
{
    class Player : Creature
    {
        int lives;

        public int Lives
        {
            get
            {
                return lives;
            }
        }

        public Player(double x, double y)
            : base(x, y)
        {
            lives = 3;
        }

        void Caught()
        {
            lives--;
            if (lives == 0)
            {
                Death();
            }
        }

        private void Death()
        {
        }
    }
}
