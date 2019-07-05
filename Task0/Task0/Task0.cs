using System;
using System.Collections.Generic;
using System.Text;

namespace Task0
{
    class Task0
    {
        public static string Sequence(int n)
        {
            if (n > 0)
            {
                string res = "";
                for (int i = 0; i < n; i++)
                {
                    res += i + 1;
                    res += " ";
                }
                return res;
            }
            else { throw new Exception("Введённое значение не больше нуля"); }

        }

        public static bool Simple(int n)
        {
            bool res = true;
            for (int i = 2; i <= n / 2; i++)
            {
                if(n == 1 && n == 0)
                {
                    res = false;
                }
                if (n % i == 0)
                {
                    res = false;
                    break;
                }
            }
            return res;
        }
        public static void Square(int n)
        {
            if (n >= 0)
            {
                if (n % 2 == 1)
                {
                    for (int i = 0; i < n; i++)
                    {
                        for (int j = 0; j < n; j++)
                        {
                            if (i == j && i == (n - 1) / 2 && j == (n - 1) / 2) { Console.Write("  "); }
                            else Console.Write("* ");
                        }
                        Console.WriteLine("\n");
                    }
                }
                else
                {
                    throw new Exception("Вы ввели чётное число");
                }
            }
            else { throw new Exception("Вы ввели отрицательное число"); }
        }
    }
}



