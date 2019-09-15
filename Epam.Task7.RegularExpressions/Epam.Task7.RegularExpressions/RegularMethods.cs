using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;


namespace Epam.Task7.RegularExpressions
{
    public class RegularMethods
    {
        public static bool DateExistance(string str)
        {
            Match match = Regex.Match(str, @"\d{2}[-]\d{2}[-]\d{4}");
            return match.Success;
        }
        public static string HTMLReplacer(string str)
        {
            string pattern = @"<.*?>";    //@" <[^>]*>";
            return new Regex(pattern).Replace(str, "_");
        }
        public static MatchCollection EmailFinder(string str)
        {
            string pattern = @"\b[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,6}\b";
            return Regex.Matches(str, pattern);   
        }
    }
}
