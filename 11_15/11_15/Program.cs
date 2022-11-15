

using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.Linq;
using System.Globalization;
using System.Runtime.InteropServices;

namespace _11_15
{
    // vectori
    internal class Program
    {
        static Random rnd = new Random();
        static void Main(string[] args)
        {
            int[] v1, v2, v3, v4;
            int[] vtest = new int[] { 1,2,3,4,5,2,3,4 };
            //v = new int[] { 0, 1, 2, 3};

            v1 = InitArray(10);
            v2 = InitArray(10, 100);
            v3 = InitArray(10, 100);

            PrintArray(v1);
            PrintArray(v2);
            PrintArray(v3);
            // todo - done
            LRSNO(vtest);
            // todo

            int k = rnd.Next(100);
            int pos;
            if ((pos = Cautare(v2, k)) != -1)
            {
                Console.WriteLine($"Am gasit elementul {k} pe pozitia {pos}");
            }
            else
                Console.WriteLine($"Nu am gasit elementul {k} in vector");


            Array.Sort(v2);
            PrintArray(v2);

            if ((pos = CautareBinara(v2, k)) != -1)
                Console.WriteLine($"Am gasit elementul {k} pe pozitia {pos}");
            else
                Console.WriteLine($"Nu am gasit elementul {k} in vector");

            // TODO - done
            // https://en.wikipedia.org/wiki/Binary_search_algorithm
            // Implementati operatiile de cautare aproximativa:
            // Rank, predecesor, succesor, cel mai aporpiat vecin. 
            CautareBinaraExtra(v2, k);

            ////v4 = InitArray(1000000, 10);
            ////PrintArray(v4);
            ////int[] f = InitArray(10);
            ////DeterminaFrecvente(v4, f);
            ////PrintArray("Frecventa de aparitie a cifrelor este: ", f);
        }
        private static void CautareBinaraExtra(int[] v, int k)
        {
            int stg, dr, mij;
            int count = 0;
            int finds;
            int predecessor = 0;
            int successor = v.Length;
            int vecin;
            int rank;

            stg = 0;
            dr = v.Length - 1;
            while (stg <= dr)
            {
                mij = (stg + dr) / 2;
                if (v[mij] < k)
                {
                    stg = mij + 1;
                    predecessor = mij;
                }
                else if (v[mij] > k)
                {
                    dr = mij - 1;
                    successor = mij;
                }

                else
                {
                    finds = mij;
                }
            }
            if (v[predecessor] > v[successor])
            {
                vecin = predecessor;
            }
            else
            {
                vecin = successor;
            }
            rank = predecessor + 1;
            Console.WriteLine($"Pentru {k}:{Environment.NewLine}Rank:{rank}.{Environment.NewLine}Sucessor:{v[successor]}.{Environment.NewLine}Predecessor:{v[predecessor]}.{Environment.NewLine}Vecin:{v[vecin]}.");
            return;
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
        private static void LRSNO(int[] v)
        {
            List<int> list = new List<int>(); // lista de referinta din care verificam daca este o secventa care se repeta sau nu
            List<string> listst = new List<string>(); // lista secventelor repetate
            List<int> liststlength = new List<int>(); // lista lungimii secventelor repetate
            int count = 0; // contor pt lungimea secventei
            for (int j = 0; j < v.Length; j++) 
            {
                if (list.Contains(v[j])) // daca lista o contine pe v[j] atunci ii o sansa de repetitie.
                {
                    
                    for (int i = 0; i < j; i++)
                    {
                        int f = j; // sa nu se suprapuna aici secventa repetata
                        int k = i;
                        string toadd = "";
                        count = 0;
                        while (f < v.Length && k < j && v[k] == v[f]) // se verifica o secventa care se repeta si se adauga intr-o lista
                        {
                            
                            toadd = toadd + Convert.ToString(v[k] + " ");
                            k++;
                            f++;
                            count++;
                            
                        }
                        liststlength.Add(count);
                        listst.Add(toadd);
                        //Console.WriteLine();
                    }                
                }
                else
                {
                    list.Add(v[j]);
                }
            }
            int[] lengthcheck = liststlength.ToArray(); // tablou pt lungimea secventelor repetate
            string[] tocheck = listst.ToArray(); // tablou pt secventele repetate in format string
            int longestst = 0; 
            for(int i = 0; i < tocheck.Length; i++) // gasirea celei mai lungi secvente repetate.
            {
                if (lengthcheck[i] > longestst)
                {
                    longestst = lengthcheck[i];
                }
                //Console.WriteLine(lengthcheck[i]);
            }
            if (longestst > 1)
            {
                for (int i = 0; i < tocheck.Length; i++)
                {
                    if (longestst == lengthcheck[i])
                    {
                        Console.WriteLine(tocheck[i]);
                        Console.WriteLine();
                    }
                }
            }
            else
            {
                Console.WriteLine("tabloul nu are o secventa de minimum 2 numere care se repeta.");
            }

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
