

using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
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
            //v = new int[] { 0, 1, 2, 3};

            v1 = InitArray(10);
            v2 = InitArray(10, 100);
            v3 = InitArray(10, 100);

            PrintArray(v1);
            PrintArray(v2);
            PrintArray(v3);

            LRSNO(v2);


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

            int rank = LowerBound(v2, k);
            int predecesor = v2[Math.Max(LowerBound(v2,k)-1, 0)]; //pentru a nu iesi indexul din vector
            int succesor = v2[Math.Min(UpperBound(v2,k),v2.Length-1)];//pentru a nu iesi indexul din vector
            int cmav = 0;
            if (k - predecesor < succesor - k)
                cmav = predecesor;
            else
                cmav = succesor;
            Console.WriteLine($"k: {k} rank: {rank}, predecesor: {predecesor}, succesor: {succesor}, cel mai apropiat vecin: {cmav}");
            

            v4 = InitArray(1000000, 10);
            //PrintArray(v4);
            int[] f = InitArray(10);
            DeterminaFrecvente(v4, f);
            PrintArray("Frecventa de aparitie a cifrelor este: ", f);
            
            Console.ReadLine();
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

        private static int LowerBound(int[] v, int k)
        {
            int st, dr, mij;
            st = 0;
            dr = v.Length - 1;
            while (st < dr)
            {
                mij = (st + dr)/2;
                if (v[mij] < k)
                    st = mij + 1;      
                else
                    dr = mij;
            }
            if (st < v.Length && v[st] < k)
                st++;
            return st;
        }

        private static int UpperBound(int[] v, int k)
        {
            int st, dr, mij;
            st = 0;
            dr = v.Length - 1;
            while (st < dr)
            {
                mij = (st + dr)/ 2;
                if (v[mij] <= k)
                    st = mij + 1;
                else
                    dr = mij;
            }
            if (st < v.Length && v[st]<k)
                st++;
            return st;
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
            int[] p = new int[v.Length];//vector ce stocheaza lungimea maxima
                                        //a unei secvente repetabile care se termina cu elementul respectiv
            //cazurile de baza
            for (int i = 0; i < v.Length; i++)
                p[i] = 1;//lungimea minima pe care o poate avea o secventa este 1
            for (int i = 1; i < v.Length - 1; i++)//tratam separat elementul de pe pozitia 0
                if (v[0] == v[i] && v[1] == v[i + 1])
                {
                    p[1] = 2;
                    break;
                }
            //cazul general
            for (int i=1;i<v.Length-1;i++)//pentru fiecare element din vector
            {
                for(int j=i+1;j<v.Length;j++)//cautam printre elementele care il urmeaza, un element care respecta proprietatea ceruta
                {
                    if (v[i] == v[j] && v[i - 1] == v[j - 1])//daca gasim un element de acest fel
                        p[j] = p[j - 1] + 1;//lungimea maxima a secventei creste pentru elementul respectiv
                }
            }

            //caut pozitia pe care se afla ultima secventa repetabila de lungime maxima
            int maxVal = p[0];
            int pozMaxVal = 0;

            for(int i=1;i<v.Length;i++)
            {
                if (p[i]>=maxVal)
                {
                    maxVal= p[i];
                    pozMaxVal = i;
                }
            }

            //afisare
            Console.Write("Ultima secventa de lungime maxima care se repeta este: ");
            AfiseazaSecventa(v, p, pozMaxVal);
            Console.WriteLine();
        }

        /// <summary>
        /// afiseaza recursiv o secventa de lungime maxima
        /// </summary>
        /// <param name="v"></param>
        /// <param name="p"></param>
        /// <param name="poz"></param>
        private static void AfiseazaSecventa(int[] v, int[] p, int poz)
        {
            if (p[poz]>1)
                AfiseazaSecventa(v, p, poz - 1);
            Console.Write($"{v[poz]} ");
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
