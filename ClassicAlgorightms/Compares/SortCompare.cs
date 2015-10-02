using System;
using System.Diagnostics;
using System.Linq;
using ClassicAlgorightms.Sorting;

namespace ClassicAlgorightms.Compares
{
    public class SortCompare
    {
        public static double time(string alg, IComparable[] a)
        {
            Stopwatch timer = new Stopwatch();
            if (alg.Equals("Insertion"))
            {
                var sort = new Insertion();
                sort.Sort(a);
            }
            else
            {
                var sort = new Selection();
                sort.Sort(a);
            }

            return timer.ElapsedMilliseconds;
        }

        public static double timeRandomInput(String alg, int N, int T)
        {
            double total = 0.0;

            Double[] a = new double[N];

            var random = new Random();
            for (int t = 0; t < T; t++)
            {
                for (int i = 0; i < N; i++)
                {
                    a[i] = random.Next();

                    //total += time(alg, a);
                }
            }

            return total;
        }
    }
}
