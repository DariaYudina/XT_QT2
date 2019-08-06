namespace Delegates
{
    using System;
    using System.Collections.Generic;
    using System.Text;
    using ConsoleMenu;
    using Delegates.Extensions;

    internal class Program
    {
        private const string EnterPositiveInteger = "Enter positive integer: ";
        private readonly string[] names =
        { 
            "Michael", "Sebastian", "Jenson", "Lewis", "Fernando", "Kimi",
            "Daniil", "Nico", "Serhio", "Kevin", "Daniel", "Roman", "Pastor", "Adrian", "Esteban", "Jean-Eric",
            "Felipe", "Valteri", "Max", "Kamui", "Marcus",
        };

        private Sorter<string> sorter;
        private Random rnd = new Random();

        private static void Main(string[] args)
        {
            Program program = new Program();
            AppMenu appMenu = new AppMenu();

            appMenu.AddItem("5.1", null);
            appMenu.AddItem("5.2 Sort strings array", program.SortStringsItem);
            appMenu.AddItem("5.3 Sort in new thread", program.SortThreadingItem);
            appMenu.AddItem("5.4 Array elements sum", program.ArraySumItem);
            appMenu.AddItem("5.5 Is it positive integer?", program.ValidateNumberItem);
            appMenu.AddItem("5.6 Compare different methods", program.CompareMethodsItem); 
            appMenu.DrawMenu();
            
        }
        private void SortStringsItem()
        {
            // ???
            Sorter<string>.OrderArray(this.names, this.StringCompare);
            this.PrintArray(this.names);
        }

        private int StringCompare(string str1, string str2)
        {
            int lengthDiff = str1.Length - str2.Length;
            if (lengthDiff != 0)
            {
                return lengthDiff;
            }

            return str1.CompareTo(str2);
        }

        private void PrintArray<T>(T[] arr)
        {
            if (arr == null)
            {
                return;
            }

            foreach (var item in arr)
            {
                Console.WriteLine(item);
            }
        }

        private void SortThreadingItem()
        {
            this.sorter = new Sorter<string>(this.names, this.StringCompare);
            this.sorter.Sorted += new EventHandler<EventArgs>(this.sorter_Sorted);
            this.sorter.ThreadSort();
        }

        private void sorter_Sorted(object sender, EventArgs e)
        {
            Console.WriteLine("Array has sorted");
            this.PrintArray(this.sorter.Array);
        }

        private void ArraySumItem()
        {
            int[] arr = new int[10];
            this.SetRandomArray(arr);
            int sum = arr.Sum();
        }

        private void SetRandomArray(int[] arr)
        {
            for (int i = 0; i < arr.Length; i++)
            {
                arr[i] = this.rnd.Next(-9, 10);
            }
        }

        private void ValidateNumberItem()
        {
            Console.Write(EnterPositiveInteger);
            string checkedString = Console.ReadLine();
            bool isNumber = checkedString.IsNumber();
            Console.WriteLine("It is " + (isNumber ? "" : "not ") + "positive integer");
        }

        private void CompareMethodsItem()
        {
            var test = new TestDelegates();
            test.StartTests();
        }
    }
}
