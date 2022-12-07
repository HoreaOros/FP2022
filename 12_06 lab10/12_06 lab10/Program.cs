using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _12_06_lab10
{
    internal class Program
    {
        static readonly ulong MOD = 10234573;

        static void Main(string[] args)
        {
            ulong N;
            //N = ulong.Parse(Console.ReadLine());

            //Console.WriteLine(M1(N));
            //Console.WriteLine(M2(N));

            Majoritate();
        }

        private static void Majoritate()
        {
            int[] v = {1, 2 , 3, 4, 1, 4, 2, 4, 4 };
            int[] w = { 1, 1, 2, 2, 3, 4, 4, 4, 4 };
            int maxim = 0, c = 0, maj = 0; ;
            for (int i = 0; i < v.Length; i++)
            {
                c = 0;
                for (int j = 0; j < v.Length; j++)
                {
                    if (v[i] == v[j])
                    {
                        c++;
                    }
                }
                if (c > maxim)
                {
                    maxim = c;
                    maj = v[i];
                }
            }
            if (maxim > v.Length / 2)
            {
                Console.WriteLine($"Vectorul are element majoritar: {maj} apare de {maxim} ori");
            }
            else
                Console.WriteLine("Vectorul nu are element majoritar");
        }

        /*
* (a+b) mod N = (a mod N + b mod N) mod N
* (a*b) mod N = (a mod N * b mod N) mod N
* a = q1*N + r1, r1 = a mod N
* b = q2*N + r2, r2 = b mod N
* a + b = q1*N + r1 + q2*N + r2 = (q1+q2)N + r1 + r2
* (a + b) mod N = ((q1+q2)N + r1 + r2) mod N = (r1 + r2) mod N = (a mod N + b mod N) mod N
* 3 % 7 = 3
* 10 % 7 = 3
* 17 % 7 = 3
*/
        private static ulong M2(ulong n)
        {
            ulong a = n;
            ulong b = n + 1;
            ulong c = 2 * n + 1;

            if (a % 2 == 0)
                a = a / 2;
            else
                b = b / 2;
            if (a % 3 == 0)
                a = a / 3;
            else if (b % 3 == 0)
                b = b / 3;
            else
                c = c / 3;
            return (((a % MOD) * (b % MOD))% MOD *c) % MOD;
        }

        private static ulong M1(ulong n)
        {
            ulong suma = 0;
            for (ulong i = 1; i <= n; i++)
            {
                suma = suma + i * i;
            }
            return suma % MOD;
        }
    }
}
