using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Task1
{
    class task1
    {
        [Flags]
        public enum Style
        {
            None = 0,
            Bold = 1,
            Italic = 2,
            Underline = 4,
        }

        public static void Rectangle(int a, int b)
        {
            if (a > 0 && b > 0)
            {
                int res = a * b;
                Console.WriteLine(res);
            }
            else { throw new Exception("Вы ввели не положительное число"); }
        }
        public static void Triangle(int n)
        {
            if (n >= 0)
            {
                for (int i = 0; i < n + 1; i++)
                {
                    for (int j = 0; j < i; j++)
                    {
                        Console.Write("* ");
                    }
                    Console.WriteLine("\n");
                }
            }
            else { throw new Exception("Вы ввели не положительное число"); }

        }
        public static void AnotherTriangle(int n)
        {
            if (n >= 0)
            {
                for (int i = 0; i <= n; i++)
                {
                    for (int j = n - 1; j >= i; j--)
                    {
                        Console.Write("  ");
                    }
                    for (int j = 0; j < i; j++)
                    {
                        Console.Write("* ");
                    }
                    for (int j = 1; j < i; j++)
                    {
                        Console.Write("* ");
                    }
                    Console.WriteLine("\n");
                }
            }
            else { throw new Exception("Вы ввели не положительное число"); }
        }
        public static void XmasTree(int n)
        {
            if (n >= 0)
            {
                for (int x = 0; x < n; x++)
                {
                    for (int i = 0; i < x; i++)
                    {
                        for (int j = n - 1; j > i; j--)
                        {
                            Console.Write("  ");
                        }
                        for (int j = 0; j < i; j++)
                        {
                            Console.Write("* ");
                        }
                        for (int j = 1; j < i; j++)
                        {
                            Console.Write("* ");
                        }
                        if (i != x - 1) { Console.Write("\n"); }
                    }
                }
                Console.Write("\n");
            }
            else { throw new Exception("Вы ввели отрицательное число"); }
        }
        public static int SumOfNumbers()
        {
            int res = 0;
            for (int i = 3; i < 1000; i++)
            {
                if ((i % 3 == 0) || (i % 5 == 0))
                {
                    res += i;
                }
            }
            return res;
        }
        public static void FontAdjustment()
        {
            Style style = Style.None;
            string value = "";
            do
            {
                Console.WriteLine("Параметры надписи: " + style);
                Console.WriteLine("Введите:");
                for (int i = 1; i <= 3; i++)
                {
                    Style s = (Style)(int)Math.Pow(2, i - 1);
                    Console.WriteLine("\t{0}: {1}", i, s);
                }
                Console.WriteLine("\t4: Выйти");

                value = Console.ReadLine();
                int menuitem;
                bool success = Int32.TryParse(value, out menuitem);

                switch (menuitem)
                {
                    case 1: style ^= Style.Bold; break;
                    case 2: style ^= Style.Italic; break;
                    case 3: style ^= Style.Underline; break;
                    case 4: value = "ex"; break;
                    default: Console.WriteLine("Выберите существующий пункт меню"); break;
                }
            } while (value != "ex");
        }
        public static void ArrayProcessing(int n)
        {
            Random rnd = new Random();
            int[] sortarr = new int[n];
            for (int i = 0; i < n; i++)
                sortarr[i] = rnd.Next(-10, 10);
            Console.WriteLine("\tСгенерированный массив: ");
            print(sortarr);
            qSort(sortarr, 0, sortarr.Length - 1);
            Console.WriteLine("\tОтсортированный массив: ");
            print(sortarr);
            Console.WriteLine("\tМаксимальный элемент: " + max(sortarr));
            Console.WriteLine("\tМинимальный элемент: " + min(sortarr));
        }
            public static int partition(int[] A, int start, int end)
            {
                int pivot = A[(start + end) / 2];
                int i = start;
                int j = end;

                while (i <= j)
                {
                    while (A[i] < pivot)
                        i++;
                    while (A[j] > pivot)
                        j--;
                    if (i <= j)
                    {
                        int temp = A[i];
                        A[i] = A[j];
                        A[j] = temp;

                        i++;
                        j--;
                    }
                }

                return i;
            }
            public static void qSort(int[] A, int start, int end)
            {
                if (start < end)
                {
                    int temp = partition(A, start, end);

                    qSort(A, start, temp - 1);
                    qSort(A, temp, end);
                }
            }
            public static void print(int[] A)
            {
                for (int i = 0; i < A.Length; ++i)
                    Console.Write("{0} ", A[i]);
                Console.WriteLine();
            }
            public static int max(int[] A)
            {
                int res = 0;
                for (int i = 0; i < A.Length; ++i)
                {
                    if (res < A[i])
                    {
                        res = A[i];
                    }
                }
                return res;
            }
            public static int min(int[] A)
            {
                int res = 0;
                for (int i = 0; i < A.Length; ++i)
                {
                    if (res > A[i])
                    {
                        res = A[i];
                    }
                }
                return res;
            }
        public static void NoPositive(int n)
        {
            Random rnd = new Random();
            int[,,] mas = new int[n, n, n];
            for (int i = 0; i < n; ++i)
                for (int j = 0; j < n; j++)
                    for (int k = 0; k < n; k++)
                        mas[i, j, k] = rnd.Next(-20, 20);

            int rows = mas.GetUpperBound(0) + 1;
            int columns = mas.GetUpperBound(1) + 1;
            int width = mas.GetUpperBound(2) + 1;

            //Печать массива
            Console.WriteLine("\tСгенерированный массив: \n");
            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < columns; j++)
                {
                    for (int k = 0; k < width; k++)
                    {
                        Console.Write($"{mas[i, j, k]} \t");
                    }
                    Console.WriteLine();
                }
                Console.WriteLine();
            }

            //Печать обработанного массива
            Console.WriteLine("\tОбработанный массив: \n");
            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < columns; j++)
                {
                    for (int k = 0; k < width; k++)
                    {
                        if (mas[i, j, k] < 0)
                        { mas[i, j, k] = 0; }
                        Console.Write($"{mas[i, j, k]} \t");
                    }
                    Console.WriteLine();
                }
                Console.WriteLine();
            }

        }
        public static void NonNegativeSum(int n)
        {
            int res = 0;

            Random rnd = new Random();
            int[] arr = new int[n];
            for (int i = 0; i < n; i++)
                arr[i] = rnd.Next(-10, 10);
            Console.WriteLine("\tСгенерированный массив: ");
            print(arr);

            for (int i = 0; i < n; i++)
            {
                if( arr[i] > 0 ) res+= arr[i];
            }
            Console.WriteLine("Сумма положительных элементов массива: " +
                "" + res );
        }
        public static void TwoDArray(int n)
        {
            int res = 0;

            Random rnd = new Random();
            int[,] arr = new int[n,n];
            Console.WriteLine("\tСгенерированный массив:\n");
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    arr[i, j] = rnd.Next(-10, 10);
                    Console.Write($"{arr[i, j]} \t");
                }
                Console.WriteLine("\n");
            }                

            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    if ((i + j) % 2 == 0) res += arr[ i, j ];
                }
            }
            Console.WriteLine("\tCумма элементов массива, стоящих на чётных позициях: " +
                "" + res);
        }
        public static int AverageStringLength(string str)
        {

            char[] punc = str.Where(Char.IsPunctuation).Distinct().ToArray();
            Array.Resize(ref punc, punc.Length + 1);
            punc[punc.Length - 1] = ' ';
            string[] only_words = str.Split(punc, StringSplitOptions.RemoveEmptyEntries);
            int sredlin = 0;
            for (int i = 0; i < only_words.Length; i++)
            {
                sredlin += only_words[i].Length;
            }
            sredlin /= only_words.Length;
            return sredlin;
        }
        public static void CharDoubler(string str_1, string str_2)
        {                        
            char[] uu = str_1.ToCharArray(); 
            str_1 = "";  
            for (int i = 0; i < uu.Length; i++)
            {  
                str_1 += (uu[i] + "");  
                if (FindCharToString(str_2, uu[i]))
                { 
                    str_1 += (uu[i] + "");  
                }
            }
            Console.WriteLine("\tРезультат:\n");
            Console.WriteLine(str_1);
        }
            static bool FindCharToString(string stroka, char simvol)
            {  
                char[] c = stroka.ToCharArray(); 
                bool rez = false;  
                for (int i = 0; i < c.Length; i++)
                {  
                    if (c[i] == simvol) { rez = true; break; } 
                }
                return rez; 
            }
    }
}
