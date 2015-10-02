using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassicAlgorightms.Sorting
{
    public class IndexMinPq<Key> where Key : struct, IComparable<Key>
    {
        private int maxN;        // maximum number of elements on PQ
        private int N;           // number of elements on PQ
        private int[] pq;        // binary heap using 1-based indexing
        private int[] qp;        // inverse of pq - qp[pq[i]] = pq[qp[i]] = i
        private Key[] keys;      // keys[i] = priority of i

        public IndexMinPq(int maxN)
        {
            this.maxN = maxN;
            keys = new Key[maxN + 1];    // make this of length maxN??
            pq = new int[maxN + 1];
            qp = new int[maxN + 1];                   // make this of length maxN??
            for (int i = 0; i <= maxN; i++)
                qp[i] = -1;
        }

        public void Insert(int i, Key key)
        {
            N++;
            qp[i] = N;
            pq[N] = i;
            keys[i] = key;
            swim(N);
        }

        public bool IsEmpty()
        {
            return N == 0;
        }

        public int DelMin()
        {
            int min = pq[1];
            Exch(1, N--);
            sink(1);
            qp[min] = -1;            // delete
            pq[N + 1] = -1;            // not needed
            return min;
        }

        public bool Contains(int i)
        {
            return qp[i] != -1;
        }

        public void Change(int i, Key key)
        {
            ChangeKey(i, key);
        }

        private void ChangeKey(int i, Key key)
        {
            keys[i] = key;
            swim(qp[i]);
            sink(qp[i]);
        }

        private void swim(int k)
        {
            while (k > 1 && Greater(k / 2, k))
            {
                Exch(k, k / 2);
                k = k / 2;
            }
        }

        private void sink(int k)
        {
            while (2 * k <= N)
            {
                int j = 2 * k;
                if (j < N && Greater(j, j + 1)) j++;
                if (!Greater(k, j)) break;
                Exch(k, j);
                k = j;
            }
        }

        private bool Greater(int i, int j)
        {
            return keys[pq[i]].CompareTo(keys[pq[j]]) > 0;
        }

        private void Exch(int i, int j)
        {
            int swap = pq[i];
            pq[i] = pq[j];
            pq[j] = swap;
            qp[pq[i]] = i;
            qp[pq[j]] = j;
        }

        public IEnumerable<Key> GetAll()
        {
            for (int i = 1; i < N; i++)
            {
                yield return keys[i];
            }
        }
    }
}
