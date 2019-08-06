using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task2_4
{
    class MyStringMenu
    {
        public void MyStringTesting()
        {
            Console.Write("Input first string: ");
            string str = Console.ReadLine();
            MyString myStr1 = new MyString(str);

            Console.Write("Input second string: ");
            str = Console.ReadLine();
            MyString myStr2 = str;

            Console.WriteLine("First string length: " + myStr1.Length);
            Console.WriteLine("Second string length: " + myStr2.Length);
            Console.WriteLine("Strings concat: " + (myStr1 + myStr2));
            Console.WriteLine("Strings equals: " + (myStr1 == myStr2));
        }
    }
}
