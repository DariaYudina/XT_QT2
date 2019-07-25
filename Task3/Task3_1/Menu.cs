using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task3_1
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
            try
            {
                Console.WriteLine("Result: " + lostObject.lostMethod(validation()));
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
        public int validation()
        {
            Console.WriteLine("Enter a number:\n");
            string value = Console.ReadLine();
            int number;
            bool success = Int32.TryParse(value, out number);
            if (success) { return number; }
            else { throw new Exception("You entered not a number"); }
        }
    }
}
