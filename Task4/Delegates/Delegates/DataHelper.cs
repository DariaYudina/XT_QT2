namespace Delegates.Extensions
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Text.RegularExpressions;

    public static class DataHelper
    {
        public static int Sum(this IEnumerable<int> source)
        {
            int sum = 0;
            foreach (var item in source)
            {
                sum += item;
            }

            return sum;
        }

        public static decimal Sum(this IEnumerable<decimal> source)
        {
            decimal sum = 0;
            foreach (var item in source)
            {
                sum += item;
            }

            return sum;
        }

        public static double Sum(this IEnumerable<double> source)
        {
            double sum = 0;
            foreach (var item in source)
            {
                sum += item;
            }

            return sum;
        }

        public static float Sum(this IEnumerable<float> source)
        {
            float sum = 0;
            foreach (var item in source)
            {
                sum += item;
            }

            return sum;
        }

        public static long Sum(this IEnumerable<long> source)
        {
            long sum = 0;
            foreach (var item in source)
            {
                sum += item;
            }

            return sum;
        }

        public static short Sum(this IEnumerable<short> source)
        {
            short sum = 0;
            foreach (var item in source)
            {
                sum += item;
            }

            return sum;
        }

        public static sbyte Sum(this IEnumerable<sbyte> source)
        {
            sbyte sum = 0;
            foreach (var item in source)
            {
                sum += item;
            }

            return sum;
        }

        public static uint Sum(this IEnumerable<uint> source)
        {
            uint sum = 0;
            foreach (var item in source)
            {
                sum += item;
            }

            return sum;
        }

        public static ulong Sum(this IEnumerable<ulong> source)
        {
            ulong sum = 0;
            foreach (var item in source)
            {
                sum += item;
            }

            return sum;
        }

        public static ushort Sum(this IEnumerable<ushort> source)
        {
            ushort sum = 0;
            foreach (var item in source)
            {
                sum += item;
            }

            return sum;
        }

        public static byte Sum(this IEnumerable<byte> source)
        {
            byte sum = 0;
            foreach (var item in source)
            {
                sum += item;
            }

            return sum;
        }

        public static bool IsNumber(this string str)
        {
            return Regex.IsMatch(str, @"^0??[^\D0]+$");
        }
    }
}
