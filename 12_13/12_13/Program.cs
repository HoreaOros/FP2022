using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace _12_13
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] v = { 3, 6, 2, 1, 5, 7, 2, 4, 1, 9 };
            int C = 10;
            //Console.WriteLine($"NF ==> {NF(v, C)}");

            //Console.WriteLine($"FF ==> {FF(v, C)}");

            //Console.WriteLine($"FF ==> {BF(v, C)}");

            // Console.WriteLine($"FF ==> {WF(v, C)}");


            Array.Sort(v, (a, b) => b.CompareTo(a));
            //Console.WriteLine($"NFD ==> {NF(v, C)}");
            //Console.WriteLine($"FFD ==> {FF(v, C)}");
            //Console.WriteLine($"BFD ==> {BF(v, C)}");
            Console.WriteLine($"WFD ==> {WF(v, C)}");
        }

        private static int WF(int[] v, int C)
        {
            int openedBins = 1;
            Console.WriteLine($"Open bin {openedBins}");
            if (v.Length == 0)
            {
                return 0;
            }
            int[] bins = new int[v.Length];

            for (int i = 0; i < v.Length; i++)
            {
                bool found = false;
                int maxim = 0;
                int indexMax = 0;
                for (int j = 0; j < openedBins; j++)
                {
                    if (v[i] + bins[j] <= C)
                    {
                        if (C - (v[i] + bins[j]) > maxim)
                        {
                            maxim = C - (v[i] + bins[j]);
                            indexMax = j;
                            found = true;
                        }
                    }
                }


                if (!found)
                {
                    bins[openedBins] = v[i];
                    openedBins++;
                    Console.WriteLine($"Open bin {openedBins}");
                    Console.WriteLine($"{v[i]} goes in bin {openedBins}");
                }
                else
                {
                    bins[indexMax] += v[i];
                    Console.WriteLine($"{v[i]} goes in bin {indexMax + 1}");
                }

            }

            return openedBins;
        }

        private static int BF(int[] v, int C)
        {
            int openedBins = 1;
            Console.WriteLine($"Open bin {openedBins}");
            if (v.Length == 0)
            {
                return 0;
            }
            int[] bins = new int[v.Length];

            for (int i = 0; i < v.Length; i++)
            {
                bool found = false;
                int minim = C;
                int indexMin=0;
                for (int j = 0; j < openedBins; j++)
                {
                    if (v[i] + bins[j] <= C)
                    {
                        if (C - (v[i] + bins[j]) < minim)
                        {
                            minim = C - (v[i] + bins[j]);
                            indexMin = j;
                            found = true;
                        }
                    }
                }


                if (!found)
                {
                    bins[openedBins] = v[i];
                    openedBins++;
                    Console.WriteLine($"Open bin {openedBins}");
                    Console.WriteLine($"{v[i]} goes in bin {openedBins}");
                }
                else
                {
                    bins[indexMin] += v[i];
                    Console.WriteLine($"{v[i]} goes in bin {indexMin + 1}");
                }

            }

            return openedBins;
        }

        private static int FF(int[] v, int C)
        {
            int openedBins = 1;
            Console.WriteLine($"Open bin {openedBins}");
            if (v.Length == 0)
            {
                return 0;
            }
            int[] bins = new int[v.Length];

            for (int i = 0; i < v.Length; i++)
            {
                bool inserted = false; ;
                for (int j = 0; j < openedBins; j++)
                {
                    if (bins[j] + v[i] <= C)
                    {
                        bins[j] += v[i];
                        Console.WriteLine($"{v[i]} goes in bin {j+1}");
                        inserted = true;
                        break;
                    }
                }
                if (!inserted)
                {
                    bins[openedBins] = v[i];
                    openedBins++;
                    Console.WriteLine($"Open bin {openedBins}");
                    Console.WriteLine($"{v[i]} goes in bin {openedBins}");
                }
                
            }

            return openedBins;
        }

        private static int NF(int[] v, int C)
        {
            int bins = 1;
            Console.WriteLine($"Open bin {bins}");
            int current_capacity = 0;
            if (v.Length == 0)
            {
                return 0;
            }
            for (int i = 0; i < v.Length; i++)
            {
                if (v[i] + current_capacity <= C)
                {
                    current_capacity += v[i];
                }
                else
                {
                    bins++;
                    Console.WriteLine($"Open bin {bins}");
                    current_capacity = v[i];
                }
                Console.WriteLine($"{v[i]} goes in bin {bins}");

            }



            return bins;
        }
    }
}
