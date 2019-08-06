using System;
using System.Collections.Generic;
using System.Text;

namespace Epam.Task1.Csharp_basics
{
    class Menu
    {
        public void open()
        {
            string ex = "yes";
            while (ex == "yes")
            {               
                Console.WriteLine("Меню:");
                Console.WriteLine("\t1: Rectangle\n" +
                                  "\t2: Triangle\n" +
                                  "\t3: Another Triangle\n" +
                                  "\t4: Xmas Tree\n" +
                                  "\t5: Sum of numbers\n" +
                                  "\t6: Font adjustment\n" +
                                  "\t7: Array processing\n" +
                                  "\t8: No positive\n" +
                                  "\t9: Non negative sum\n" +
                                  "\t10: 2D array\n" +
                                  "\t11: AverageStringLength\n" +
                                  "\t12: Char Doubler\n" +
                                  "\t13: Выйти");
                Console.WriteLine("Введите выбранный пункт меню:");
                string value = Console.ReadLine();
                int menuitem;
                bool success = Int32.TryParse(value, out menuitem);
                if (success)
                {
                    switch (menuitem)
                    {
                        case 1:
                            task1.Rectangle(validation(), validation());
                            break;
                        case 2:
                            task1.Triangle(validation());
                            break;
                        case 3:
                            task1.AnotherTriangle(validation());
                            break;
                        case 4:
                            task1.XmasTree(validation());
                            break;
                        case 5:
                            Console.WriteLine(task1.SumOfNumbers());
                            break;
                        case 6:
                            task1.FontAdjustment();
                            break;
                        case 7:
                            task1.ArrayProcessing(validation());
                            break;
                        case 8:
                            task1.NoPositive(validation());
                            break;
                        case 9:
                            task1.NonNegativeSum(validation());
                            break;
                        case 10:
                            task1.TwoDArray(validation());
                            break;
                        case 11:
                            {
                                Console.WriteLine("\tВведите строку\n");
                                string str = Console.ReadLine();
                                Console.WriteLine(task1.AverageStringLength(str));
                                break;
                            }
                        case 12:
                            {
                                Console.WriteLine("\tВведите 2 строки через enter\n");
                                string str1 = Console.ReadLine();
                                string str2 = Console.ReadLine();
                                task1.CharDoubler(str1, str2) ;                              
                                break;
                            }
                        case 13:
                            Console.WriteLine("\tВы выбрали выйти\n");
                            ex = "no";
                            break;
                        default:
                            Console.WriteLine("\tВыберите существующий пункт меню");
                            break;
                    }
                }
                else { Console.WriteLine("\tВы ввели не число "); }
            }
        }
        public int validation()
        {
            Console.WriteLine("\tВведите число для выбранной функции:\n");
            string value = Console.ReadLine();
            int number;
            bool success = Int32.TryParse(value, out number);
            if (success) { return number; }
            else { throw new Exception("\tВы ввели не число"); }
        }
    }
}


