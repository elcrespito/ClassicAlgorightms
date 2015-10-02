using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassicAlgorightms.Sorting
{
    public class MinPQ<Key> where Key : class , IComparable<Key>
    {
        private Key[] pq;
        private int N = 0;

        public MinPQ() : this(1)
        {

        }

        public MinPQ(int maxN)
        {
            pq = new Key[maxN + 1];
        }

        public bool isEmpty()
        {
            return N == 0;
        }

        public int size()
        {
            return N;
        }

        public void insert(Key v)
        {
            if (N == pq.Length - 1) Resize(2 * pq.Length);

            pq[++N] = v;
            swim(N);
        }

        public Key delMax()
        {
            Key max = pq[1];
            exch(1, N--);
            pq[N + 1] = null;
            sink(1);
            return max;
        }

        public Key delMin()
        {
            if (isEmpty()) throw new Exception("Priority queue underflow");
            exch(1, N);
            Key min = pq[N--];
            sink(1);
            pq[N + 1] = null;         // avoid loitering and help with garbage collection
            if ((N > 0) && (N == (pq.Length - 1) / 4)) Resize(pq.Length / 2);
            return min;
        }

        private void sink(int k)
        {
            while (2 * k <= N)
            {
                int j = 2 * k;
                if (j < N && Greater(j, j + 1)) j++;
                if (!Greater(k, j)) break;
                exch(k, j);
                k = j;
            }
        }

        private void exch(int i, int j)
        {
            Key t = pq[i];
            pq[i] = pq[j];
            pq[j] = t;
        }

        private bool less(int i, int j)
        {
            return pq[i].CompareTo(pq[j]) < 0;
        }

        private void swim(int k)
        {
            while (k > 1 && Greater(k / 2, k))
            {
                exch(k, k / 2);
                k = k / 2;
            }
        }

        private void Resize(int capacity)
        {
            Key[] temp = new Key[capacity];
            for (int i = 1; i <= N; i++)
            {
                temp[i] = pq[i];
            }
            pq = temp;
        }

        private bool Greater(int i, int j)
        {
            return pq[i].CompareTo(pq[j]) > 0;
        }
    }
}