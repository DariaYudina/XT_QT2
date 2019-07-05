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
                Console.WriteLine("Меню:\n");
                Console.WriteLine("1: Sequence\n" +
                                  "2: Simple\n" +
                                  "3: Square\n" +
                                  "4: Выйти\n");
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
                                Console.WriteLine("Результат:");
                                if (Task0.Simple(validation())) { Console.WriteLine("Введенное число - простое"); }
                                else { Console.WriteLine("Введенное число - не является простым"); };
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
                        case 4: Console.WriteLine("Вы выбрали выйти\n"); ex = "no"; break;
                        default: Console.WriteLine("Выберите существующий пункт меню"); break;
                    }
                }
                else { Console.WriteLine("Вы ввели не число "); }
            }
        }
        public int validation()
        {
            Console.WriteLine("Введите число для выбранной функции:\n");
            string value = Console.ReadLine();
            int number;
            bool success = Int32.TryParse(value, out number);
            if (success) { return number; }
            else { throw new Exception("Вы ввели не число"); }
        }       
    }
}
