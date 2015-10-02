using System;

namespace ClassicAlgorightms.Sorting
{
    public class HeapSorting
    {
        public void sort(IComparable[] a)
        {
            int N = a.Length - 1;
            for (int k = N / 2; k >= 1; k--)
            {
                sink(a, k, N);
            }

            while (N > 1)
            {
                exch(a, 1, N--);
                sink(a, 1, N);
            }
        }

        private void exch(IComparable[] a, int i, int j)
        {
            IComparable t = a[i];
            a[i] = a[j];
            a[j] = t;
        }

        private void sink(IComparable[] a, int k, int N)
        {
            while (k * 2 <= N)
            {
                int j = k * 2;
                if (j < N && less(a, j, j + 1)) j++;
                if (!less(a, k, j)) break;
                exch(a, k, j);
                k = j;
            }
        }

        private bool less(IComparable[] a, int j, int k)
        {
            return a[j].CompareTo(a[k]) < 0;
        }

        public bool isSorted(IComparable[] a)
        {
            for (int i = 1; i < a.Length; i++)
            {
                if (less(a, i, i - 1)) return false;
            }

            return true;
        }
    }
}