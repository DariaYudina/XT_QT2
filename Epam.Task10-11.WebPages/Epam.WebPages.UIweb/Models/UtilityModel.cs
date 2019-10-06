using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Epam.WebPages.UIweb.Models
{
    public static class UtilityModel
    {
        public static string AgeSuffics(int age)
        {
            if (age % 10 == 1)
            {
                return "год";
            } else if (age % 10 >= 2 && age % 10 < 5)
            {
                return "года";
            } else
            {
                return "лет";
            }
        }
    }
}