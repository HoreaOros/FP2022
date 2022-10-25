using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _10_25
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //P1();
            P2();
        }

        /// <summary>
        /// Verificam daca un numar este prim
        /// </summary>
        private static void P2()
        {
            int n;
            n = int.Parse(Console.ReadLine());

            if (n < 2)
            {
                Console.WriteLine("Nu e prim");
                return;
            }
            if (n == 2)
            {
                Console.WriteLine("E prim");
                return;
            }

            for (int d  = 2; d*d  <= n; d++)
            {
                if (n % d == 0)
                {
                    Console.WriteLine("Nu e prim");
                    return;
                }
            }
            Console.WriteLine("E prim");


        }

        /// <summary>
        /// Se citesc 3 numere de pe o linie a ecranului 
        /// si trebuie afisate in ordine crescatoare
        /// </summary>
        /// <example>Daca se citeste 5 3 2 se afiseaza 2 3 5</example>
        /// <exception cref="OverflowException"></exception>
        /// <exception cref="IndexOutOfRangeException"></exception>
        private static void P1()
        {
            int a, b, c;
            string line;

            line = Console.ReadLine();
            char[] sep = { ' ', ';', ','  };
            string[] tokens = line.Split(sep, StringSplitOptions.RemoveEmptyEntries);

            a = int.Parse(tokens[0]); 
            b = int.Parse(tokens[1]); 
            c = int.Parse(tokens[2]);

            // Varianta 1;

            int aux;
            if (a > b)
            {
                aux = a;
                a = b;
                b = aux;

                // alternativa
                
                //a = a + b;
                //b = a - b;
                //a = a - b;
                //a   b
                //-----
                //1   2
                //3
                //    1
                //2

            }
            if (a > c)
            {
                aux = a;
                a = c;
                c = aux;
            }
            if (b > c)
            {
                aux = b;
                b = c;
                c = aux;
            }

            Console.WriteLine($"{a} {b} {c}");

            // Varianta 2
            int minim;
            minim = a;
            if (b < minim)
            {
                minim = b;
            }
            if (c < minim)
            {
                minim = c;
            }
            int maxim;
            maxim = a;
            if (b > maxim)
            {
                maxim = b;
            }
            if (c > maxim)
            {
                maxim = c;
            }

            Console.WriteLine($"{minim} {a + b + c - minim - maxim} {maxim}");

            // Varianta 3
            minim = Math.Min(a, Math.Min(b, c));
            maxim = Math.Max(b, Math.Max(c, a));
            Console.WriteLine($"{minim} {a + b + c - minim - maxim} {maxim}");
        }
    }
}
