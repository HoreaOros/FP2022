using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace N1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            
            P1();

        }

        /// <summary>
        /// Calculeaza suma numerelor de la 1 la n
        /// </summary>
        private static void P1()
        {
            int n;
            Console.WriteLine("Introduceti un numar natural!");
            n = int.Parse(Console.ReadLine());
            int suma = 0;

            for (int k = 1;  k <= n; k++)
            {
                suma = 0;
                for (int i = 1; i <= k; i++)
                {
                    checked
                    {
                        suma += i;
                    }
                }
                Console.WriteLine($"Suma numerelor de la 1 la {k} este {suma}");
            }
            
            
        }
    }
}
