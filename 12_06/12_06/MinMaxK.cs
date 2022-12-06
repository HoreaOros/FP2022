using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _12_06
{
    internal class MinMaxK
    {
        static void Main(string[] args)
        {
            int k;

            do
            {
                k = ExtractNextInt();
                Console.WriteLine(k);
            } while (k != 0);
            


        }

        private static int ExtractNextInt()
        {
            int nr = 0;
            int ch;
            do
            {
                ch = Console.Read();
                if (ch == -1)
                {
                    return 0;
                }
            } while (char.IsWhiteSpace((char)ch));
            
            while (char.IsDigit((char)ch))
            {
                nr = nr * 10 + ch - '0';
                ch = Console.Read();
                if (ch == -1)
                {
                    return 0;
                }
            }

            

            return nr;
        }
    }
}
