

using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
namespace _11_15
{
    // vectori
    internal class Program
    {
        static Random rnd = new Random();
        static void Main(string[] args)
        {
            int[] v1, v2, v3, v4;
            //v = new int[] { 0, 1, 2, 3};

            v1 = InitArray(10);
            v2 = InitArray(10, 100);
            v3 = InitArray(10, 100);

            PrintArray(v1);
            PrintArray(v2);
            PrintArray(v3);

            //LRSNO(v2);


            int k = rnd.Next(100);
            int pos;
            if ((pos = Cautare(v2, k) ) != -1)
            {
                Console.WriteLine($"Am gasit elementul {k} pe pozitia {pos}");
            }
            else
                Console.WriteLine($"Nu am gasit elementul {k} in vector");


            Array.Sort(v2);
            PrintArray(v2);

            if((pos = CautareBinara(v2, k)) != -1)
                Console.WriteLine($"Am gasit elementul {k} pe pozitia {pos}");
            else
                Console.WriteLine($"Nu am gasit elementul {k} in vector");

            // TODO
            // https://en.wikipedia.org/wiki/Binary_search_algorithm
            // Implementati operatiile de cautare aproximativa:
            // Rank, predecesor, succesor, cel mai aporpiat vecin. 


            v4 = InitArray(1000000, 10);
            //PrintArray(v4);
            int[] f = InitArray(10);
            DeterminaFrecvente(v4, f);
            PrintArray("Frecventa de aparitie a cifrelor este: ", f);
        }

        private static void DeterminaFrecvente(int[] v, int[] f)
        {
            for (int i = 0; i < v.Length; i++)
                f[v[i]]++;
        }

        private static void PrintArray(string mesaj, int[] f)
        {
            Console.WriteLine(mesaj);
            PrintArray(f);
        }

        /// <summary>
        /// Cauta cheia in vector. 
        /// </summary>
        /// <param name="v2">Vectorul sortat crescator</param>
        /// <param name="k">Cheia</param>
        /// <returns>Indexul pe care se afla cheia sau -1 daca nu este gasita cheia</returns>
        /// <exception cref="NotImplementedException"></exception>
        private static int CautareBinara(int[] v, int k)
        {
            int stg, dr, mij;
            stg = 0;
            dr = v.Length - 1;
            while (stg <= dr)
            {
                mij = (stg + dr) / 2;
                if (v[mij] < k)
                    stg = mij + 1;
                else if (v[mij] > k)
                    dr = mij - 1;
                else
                    return mij;
            }
            return -1;
        }

        /// <summary>
        /// Se cauta in vectorul v cheia k.
        /// Cautare liniara cu comlexitate O(n)
        /// </summary>
        /// <param name="v">vectorul in care se cauta</param>
        /// <param name="k">cheia pe care o cautam</param>
        /// <returns>Pozitia pe care se afla cheia in vector sau -1 daca cheia nu este gasita</returns>
        private static int Cautare(int[] v, int k)
        {
            for (int i = 0; i < v.Length; i++)
            {
                if (v[i] == k)
                {
                    return i;
                }
            }

            return -1;

        }

        // TODO
        /// <summary>
        /// Determina cea mai lunga secventa din vector care se repeta. 
        /// Secventa nu se suprapune cu repetitia ei. 
        /// Trebuie realizata o solutie eficienta care 
        /// sa aiba complexitatea mai mica de O(n^3). 
        /// </summary>
        /// <example>
        /// 1 2 3 4 5 2 3 4 -> rezultatul este 2 3 4 
        /// </example>
        /// <param name="v"></param>
        /// <exception cref="NotImplementedException"></exception>
        private static void LRSNO(int[] v)
        {
            throw new NotImplementedException();
        }

        private static void PrintArray(int[] v)
        {
            for (int i = 0; i < v.Length; i++)
            {
                Console.Write($"{v[i]} ");
            }
            Console.WriteLine();
        }

        private static int[] InitArray(int n, int max)
        {
            int[] v;
            v = new int[n];
            //Thread.Sleep(10);
            
            for (int i = 0; i < v.Length; i++)
            {
                v[i] = rnd.Next(max);
            }
            return v;
        }

        private static int[] InitArray(int n)
        {
            return new int[n];
        }
    }
}
