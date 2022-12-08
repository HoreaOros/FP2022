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
            Console.WriteLine("{0}", M2(N));
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
