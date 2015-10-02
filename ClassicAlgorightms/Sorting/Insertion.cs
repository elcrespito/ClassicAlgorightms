using System;

namespace ClassicAlgorightms.Sorting
{
    public class Insertion : Sorting
    {
        public override void Sort(IComparable[] a)
        {
            for (int i = 1; i < a.Length; i++)
            {
                for (int j = i; j > 0 && less(a[j], a[j - 1]); j--)
                {
                    exch(a, j, j - 1);
                }
            }
        }
    }
}
