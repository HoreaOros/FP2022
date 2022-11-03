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
            //Days_Between_Dates // TODO Completat

            //x < 100 || Die();
            // if(x[i] % 2 == 0 && i < n) - nu e OK
            // if(i < n && x[i] % 2 == 0) - e OKish

            // Palindrom();
            // TODO: Sa se determine cel mai lung sufix palindrom al unui numar
            // Ex. 98121121
            //SufixPalindrom(); // TODO Completat

            //Stars1();
            //Stars2();
            //Stars3();

            //Stars4();
            //Stars5();


            //Coins();
        }

        private static void SufixPalindrom()
        {
            Console.WriteLine("Introduceti numarul de testat:");
            int n = int.Parse(Console.ReadLine());
            int naux = n;
            int naux2 = 0;
            int naux3 = 0;
            while (naux > 0)
            {
                naux2 = naux2 * 10 + naux % 10;
                naux = naux / 10;
                if (naux2.IsPalindrom())
                {
                    naux3 = naux2;
                }
                
            }
            Console.WriteLine($"Cel mai lung sufix palindrom al numarului {n} este {naux3}");
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

        // TODO - done
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
            int n;
            n = int.Parse(Console.ReadLine());
            for (int i = 1; i <= n; i++)
            {
                for (int j = 1; j <= n - i + 1; j++)
                {
                    Console.Write('*');
                }
                for (int j = 1; j <= 2 * (i - 1); j++)
                {
                    Console.Write(' ');
                }
                for (int j = 1; j <= n - i + 1; j++)
                {
                    Console.Write('*');
                }

                Console.WriteLine();
            }
            for (int i = n; i > 0; i--)
            {
                for (int j = 1; j <= n - i + 1; j++)
                {
                    Console.Write('*');
                }
                for (int j = 1; j <= 2 * (i - 1); j++)
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

        // TODO - done
        /// <summary>
        /// pt n = 4 se va afisa:
        /// *      *
        /// **    **
        /// ***  ***
        /// ********
        /// <summary>
        private static void Stars4()
        {
            int n;
            //Console.ForegroundColor = ConsoleColor.Green;
            n = int.Parse(Console.ReadLine());
            for (int i = n; i > 0; i--)
            {
                for (int j = 1; j <= n - i + 1; j++)
                {
                    Console.Write('*');
                }
                for (int j = 1; j <= 2 * (i - 1); j++)
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
        private static void Days_Between_Dates()
        {
            try
            {
                Console.WriteLine("Introduceti prima data in format DD/MM/YYYY (ZZ/LL/AAAA):");
                string date1 = Console.ReadLine();
                date1 = date1.Replace(" ", "/");
                string[] dateS = date1.Split('/', (char)StringSplitOptions.RemoveEmptyEntries);
                int[] dateI = new int[3];
                dateI[0] = int.Parse(dateS[0]);
                dateI[1] = int.Parse(dateS[1]);
                dateI[2] = int.Parse(dateS[2]);
                DateTime an1 = new DateTime(dateI[2], dateI[1], dateI[0]);

                Console.WriteLine("Introduceti a doua data in format DD/MM/YYYY (ZZ/LL/AAAA):");
                date1 = Console.ReadLine();
                date1 = date1.Replace(" ", "/");
                dateS = date1.Split('/', (char)StringSplitOptions.RemoveEmptyEntries);
                dateI[0] = int.Parse(dateS[0]);
                dateI[1] = int.Parse(dateS[1]);
                dateI[2] = int.Parse(dateS[2]);
                DateTime an2 = new DateTime(dateI[2], dateI[1], dateI[0]);
                TimeSpan distance = an2 - an1;
                Console.WriteLine($"Sunt {distance.Days} de zile intre cele 2 date introduse");
            }
            catch (Exception)
            {
                Console.WriteLine("Data / Datele nu au fost introduse corect!!!");
                Console.ReadKey();
            }
        }

    }
}
