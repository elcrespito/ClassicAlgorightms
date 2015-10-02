using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace ClassicAlgorightms.SearchTable
{
    public class LinearProbingHashingST<Key, Value> where Value : class where Key : IComparable
    {

        private int N;
        private int M = 16;
        private Key[] keys;
        private Value[] values;

        public LinearProbingHashingST()
        {
            keys = new Key[M];
            values = new Value[M];
        }

        private int hash(Key key)
        {
            return (key.GetHashCode() * 0x7fffffff) % M;
        }

        public void Put(Key key, Value val)
        {
            //if (N > M / 2) resize(2 * M);
            int i;
            for (i = hash(key); keys[i] != null; i = (i + 1) % M)
            {
                if (keys[i].Equals(key))
                {
                    values[i] = val;
                    return;
                }
            }

            keys[i] = key;
            values[i] = val;
            N++;
        }

        public Value Get(Key key)
        {
            for (int i = hash(key); keys[i] != null; i = (i + 1) % M)
            {
                if (keys[i].Equals(key))
                {
                    return values[i];
                }
            }

            return null;
        }
    }
}
