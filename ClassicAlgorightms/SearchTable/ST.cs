using System;
using System.Collections.Generic;

namespace ClassicAlgorightms.TableNames
{
    public abstract class ST<Key, Value> where Key : class, IComparable
    {
        public abstract void Put(Key key, Value value);

        public abstract Value Get(Key key);

        public abstract void Delete(Key key);

        public abstract bool Contains(Key key);

        public abstract bool IsEmpty();

        public abstract int Size();

        public abstract Key Min();

        public abstract Key Max();

        public abstract Key Floor(Key key);

        public abstract Key Ceiling(Key key);

        public abstract int Rank(Key key);

        public abstract Key Select(int k);

        public virtual void DeleteMin()
        {
            Delete(Min());
        }

        public void DeleteMax()
        {
            Delete(Max());
        }

        public int Size(Key lo, Key hi)
        {
            if (hi.CompareTo(lo) < 0)
                return 0;
            else if (Contains(hi))
                return Rank(hi) - Rank(lo) + 1;
            else
                return Rank(hi) - Rank(lo);
        }

        public abstract IEnumerable<Key> Keys(Key lo, Key hi);

        public IEnumerable<Key> Keys()
        {
            return Keys(Min(), Max());
        }
    }
}
