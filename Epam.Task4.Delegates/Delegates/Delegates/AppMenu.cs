namespace Delegates
{
    using System;
    using System.Collections.Generic;
    using System.Globalization;
    using System.IO;
    using System.Text;
    using Delegates.Extensions;

    internal class AppMenu
    {
        private const string EnterPositiveInteger = "Enter positive integer: ";
        private readonly string[] names =
        { 
            "Michael", "Sebastian", "Jenson", "Lewis", "Fernando", "Kimi",
            "Daniil", "Nico", "Serhio", "Kevin", "Daniel", "Roman", "Pastor", "Adrian", "Esteban", "Jean-Eric",
            "Felipe", "Valteri", "Max", "Kamui", "Marcus" 
        };

        private readonly ConsoleColor backColor = ConsoleColor.Black;
        private readonly ConsoleColor foreColor = ConsoleColor.Gray;
        private readonly ConsoleColor selectedBackColor = ConsoleColor.Green;
        private readonly ConsoleColor selectedForeColor = ConsoleColor.Black;

        private List<string> menuList = new List<string>();
        private int cursor;
        private int selectedMenuItem = -1;
        private bool exit;

        private Sorter<string> sorter;
        private Random rnd = new Random();

        public AppMenu()
        {
            this.menuList.Add("5.1");
            this.menuList.Add("5.2 Sort strings array");
            this.menuList.Add("5.3 Sort in new thread");
            this.menuList.Add("5.4 Array elements sum");
            this.menuList.Add("5.5 Is it positive integer?");
            this.menuList.Add("5.6 Compare different methods");
        }

        public void DrawMenu()
        {
            this.exit = false;
            ConsoleKeyInfo ckiMenu = new ConsoleKeyInfo();
            do
            {
                Console.BackgroundColor = this.backColor;
                Console.ForegroundColor = this.foreColor;
                Console.Clear();

                switch (this.selectedMenuItem)
                {
                    case 1:
                        this.SortStringsItem();
                        break;
                    case 2:
                        this.SortThreadingItem();
                        break;
                    case 3:
                        this.ArraySumItem();
                        break;
                    case 4:
                        this.ValidateNumberItem();
                        break;
                    case 5:
                        this.CompareMethodsItem();
                        break;
                    default:
                        break;
                }

                this.selectedMenuItem = -1;

                Console.Clear();
                Console.WriteLine("Main menu");

                if (this.cursor < 0)
                {
                    this.cursor = this.menuList.Count - 1;
                }
                else if (this.cursor >= this.menuList.Count)
                {
                    this.cursor = 0;
                }

                for (int i = 0; i < this.menuList.Count; i++)
                {
                    if (i == this.cursor)
                    {
                        Console.BackgroundColor = this.selectedBackColor;
                        Console.ForegroundColor = this.selectedForeColor;
                    }
                    else
                    {
                        Console.BackgroundColor = this.backColor;
                        Console.ForegroundColor = this.foreColor;
                    }

                    Console.WriteLine(this.menuList[i]);
                }

                ckiMenu = Console.ReadKey(true);
                this.KeyHandler(ckiMenu);
            }
            while
                (!this.exit);
        }
        
        private void KeyHandler(ConsoleKeyInfo cki)
        {
            switch (cki.Key)
            {
                case ConsoleKey.DownArrow:
                    this.cursor++;
                    break;
                case ConsoleKey.UpArrow:
                    this.cursor--;
                    break;
                case ConsoleKey.Escape:
                    this.exit = true;
                    break;
                case ConsoleKey.Enter:
                    this.selectedMenuItem = this.cursor;
                    break;
                default:
                    break;
            }
        }

        private void FootMethod()
        {
            Console.WriteLine("Press any key to back to menu");
            Console.ReadKey();
        }

        private void SortStringsItem()
        {
            // ???
            Sorter<string>.OrderArray(this.names, this.StringCompare);
            this.PrintArray(this.names);

            this.FootMethod();
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
            this.FootMethod();
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

            this.FootMethod();
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

            this.FootMethod();
        }

        private void CompareMethodsItem()
        {
            var test = new TestDelegates();
            test.StartTests();

            this.FootMethod();
        }
    }
}
