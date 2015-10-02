using System;
using System.Collections.Generic;
using System.Linq;
using ClassicAlgorightms.TableNames;

namespace ClassicAlgorightms.SearchTable
{
    public class BinarySearchST<Key, Value> : ST<Key, Value> where Key : class, IComparable where Value : class
    {
        private Key[] keys;
        private Value[] vals;
        private int N;

        public BinarySearchST(int capacity)
        {
            keys = (Key[])new IComparable[capacity];
            vals = new Value[capacity];
        }

        public override void Put(Key key, Value value)
        {
            int i = Rank(key);
            if (i < N && keys[i].CompareTo(key) == 0)
            {
                vals[i] = value;
                return;
            }

            for (int j = N; j > i; j--)
            {
                keys[j] = keys[j - 1];
                vals[j] = vals[j - 1];
            }

            keys[i] = key;
            vals[i] = value;
            N++;
        }

        public override Value Get(Key key)
        {
            if (IsEmpty()) return null;

            int i = Rank(key);
            if (i < N && keys[i].CompareTo(key) == 0)
                return vals[i];

            return null;

        }

        public override void Delete(Key key)
        {
            throw new NotImplementedException();
        }

        public override bool Contains(Key key)
        {
            return Get(key) != null;
        }

        public override bool IsEmpty()
        {
            return !keys.Any();
        }

        public override int Size()
        {
            return N;
        }

        public override Key Min()
        {
            return keys[0];
        }

        public override Key Max()
        {
            return keys[N - 1];
        }

        public override Key Floor(Key key)
        {
            throw new NotImplementedException();
        }

        public override Key Ceiling(Key key)
        {
            int i = Rank(key);
            return keys[i];
        }

        public override int Rank(Key key)
        {
            int lo = 0, hi = N - 1;

            while (lo <= hi)
            {
                int mid = lo + (hi - lo) / 2;

                int cmp = key.CompareTo(vals[mid]);
                if (cmp < 0)
                {
                    hi = mid - 1;
                }
                else if (cmp > 0)
                {
                    lo = mid + 1;
                }
                else
                {
                    return mid;
                }
            }

            return lo;
        }

        public override Key Select(int k)
        {
            return keys[k];
        }

        public override IEnumerable<Key> Keys(Key lo, Key hi)
        {
            Queue<Key> q = new Queue<Key>();

            for (int i = Rank(lo); i <= Rank(hi); i++)
            {
                q.Enqueue(keys[i]);
            }

            if (Contains(hi))
            {
                q.Enqueue(keys[Rank(hi)]);
            }

            return q;
        }
    }
}
