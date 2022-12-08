using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _12_06_curs
{
    internal class Program
    {
        private static readonly Random rnd = new Random();
        static void Main(string[] args)
        {
            int[] v = InitArray(10, 1000);
            PrintArray(v);
            QuickSort(v);
            PrintArray(v);
        }
    /*
    _# choose pivot_
swap a[1, rand(1, n)]

_# 2-way partition_
k = 1
for i = 2:n, if a[i] < a[1], swap a[++k, i]
swap a[1, k]
_→ invariant: a[1..k - 1] < a[k] <= a[k + 1..n] _

_# recursive sorts_
sort a[1..k - 1]
sort a[k + 1, n]
        */
        private static void QuickSort(int[] v)
        {
            QuickSort(v, 0, v.Length - 1);
        }
        private static void QuickSort(int[] v, int lo, int hi)
        {
            if(lo < hi)
            {
                int index;
                index = rnd.Next(lo, hi + 1);
                (v[lo], v[index]) = (v[index], v[lo]);
                //int aux;
                //aux = v[lo]; v[lo] = v[index]; v[index] = aux;
                int k = lo;
                for (int i = lo + 1; i <= hi; i++)
                    if (v[i] < v[lo])
                    {
                        k++;
                        (v[k], v[i]) = (v[i], v[k]);
                    }
                (v[lo], v[k]) = (v[k], v[lo]);

                QuickSort(v, lo, k - 1);
                QuickSort(v, k + 1, hi);
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
            int[] v = new int[n];
            for (int i = 0; i < v.Length; i++)
            {
                v[i] = rnd.Next(max);
            }
            return v;
        }
    }
}
