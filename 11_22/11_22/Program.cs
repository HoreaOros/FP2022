using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using P15 = _11_15;

namespace _11_22
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //int[] v = P15.Program.InitArray(10, 100);
            //P15.Program.PrintArray(v);
            //SelectionSort(v);

            //BubbleSort(v);

            //InsertionSort(v);
            //P15.Program.PrintArray(v);
            DoublingTest();


            
        }


        public static void MergeSort(int[] v)
        {
            MergeSort(v, 0, v.Length - 1);
        }


        private static void MergeSort(int[] v, int lo, int hi)
        {
            if (lo < hi)
            {
                int mid;
                mid = lo + (hi - lo) / 2;
                
                MergeSort(v, lo, mid);
                MergeSort(v, mid + 1, hi);

                int[] left = new int[mid - lo + 1];
                int i;
                for (i = lo; i <= mid; i++)
                {
                    left[i - lo] = v[i];
                }
                int[] right = new int[hi - mid];
                for (i = mid + 1; i <= hi; i++)
                {
                    right[i - (mid + 1)] = v[i];
                }

                int j = 0, k = lo;
                i = 0;
                while (i < left.Length && j < right.Length)
                {
                    if (left[i] < right[j])
                        v[k++] = left[i++];
                    else
                        v[k++] = right[j++];
                }
                while (i < left.Length)
                {
                    v[k++] = left[i++];
                }
                while (j < right.Length)
                {
                    v[k++] = right[j++];
                }
            }
        }

        public static void DoublingTest()
        {
            Stopwatch sw = new Stopwatch();
            int[] v;
            for(int N = 1000; N < int.MaxValue / 2; N *=2)
            {
                v = P15.Program.InitArray(N, 100000);
                sw.Restart();
                MergeSort(v);
                sw.Stop();
                Console.WriteLine($"N = {N} -->> {sw.ElapsedMilliseconds}");
            }
        }
        /// <summary>
        /// for i = 2:n,
        ///    for (k = i; k > 1 and a[k] < a[k - 1]; k--)
        ///        swap a[k, k - 1]
        ///    → invariant: a[1..i] is sorted
        /// end
        /// </summary>
        /// <param name="v"></param>
        /// <exception cref="NotImplementedException"></exception>
        private static void InsertionSort(int[] v)
        {
            int aux;
            for (int i = 1; i < v.Length; i++)
            {
                for (int k = i; k > 0 && v[k] < v[k - 1]; k--)
                {
                    aux = v[k]; v[k] = v[k - 1]; v[k - 1] = aux;
                }
            }
        }

        /// <summary>
        /// for i = 1:n,
        ///    swapped = false
        ///    for j = n:i+1,
        ///        if a[j] < a[j - 1],
        ///            swap a[j, j - 1]
        ///            swapped = true
        ///    → invariant: a[1..i] in final position
        ///    break if not swapped
        /// end
        /// </summary>
        /// <param name="v"></param>
        /// <exception cref="NotImplementedException"></exception>
        private static void BubbleSort(int[] v)
        {
            bool swapped;
            int aux;
            for (int i = 0; i < v.Length; i++)
            {
                swapped = false;
                for (int j  = v.Length - 1; j > i; j--)
                {
                    if (v[j] < v[j - 1])
                    {
                        aux = v[j]; v[j] = v[j - 1]; v[j - 1] = aux;
                        swapped = true;
                    }
                }
                if (!swapped)
                    break;
            }
        }

        /// <summary>
        /// for i = 1:n,
        ///        k = i
        ///    for j = i+1:n, if a[j] < a[k], k = j
        ///    → invariant: a[k] smallest of a[i..n]
        ///    swap a[i, k]
        ///    → invariant: a[1..i] in final position
        /// end
        /// </summary>
        /// <param name="v"></param>
        /// <exception cref="NotImplementedException"></exception>
        private static void SelectionSort(int[] v)
        {
            int k, aux;
            for (int i = 0; i < v.Length; i++)
            {
                k = i;
                for (int j = i + 1; j < v.Length; j++)
                {
                    if (v[j] < v[k])
                        k = j;
                }
                aux = v[i]; v[i] = v[k]; v[k] = aux;
                //(v[i], v[k]) = (v[k], v[i]);
            }
        }
    }
}
