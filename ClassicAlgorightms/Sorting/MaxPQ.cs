﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassicAlgorightms.Sorting
{
    public class MaxPQ<Key> where Key : class, IComparable
    {
        private Key[] pq;
        private int N = 0;

        public MaxPQ(int maxN)
        {
            pq = (Key[])new IComparable[maxN + 1];
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

        private void sink(int k)
        {
            while (2 * k <= N)
            {
                int j = 2 * k;
                if (j < N && less(j, j + 1)) j++;
                if (!less(k, j)) break;
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
            while (k > 1 && less(k / 2, k))
            {
                exch(k / 2, k);
                k = k / 2;
            }
        }
    }
}
