using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassicAlgorightms.Sorting
{
    public class ShellInArray : Sorting
    {
        public override void Sort(IComparable[] a)
        {
            int n = a.Length;
            int h = 1;
            int arrayLength = 1;

            while (h < n / 3)
            {
                h = h * 3 + 1;
                arrayLength++;
            }

            int[] hmas = new int[arrayLength--];
            hmas[arrayLength--] = h;
            h = h / 3;
            while (h >= 1)
            {
                hmas[arrayLength--] = h;
                h = h / 3;
            }

            for (int k = hmas.Length - 1; k >= 0; k--)
            {
                for (int i = hmas[k]; i < n; i++)
                {
                    for (int j = i; j > 0 && less(a[j], a[j - 1]); j -= h)
                    {
                        exch(a, j, j - 1);
                    }
                }
            }
        }
    }
}