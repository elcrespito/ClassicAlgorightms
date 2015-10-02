using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassicAlgorightms.Strings
{
    public class KMP
    {
        private string pat;
        private int[,] dfa;
        public KMP(string pat)
        {
            this.pat = pat;
            int m = pat.Length;
            int R = 256;
            dfa = new int[R, m];

            dfa[pat[0], 0] = 1;

            for (int x = 0, j = 1; j < m; j++)
            {
                for (int c = 0; c < R; c++)
                {
                    ////dfa[c, j] = dfa[c, x];
                }

                dfa[pat[j], j] = j + 1;
                x = dfa[pat[j], x];
            }
        }

        public int Search(string txt)
        {
            int i, j, N = txt.Length, M = pat.Length;

            for (i = 0, j = 0; i < N && j < M; i++)
            {
                j = dfa[txt[i], j];
            }

            if (j == M)
            {
                return i - M;
            }
            else
            {
                return N;
            }
        }
    }
}
