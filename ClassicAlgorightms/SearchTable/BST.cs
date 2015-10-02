using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ClassicAlgorightms.TableNames;

namespace ClassicAlgorightms.SearchTable
{
    public class BST<Key, Value> : ST<Key, Value> where Key : class, IComparable where Value : class
    {
        private Node root;
        private class Node
        {
            public Key key;
            public Value val;
            public Node left, right;
            public int N;

            public Node(Key key, Value val, int n)
            {
                this.key = key;
                this.val = val;
                N = n;
            }
        }

        public override void Put(Key key, Value value)
        {
            root = Put(root, key, value);
        }

        private Node Put(Node x, Key key, Value value)
        {
            if (x == null) return new Node(key, value, 1);

            int cmp = key.CompareTo(x.key);

            if (cmp < 0)
                x.left = Put(x.left, key, value);
            else if (cmp > 0)
                x.right = Put(x.right, key, value);
            else x.val = value;

            x.N = Size(x.left) + Size(x.right) + 1;
            return x;
        }

        public override Value Get(Key key)
        {
            return Get(root, key);
        }

        private Value Get(Node x, Key key)
        {
            if (x == null) return null;

            int comp = key.CompareTo(x.key);
            if (comp < 0)
            {
                return Get(x.left, key);
            }
            else if (comp > 0)
            {
                return Get(x.right, key);
            }

            return x.val;
        }

        public override void Delete(Key key)
        {
            root = Delete(root, key);
        }

        private Node Delete(Node x, Key key)
        {
            if (x == null) return null;

            int cmp = key.CompareTo(x.key);

            if (cmp < 0) x.left = Delete(x.left, key);
            if (cmp > 0) x.right = Delete(x.right, key);
            else
            {
                if (x.right == null) return x.left;
                if (x.left == null) return x.right;
                Node t = x;
                x = Min(t.right);
                x.right = DeleteMin(t.right);
                x.left = t.left;
            }

            x.N = Size(x.left) + Size(x.right) + 1;
            return x;
        }

        public override bool Contains(Key key)
        {
            return Get(key) != null;
        }

        public override bool IsEmpty()
        {
            throw new NotImplementedException();
        }

        public override int Size()
        {
            return Size(root);
        }

        private int Size(Node x)
        {
            if (x == null) return 0;

            return x.N;
        }

        public override Key Min()
        {
            return Min(root).key;
        }

        private Node Min(Node x)
        {
            if (x.left == null) return x;

            return Min(x.left);
        }

        public override Key Max()
        {
            return Max(root).key;
        }

        private Node Max(Node x)
        {
            if (x.right == null) return x;

            return Max(x.right);
        }

        public override Key Floor(Key key)
        {
            Node x = Floor(root, key);
            if (x == null) return null;
            return x.key;
        }

        private Node Floor(Node x, Key key)
        {
            if (x == null) return null;

            int cmp = key.CompareTo(x.key);
            if (cmp == 0) return x;
            if (cmp < 0) return Floor(x.left, key);

            Node t = Floor(x.right, key);
            if (t != null) return t;
            else return x;
        }

        public override Key Ceiling(Key key)
        {
            Node x = Ceiling(root, key);
            if (x == null) return null;
            return x.key;
        }

        private Node Ceiling(Node x, Key key)
        {
            if (x == null) return null;

            int cmp = key.CompareTo(x.key);
            if (cmp == 0) return x;
            if (cmp > 0) return Floor(x.right, key);

            Node t = Floor(x.left, key);
            if (t != null) return t;
            else return x;
        }

        public override int Rank(Key key)
        {
            return Rank(key, root);
        }

        private int Rank(Key key, Node x)
        {
            if (x == null) return 0;

            int cmp = key.CompareTo(x.key);

            if (cmp < 0) return Rank(key, x.left);
            else if (cmp > 0) return 1 + Size(x.left) + Rank(key, x.right);
            else return Size(x.left);
        }

        public override Key Select(int k)
        {
            return Select(root, k).key;
        }

        private Node Select(Node x, int k)
        {
            if (x == null) return null;

            int t = Size(x.left);
            if (t > k) return Select(x.left, k);
            else if (t < k) return Select(x.right, k - t - 1);
            else return x;
        }

        public override IEnumerable<Key> Keys(Key lo, Key hi)
        {
            Queue<Key> queue = new Queue<Key>();
            Keys(root, queue, lo, hi);
            return queue;
        }

        public new IEnumerable<Key> Keys()
        {
            return Keys(Min(), Max());
        }

        private void Keys(Node x, Queue<Key> queue, Key lo, Key hi)
        {
            if (x == null) return;

            int cmplo = lo.CompareTo(x.key);
            int cmphi = hi.CompareTo(x.key);

            if (cmplo < 0) Keys(x.left, queue, lo, hi);
            if (cmplo <= 0 && cmphi >= 0) queue.Enqueue(x.key);
            if (cmphi > 0) Keys(x.right, queue, lo, hi);
        }

        public new void DeleteMin()
        {
            root = DeleteMin(root);
        }

        private Node DeleteMin(Node x)
        {
            if (x.left == null) return x.right;

            x.left = DeleteMin(x.left);
            x.N = Size(x.left) + Size(x.right) + 1;
            return x;
        }
    }
}
