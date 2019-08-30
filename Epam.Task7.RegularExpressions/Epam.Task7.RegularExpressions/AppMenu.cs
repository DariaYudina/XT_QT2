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
        public static 
            bool ContainsDate(string str)
        {
            Match match = Regex.Match(str, @"\d{2}[-]\d{2}[-]\d{4}");
            return match.Success;
        }
        public static string TagReplace(string str)
        {
            string pattern = @"<[^>]*>";
            return new Regex(pattern).Replace(str, "_");
        }
    }
}
