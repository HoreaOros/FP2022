using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace _12_20
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[,] m = ReadMatrix("input.txt");
            PrintMatrix(m);

            Spiral(m);
            
            Serpuire(m);
            Alternare(m);

            Console.WriteLine($"Suma elementelor din partea de Nord: {Nord(m)}");
            Console.WriteLine($"Suma elementelor din partea de Sud: {Sud(m)}");
            Console.WriteLine($"Suma elementelor din partea de Vest: {Vest(m)}");
            Console.WriteLine($"Suma elementelor din partea de Est: {Est(m)}");
        }

        private static int Est(int[,] m)
        {
            int sum = 0;
            //TODO
            return sum;
        }

        private static int Vest(int[,] m)
        {
            int sum = 0;
            //TODO
            return sum;
        }

        private static int Sud(int[,] m)
        {
            int sum = 0;
            //TODO
            return sum;
        }

        private static int Nord(int[,] m)
        {
            int sum = 0;
            if (m.GetLength(0) != m.GetLength(1))
            {
                throw new ArgumentException();
            }
            for (int i = 0; i < m.GetLength(0); i++)
            {
                for (int j = 0; j < m.GetLength(1); j++)
                {
                    if (i < j && i + j < m.GetLength(0) - 1)
                    {
                        sum += m[i, j];
                    }
                }
            }

            return sum;
        }

        /// <summary>
        /// Trebuie generate elementele matricii
        /// dupa modelul de mai jos:
        /// 1 1 1 1 1 1
        /// 1 0 0 0 0 1
        /// 1 0 1 1 0 1
        /// 1 0 1 1 0 1
        /// 1 0 0 0 0 1
        /// 1 1 1 1 1 1
        /// </summary>
        /// <param name="m"></param>
        private static void Alternare(int[,] m)
        {
            // TODO
        }

        /// <summary>
        /// Pentru matricea:
        /// 1  3  4 10
        /// 2  5  9 11
        /// 6  8 12 15
        /// 7 13 14 16
        /// Se afiseaza: 1 2 3 ... 16
        /// </summary>
        /// <param name="m">Matrix</param>
        /// <exception cref="NotImplementedException"></exception>
        private static void Serpuire(int[,] m)
        {
            // TODO
        }



        private static void Spiral(int[,] m)
        {
            int total = m.GetLength(0) * m.GetLength(1);
            int i1 = 0, j1 = 0;
            int i2 = m.GetLength(0) - 1;
            int j2 = m.GetLength(1) - 1;
            int count = 0;
            do
            {
                for (int k = j1; k < j2; k++)
                {
                    Console.Write($"{m[i1, k]} ");
                    count++;
                }
                
                if (count == total)
                    break;
                for (int k = i1; k < i2; k++)
                {
                    Console.Write($"{m[k, j2]} ");
                    count++;
                }
                if (count == total)
                    break;

                for (int k = j2; k > j1; k--)
                {
                    Console.Write($"{m[i2, k]} ");
                    count++;
                }
                if (count == total)
                    break;
                for (int k = i2; k > i1; k--)
                {
                    Console.Write($"{m[k, j1]} ");
                    count++;
                }
                if (count == total)
                    break;

                i1++;j1++;
                i2--;j2--;
            } while (true);
            Console.WriteLine();
        }

        private static void PrintMatrix(int[,] m)
        {
            for (int i = 0; i < m.GetLength(0); i++)
            {
                for (int j = 0; j < m.GetLength(1); j++)
                {
                    Console.Write($"{m[i, j],3} ");
                }
                Console.WriteLine();
            }
        }

        private static int[,] ReadMatrix(string fileName)
        {
            using (StreamReader sr = new StreamReader(fileName))
            {
                int n;
                n = int.Parse(sr.ReadLine());
                string line;
                int[,] matrix = new int[n, n];
                for (int i = 0; i < n; i++)
                {
                    line = sr.ReadLine();
                    string[] tokens = line.Split(new char[] {' '}, StringSplitOptions.RemoveEmptyEntries);
                    for (int j = 0; j < tokens.Length; j++)
                    {
                        matrix[i, j] = int.Parse(tokens[j]);
                    }
                }
                return matrix;
            }
        }
    }
}
