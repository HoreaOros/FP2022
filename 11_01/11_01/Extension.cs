using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _11_01
{
    internal static class Extension
    {
        public static bool IsPalindrom(this int n)
        {
            return n == ReverseInt(n);
        }

        private static int ReverseInt(int n)
        {
            int c;
            int result = 0;
            while (n > 0)
            {
                c = n % 10;
                result = result * 10 + c;
                n = n / 10; 
            }
            return result; 
        }

        private static int Reverse(int n)
        {
            return int.Parse(string.Concat(n.ToString().Reverse()));
        }

    }
}
