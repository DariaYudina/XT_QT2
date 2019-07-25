using System;
using System.Collections.Generic;
using System.Text;

namespace Task0
{
    class Menu
    {
        public void open()
        {
            string ex = "yes";
            while (ex == "yes")
            {
                Console.WriteLine("Menu:\n");
                Console.WriteLine("1: Sequence" + Environment.NewLine +
                                  "2: Simple" + Environment.NewLine +
                                  "3: Square" + Environment.NewLine +
                                  "4: Exit" + Environment.NewLine);
                string value = Console.ReadLine();
                int menuitem;
                bool success = Int32.TryParse(value, out menuitem);
                if (success)
                {
                    switch (menuitem)
                    {
                        case 1:
                            {
                                try
                                {
                                    Console.WriteLine(Task0.Sequence(validation()));
                                }
                                catch (Exception e)
                                {
                                    Console.WriteLine(e.Message);
                                }
                                break;
                            }
                        case 2:
                            {
                                try
                                {
                                Console.WriteLine("Result:");
                                if (Task0.Simple(validation())) { Console.WriteLine("the number is simple"); }
                                else { Console.WriteLine("the number is not simple"); };
                                }
                                catch (Exception e)
                                {
                                Console.WriteLine(e.Message);
                                }
                                break;
                            }
                        case 3:
                            {
                                try
                                {
                                    Task0.Square(validation());
                                }
                                catch(Exception e)
                                {
                                    Console.WriteLine(e.Message);
                                }
                                break;
                            }
                        case 4: Console.WriteLine("Exit" + Environment.NewLine); ex = "no"; break;
                        default: Console.WriteLine("Select an existing menu item"); break;
                    }
                }
                else { Console.WriteLine("You entered not a number"); }
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
