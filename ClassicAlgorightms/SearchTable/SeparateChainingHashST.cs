using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassicAlgorightms.SearchTable
{
    public class SeparateChainingHashST<Key, Value> where Key : class, IComparable where Value : class
    {
        private int N;
        private int M;

        private BST<Key, Value>[] st;

        public SeparateChainingHashST() : this(997)
        {
        }

        public SeparateChainingHashST(int m)
        {
            M = m;
            this.st = new BST<Key, Value>[M];

            for (int i = 0; i < M; i++)
            {
                st[i] = new BST<Key, Value>();
            }
        }

        private int Hash(Key key)
        {
            return (key.GetHashCode() & 0x7fffffff) % M;
        }

        public Value Get(Key key)
        {
            return st[Hash(key)].Get(key);
        }

        public void Put(Key key, Value val)
        {
            st[Hash(key)].Put(key, val);
        }
    }
}
