using System;

namespace ClassicAlgorightms.Sorting
{
    public class MergeSorting : Sorting
    {
        public IComparable[] aux;

        public override void Sort(IComparable[] a)
        {
            aux = new IComparable[a.Length];
            Sort(a, 0, a.Length - 1);
        }

        public void Sort(IComparable[] a, int lo, int high)
        {
            if (high <= lo)
            {
                return;
            }

            int mid = lo + (high - lo) / 2;
            Sort(a, lo, mid);
            Sort(a, mid + 1, high);
            Merge(a, lo, mid, high);
        }


        protected void Merge(IComparable[] a, int lo, int mid, int hi)
        {
            int i = lo, j = mid + 1;

            for (int k = lo; k <= hi; k++)
            {
                aux[k] = a[k];
            }

            for (int k = lo; k <= hi; k++)
            {
                if (i > mid)
                {
                    a[k] = aux[j++];
                }
                else if (j > hi)
                {
                    a[k] = aux[i++];
                }
                else if (less(aux[j], aux[i]))
                {
                    a[k] = aux[j++];
                }
                else
                {
                    a[k] = aux[i++];
                }
            }
        }
    }
}
