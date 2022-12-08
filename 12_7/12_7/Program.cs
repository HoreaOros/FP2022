using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace _12_7
{
    internal class Program
    {
        private static readonly ulong MOD = 10234573;
        static void Main(string[] args)
        {
            ulong N;
            N = ulong.Parse(Console.ReadLine());
            //Console.WriteLine(M1(N));
            //Console.WriteLine(M2(N));
            Console.WriteLine(M3(N));
        }

        private static ulong M2(ulong n)
        {
            ulong suma;
            suma = n * (n + 1) * (2 * n + 1) / 6;
            return suma % MOD;
        }
        private static ulong M3(ulong n)
        {
            /*
            n = 3*k
            n = 3*k + 1
            n = 3*k + 2
            */
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
            return a % MOD  * b % MOD * c % MOD;
        }
        /*
         * (a+b) mod n = (a mod n + b mod n) mod n
         * (a*b) mod n = (a mod n * b mod n) mod n
         * a = q1*n + r1, r1 = a mod n
         * b = q2*n + r2, r2 = b mod n
         * a+b = q1*n + r1 + q2*n + r2 = n(q1+q2) + r1 + r2 / mod n
         * (a+b) mod n = [n(q1+q2) + r1 + r2] mod n
         * (a+b) mod n = [nQ + r1 + r2] mod n
         * (a+b) mod n = [r1 + r2] mod n
         * (a+b) mod n = (a mod n + b mod n) mod n
         * Ex. 3 mod 7 = 3, 10 mod 7 = 3, (3 + 2*7) mod 7 = 3
         */

        private static ulong M1(ulong n)
        {
            ulong suma = 0;
            for (ulong i = 1; i <= n; i++)
            {
                suma += i * i;
            }
            return suma % MOD;
        }
    }
}
