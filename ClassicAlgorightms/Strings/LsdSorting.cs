using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassicAlgorightms.Strings
{
    public static class LsdSorting
    {
        public static void Sort(string[] array, int N)
        {
            int R = 256;
            string[] aux = new string[array.Length];

            for (int d = N - 1; d >= 0; d--)
            {
                int[] count = new int[R + 1];

                for (int i = 0; i < array.Length; i++)
                {
                    count[array[i][d] + 1]++;
                }

                for (int r = 0; r < R; r++)
                {
                    count[r + 1] += count[r];
                }

                for (int i = 0; i < array.Length; i++)
                {
                    aux[count[array[i][d]]++] = array[i];
                }

                for (int i = 0; i < array.Length; i++)
                {
                    array[i] = aux[i];
                }
            }
        }
    }
}
