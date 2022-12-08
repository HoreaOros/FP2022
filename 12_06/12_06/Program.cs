using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace _12_06
{
    internal class Program
    {
        const ulong M = 10234573;
        static void Main(string[] args)
        {
            ulong N;
            N = ulong.Parse(Console.ReadLine());
            //M1(N);
            M2(N);
        }
        /// <summary>
        /// O(1)
        /// </summary>
        /// <param name="N"></param>
        private static void M2(ulong N)
        {
            // S = n*(n+1)*(2n+1)/6
            ulong S = N * (N + 1) * (2 * N + 1) / 6;
            ulong a = N;
            ulong b = N + 1;
            ulong c = 2*N + 1;
            
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


            Console.WriteLine("{0}", ((a * b) % M * c) % M);
        }
        private static void M1(ulong n)
        {
            ulong suma = 0;
            for (ulong i = 1; i <= n; i++)
            {
                suma = (suma + (i * i) % M) % M;
            }
            Console.WriteLine("{0}", suma);
        }
    }
}
/*
(a+b) mod n = ((a mod n) + (b mod n)) mod n
(a*b) mod n = ((a mod n) * (b mod n)) mod n

Justificare 
a = q1*n + r1, unde r1 = a mod n
b = q2*n + r2, unde r2 = a mod n
a+b = n*(q1+q2) + (r1+r2)
(a+b) mod n = (n*(q1+q2) + (r1+r2)) mod n
(a+b) mod n = ((r1+r2)) mod n
(a+b) mod n = ((a mod n) + (b mod n)) mod n
 */
