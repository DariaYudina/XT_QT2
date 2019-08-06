using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Epam.Task3.Task3_1.Task_collections
{
    class Menu
    {
        private bool exit = false;
        private Lost lostObject = new Lost();
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
                        case 1: UseLost(); break;
                        case 2: exit = true; break;
                        default: Console.WriteLine("Please input an existing menu item"); break;
                    }
                }
                else { Console.WriteLine("Please input a number"); }
            } while (!exit);
        }
        public void UseLost()
        {
            Console.WriteLine("Result: " + lostObject.lostMethod(validation()));          
        }
        public int validation()
        {
            int number;
            bool exitvalidation = false;
            while(!exitvalidation)
            {
                Console.WriteLine("Enter a number:\n");
                string value = Console.ReadLine();
                if (Int32.TryParse(value, out number)) { exitvalidation = true; return number; }
            }
            return 0;
        }
    }
}
