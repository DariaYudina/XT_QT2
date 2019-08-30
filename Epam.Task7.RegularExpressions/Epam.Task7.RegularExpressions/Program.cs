using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Epam.Task7.RegularExpressions
{
    public class Program
    {
        static void Main(string[] args)
        {
            string pattern = @"\b[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,6}\b";
                
            string email = "dasha@gmail.com sdweeewr dasha@gmail.com ";
            var r = Regex.Matches(email, pattern);
            foreach (var item in r)
            {
                Console.WriteLine(item);
            }
            Console.ReadLine();
        }
    }
}
