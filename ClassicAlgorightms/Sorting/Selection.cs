using System;

namespace ClassicAlgorightms.Sorting
{
    public class Selection : Sorting
    {
        public override void Sort(IComparable[] a)
        {
            for (int i = 0; i < a.Length; i++)
            {
                int min = i;
                for (int j = i + 1; j < a.Length; j++)
                {
                    if (a[j].CompareTo(a[min]) == -1)
                    {
                        min = j;
                    }
                }

                if (less(a[min], a[i]))
                {
                    exch(a, i, min);
                }
            }
        }
    }
}
