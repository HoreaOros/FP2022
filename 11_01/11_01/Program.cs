using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _11_01
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //TestLeapYear();
            // TODO: scrieti o functie care determina numarul de zile dintre doua date calendaristice

            //x < 100 || Die();
            // if(x[i] % 2 == 0 && i < n) - nu e OK
            // if(i < n && x[i] % 2 == 0) - e OKish

            //Palindrom();
            // TODO: Sa se determine cel mai lung sufix palindrom al unui numar
            // Ex. 98121121

            //Stars1();
            //Stars2();
            //Stars3();

            //Stars4();
            //Stars5();


            //Coins();
            S1();
            S2();
            S3();
            S4();

        }

        private static void Coins()
        {
            int stake;
            int goal;
            int times = 10000;
            int wins = 0, losses = 0;


            Random rnd = new Random();

            for (int i = 1; i <= times; i++)
            {

                stake = 40;
                goal = 100;

                while (!(stake == 0 || goal == stake))
                {
                    if (rnd.Next(2) == 0)
                    {
                        stake++;
                    }
                    else
                    {
                        stake--;
                    }
                }
                if (stake == 0)
                {
                    losses++;
                }
                else if (stake == goal)
                {
                    wins++;
                }
            }

            Console.WriteLine($"Wins: {wins}, Losses: {losses}");
        }

        // TODO
        /// <summary>
        /// pt n = 4
        /// ********
        /// ***  ***
        /// **    **
        /// *      *
        /// *      *
        /// **    **
        /// ***  ***
        /// ********
        /// </summary>
        private static void Stars5()
        {
            throw new NotImplementedException();
        }

        // TODO
        /// <summary>
        /// pt n = 4 se va afisa:
        /// *      *
        /// **    **
        /// ***  ***
        /// ********
        /// <summary>
        private static void Stars4()
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// pt n = 4 se va afisa:
        /// ********
        /// ***  ***
        /// **    **
        /// *      *
        /// </summary>
        private static void Stars3()
        {
            int n;
            //Console.ForegroundColor = ConsoleColor.Green;
            n = int.Parse(Console.ReadLine());
            for (int i = 1; i <= n; i++)
            {
                for (int j = 1; j <= n - i + 1; j++)
                {
                    Console.Write('*');
                }
                for (int j = 1; j <= 2 *(i - 1); j++)
                {
                    Console.Write(' ');
                }
                for (int j = 1; j <= n - i + 1; j++)
                {
                    Console.Write('*');
                }

                Console.WriteLine();
            }
        }

        /// <summary>
        /// pt. n = 4
        /// ****
        /// ***
        /// **
        /// *
        /// </summary>
        private static void Stars2()
        {
            int n;
            //Console.ForegroundColor = ConsoleColor.Green;
            n = int.Parse(Console.ReadLine());


            for (int i = n; i >= 1; i--)
            {
                for (int j = 1; j <= i; j++)
                {
                    Console.Write('*');
                }
                Console.WriteLine();
            }
        }

        /// <summary>
        /// pt. n = 5
        /// *
        /// **
        /// ***
        /// ****
        /// *****
        /// </summary>
        private static void Stars1()
        {
            int n;
            //Console.ForegroundColor = ConsoleColor.Green;
            n = int.Parse(Console.ReadLine());

            
            for (int i = 1; i <= n; i++)
            {
                for (int j = 1; j <= i; j++)
                {
                    Console.Write('*');
                }
                Console.WriteLine();
            }
        }

        private static void Palindrom()
        {
            Console.WriteLine("Introduceti un numar natural:");
            int n;
            n = int.Parse(Console.ReadLine());
            
            if (n.IsPalindrom())
                Console.WriteLine($"{n} este palindrom");
            else
                Console.WriteLine($"{n} nu este palindrom");
        }

        private static void TestLeapYear()
        {
            for (int n = 1582; n <= 2022; n++)
            {
                EsteBisect(n);
            }
            
        }

        private static void EsteBisect(int n)
        {
            if (((n % 4 == 0) && (n % 100 != 0)) || 
                    (n % 400 == 0))
                Console.WriteLine($"{n} este an bisect");
            else
                Console.WriteLine($"{n} nu este an bisect");
        }

        private static void EsteBisect()
        {
            int n; 
            n = int.Parse(Console.ReadLine());

            EsteBisect(n);
            
        }
        /// <summary>
        /// pt n = 4 se va afisa:
        /// *      *
        /// **    **
        /// ***  ***
        /// ********
        /// </summary>
        private static void S1()
        {
            Console.WriteLine("Introduceti valoarea n");
            int n;
            Console.ForegroundColor = ConsoleColor.Green;
            n = int.Parse(Console.ReadLine());
            for (int i = n; i >= 1; i--)
            {
                for (int j = 1; j <= n - i + 1; j++) Console.Write('*');
                for (int j = 1; j <= 2 * (i - 1); j++) Console.Write(' ');
                for (int j = 1; j <= n - i + 1; j++) Console.Write('*');
                Console.WriteLine();
            }
            Console.ReadKey();
        }
        /// <summary>
        /// pt n = 4
        /// ********
        /// ***  ***
        /// **    **
        /// *      *
        /// *      *
        /// **    **
        /// ***  ***
        /// ********
        /// </summary>
        private static void S2()
        {
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("Introduceti valoarea n");
            int n;
            Console.ForegroundColor = ConsoleColor.Green;
            n = int.Parse(Console.ReadLine());
            for (int i = 1; i <= n; i++)
            {
                for (int j = 1; j <= n - i + 1; j++) Console.Write('*');
                for (int j = 1; j <= 2 * (i - 1); j++) Console.Write(' ');
                for (int j = 1; j <= n - i + 1; j++) Console.Write('*');
                Console.WriteLine();
            }
            for (int i = n; i >= 1; i--)
            {
                for (int j = 1; j <= n - i + 1; j++) Console.Write('*');
                for (int j = 1; j <= 2 * (i - 1); j++) Console.Write(' ');
                for (int j = 1; j <= n - i + 1; j++) Console.Write('*');
                Console.WriteLine();
            }
            Console.ReadKey();

        }
        /// <summary>
        ///Sa se determine cel mai lung sufix palindrom al unui numar
        ///Ex. 98121121
        /// </summary>
        private static void S3()
        {
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("Introduceti numarul n");
            int n = int.Parse(Console.ReadLine());
            int aux, max = n % 10, o = 0, nr = 1, p, aux2;
            aux = n;
            while (aux > 0)
            {
                nr++;
                aux = aux / 10;
            }
            for (int i = 1; i <= nr; i++)
            {
                p = Convert.ToInt32(Math.Pow(10, i));
                aux = n % p;
                aux2 = aux;
                o = 0;
                while (aux > 0)
                {
                    o = (o * 10) + (aux % 10);
                    aux = aux / 10;
                }
                if (o == aux2) { if (o > max) max = o; }

            }
            Console.WriteLine(max);
            Console.ReadKey();

        }/// <summary>
         ///  scrieti o functie care determina numarul de zile dintre doua date calendaristice
         /// </summary>
        private static void S4()
        {
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("Introduceti cele 2 date,una sub cealalta");


            DateTime d1 = Convert.ToDateTime(Console.ReadLine());
            DateTime d2 = Convert.ToDateTime(Console.ReadLine());
            Console.WriteLine("Numarul de zile dintre cele 2 date este ");
            Console.WriteLine((d2 - d1).TotalDays);
        }
    }
}
