using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab10
{
    internal class Program
    {
        private static readonly ulong MODULUS = 10234573;
        static void Main(string[] args)
        {
            ulong N;
            N = ulong.Parse(Console.ReadLine());
            //Console.WriteLine("{0}", M1(N));
            //Console.WriteLine("{0}", M2(N));
            Console.WriteLine("{0}", M3(N));
        }


        /*
         * n = 3k, 3k+1, 3k+2 
         * (a + b) mod n = (a mod n + b mod n) mod n
         * (a * b) mod n = (a mod n * b mod n) mod n
         * (a * b * c) mod n = (a mod n * b mod n * c mod n) mod n
         */

        private static ulong M3(ulong n)
        {
            ulong a, b, c;
            a = n;
            b = n + 1;
            c = 2 * n + 1;

            if (a % 2 == 0)
                a /= 2;
            else
                b /= 2;

            if (a % 3 == 0)
                a /= 3;
            else if (b % 3 == 0)
                b /= 3;
            else
                c /= 3;
            return (a % MODULUS * b % MODULUS * c) % MODULUS;
        }

        private static ulong M2(ulong n)
        {
            ulong suma = 0;
            suma = n * (n + 1) * (2 * n + 1) / 6;
            return suma % MODULUS;
        }

        private static ulong M1(ulong N)
        {
            ulong suma = 0;
            for (ulong i = 1; i <= N; i++)
            {
                suma += i * i;
            }

            return suma % MODULUS;
        }

    }
}
