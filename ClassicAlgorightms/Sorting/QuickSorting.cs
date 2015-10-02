using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassicAlgorightms.Sorting
{
    public class QuickSorting : Sorting
    {
        public void Sort(IComparable[] a, int lo, int high)
        {
            if (high <= lo)
            {
                return;
            }

            int j = Partition(a, lo, high);
            Sort(a, lo, j - 1);
            Sort(a, j + 1, high);
        }

        private int Partition(IComparable[] a, int lo, int high)
        {
            int i = lo, j = high + 1;
            IComparable v = a[lo];

            while (true)
            {
                while (less(a[++i], v))
                {
                    if (i == high) break;
                }

                while (less(v, a[--j]))
                {
                    if (j == lo) break;
                }

                if (i >= j)
                {
                    break;
                }

                exch(a, i, j);
            }

            exch(a, lo, j);
            return j;
        }



        public override void Sort(IComparable[] a)
        {
            Sort(a, 0, a.Length - 1);
        }
    }
}
