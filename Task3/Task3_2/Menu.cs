using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task3_2
{
    class Menu
    {
        private bool exit = false;
        public void openMenu()
        {
            do
            {
                Console.WriteLine("Menu:\n");
                Console.WriteLine("1: Lost method" + Environment.NewLine +
                                  "2: Exit" + Environment.NewLine);
                Console.WriteLine("Please input selected menu item:\n");
                string value = Console.ReadLine();
                int selectedMenu;
                bool success = Int32.TryParse(value, out selectedMenu);

                if (success)
                {
                    switch (selectedMenu)
                    {
                        case 1:  break;
                        case 2: exit = true; break;
                        default: Console.WriteLine("Please input an existing menu item"); break;
                    }
                }
                else { Console.WriteLine("Please input a number"); }
            } while (!exit);
        }
    }
}
