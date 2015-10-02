using System;

namespace ClassicAlgorightms.Sorting
{
    public class ShellSorting : Sorting
    {
        public override void Sort(IComparable[] a)
        {
            int n = a.Length;
            int h = 1;

            while (h < n / 3)
            {
                h = h * 3 + 1;
            }

            while (h >= 1)
            {
                for (int i = h; i < n; i++)
                {
                    for (int j = i; j > 0 && less(a[j], a[j - 1]); j -= h)
                    {
                        exch(a, j, j - 1);
                    }
                }
                h = h / 3;
            }
        }
    }
}
