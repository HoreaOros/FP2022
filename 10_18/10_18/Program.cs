using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;
namespace N1
{
    internal class Program
    {
        static void Main(string[] args)
        {

            //P1();
            //P2();
            //P3();

            P4();


        }

        /// <summary>
        /// Determinati daca trei numere pozitive a, b si c pot fi lungimile laturilor unui triunghi. 
        /// </summary>
        private static void P4()
        {
            Console.WriteLine("Introduceti 3 numere naturale - pe o singura linie, separate prin spatiu");
            int a, b, c;

            string line;
            line = Console.ReadLine();
            char[] separator = new char[] { ' ', ',', ';' };
            string[] tokens = line.Split(separator, StringSplitOptions.RemoveEmptyEntries);

            a = int.Parse(tokens[0]); 
            b = int.Parse(tokens[1]); 
            c = int.Parse(tokens[2]);

            if (a < b + c && b < a + c && c < a + b)
                Console.WriteLine("Triunghi");
            else
                Console.WriteLine("Nu e triunghi");
            {

            }

        }

        private static void P3()
        {
            int n;
            Console.WriteLine("Introduceti un numar natural!");
            n = int.Parse(Console.ReadLine());
            int suma = 0;

            Console.WriteLine($"Suma numerelor de la 1 la {n} este {n * (n + 1)/2}");
        }

        private static void P2()
        {
            int n;
            Console.WriteLine("Introduceti un numar natural!");
            n = int.Parse(Console.ReadLine());
            int suma = 0;
            Stopwatch sw = new Stopwatch();
            sw.Start();
            
            for (int i = 1; i <= n; i++)
            {
                suma += i;
                //Console.WriteLine($"Suma numerelor de la 1 la {i} este {suma}");
            }

            sw.Stop();
            Console.WriteLine($"Operatia a durat: {sw.ElapsedMilliseconds}");
        }

        /// <summary>
        /// Calculeaza suma numerelor de la 1 la 1, 1 la 2, ...
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
