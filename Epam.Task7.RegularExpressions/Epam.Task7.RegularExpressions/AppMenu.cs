using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Epam.Task7.RegularExpressions
{
    public class AppMenu
    {
        private bool exit;
        public void OpenMenu()
        {
            exit = false;
            do
            {
                Console.WriteLine($"Please select some action:{Environment.NewLine}" +
                                     $"1. Date existance{Environment.NewLine}" +
                                     $"2. HTML replacer{Environment.NewLine}" +
                                     $"3. Email finder{Environment.NewLine}" +
                                     $"4. Exit{Environment.NewLine}");
                var input = Console.ReadLine();
                if (int.TryParse(input, out int selectedOption)
                    && selectedOption > 0)
                {
                    switch (selectedOption)
                    {
                        case 1:
                            DateExistance();
                            break;
                        case 2:
                            HTMLReplacer();
                            break;
                        case 3:
                            EmailFinder();
                            break;
                        case 4:
                            exit = true;
                            break;
                        default:
                            Console.WriteLine("Input correct menu item");
                            break;
                    }
                }
                else
                {
                    Console.WriteLine("Input correct menu item");
                }
            } while (!exit);
        }
        public void DateExistance()
        {
            Console.WriteLine("Введите текст содержащий дату в формате dd-mm-yyyy: ");
            string str = Console.ReadLine();
            if (RegularMethods.DateExistance(str))
            {
                Console.WriteLine("В тексте " + str + " содержится дата.");
            }
            else
            {
                Console.WriteLine("В тексте " + str + " не содержится дата.");
            }           
        }
        public void HTMLReplacer()
        {
            Console.WriteLine("Введите текст с html: ");
            Console.WriteLine("Результат: " + RegularMethods.HTMLReplacer(Console.ReadLine()));           
        }
        public void EmailFinder()
        {
            Console.WriteLine("Введите строку: ");
            string str = Console.ReadLine();
            Console.WriteLine("Найденные адреса электронной почты: ");
            foreach(var item in RegularMethods.EmailFinder(str))
            {
                Console.WriteLine(item);
            }          
        }
    }
}
