using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Matrici
{
    internal class Program
    {
        private static readonly Random rnd = new Random();
        static void Main(string[] args)
        {
            Console.WriteLine("Matrici");
            int[,] data1 = InitMatrix(3, 4, 100);
            PrintMatrix(data1, "data1");

            int[,] data2 = InitMatrix(4, 5, 100);
            PrintMatrix(data2, "data2");
            
            int[,] data3 = Multiply(data1, data2);
            PrintMatrix(data3, "data1*data2");
        }

        private static int[,] Multiply(int[,] data1, int[,] data2)
        {
            if (data1.GetLength(1) != data2.GetLength(0))
            {
                throw new ArgumentException();
            }
            int[,] result = new int[data1.GetLength(0), data2.GetLength(1)];
            for (int i = 0; i < data1.GetLength(0); i++)
            {
                for (int j = 0; j < data2.GetLength(1); j++)
                {
                    int suma = 0;
                    for (int k = 0; k < data1.GetLength(1); k++)
                    {
                        suma += data1[i, k] * data2[k, j];
                    }
                    result[i, j] = suma;
                }
            }
            return result;
        }

        private static void PrintMatrix(int[,] data, string mesaj)
        {
            Console.WriteLine(mesaj);
            for (int i = 0; i < data.GetLength(0); i++)
            {
                for (int j = 0; j < data.GetLength(1); j++)
                {
                    Console.Write($"{data[i, j], 3} ");
                }
                Console.WriteLine();
            }
            Console.WriteLine();
        }

        private static int[,] InitMatrix(int linii, int coloane, int maxim)
        {
            int[,] data = new int[linii, coloane];
            for (int i = 0; i < data.GetLength(0); i++)
            {
                for (int j = 0; j < data.GetLength(1); j++)
                {
                    data[i, j] = rnd.Next(maxim);
                }
            }
            return data;
        }
    }
}
