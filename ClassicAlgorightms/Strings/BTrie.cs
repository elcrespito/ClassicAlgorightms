using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassicAlgorightms.Strings
{
    public class BTrie
    {
        private static int R = 256;
        private Node root;

        public class Node
        {
            public string Value;
            public Node[] next = new Node[R];
        }
        public BTrie()
        {

        }

        public string Get(string key)
        {
            Node x = Get(root, key, 0);
            if (x == null) return null;
            return x.Value;
        }

        private Node Get(Node x, string key, int d)
        {
            if (x == null) return null;
            if (key.Length == d) return x;
            char c = key[d];
            return Get(x.next[c], key, d + 1);
        }

        public void Put(string key, string value)
        {
            root = Put(root, key, value, 0);
        }

        private Node Put(Node x, string key, string value, int d)
        {
            if (x == null) x = new Node();
            if (d == key.Length)
            {
                x.Value = value;
                return x;
            }

            char c = key[d];
            x.next[c] = Put(x.next[c], key, value, d + 1);
            return x;
        }

        public void Delete(string key)
        {
            root = Delete(root, key, 0);
        }

        private Node Delete(Node x, string key, int d)
        {
            if (x == null) return null;

            if (d == key.Length)
            {
                x.Value = null;
            }
            else
            {
                char c = key[d];
                x.next[c] = Delete(x.next[c], key, d + 1);
            }

            if (x.Value != null) return x;

            for (char c = '0'; c < R; c++)
            {
                if (x.next[c] != null) return x;
            }

            return null;
        }

        public bool Contains(string key)
        {
            return true;
        }

        public bool IsEmpty()
        {
            return false;
        }

        public string LongestPrefixIs(string s)
        {
            int length = Search(root, s, 0, 0);
            return s.Substring(0, length);
        }

        private int Search(Node x, string s, int d, int length)
        {
            if (x == null) return length;
            if (x.Value != null) length = d;
            if (d == s.Length) return length;
            char c = s[d];
            return Search(x.next[c], s, d + 1, length);
        }

        public IEnumerable<string> KeysWithPrefix(string pre)
        {
            var q = new Queue<string>();
            Collect(Get(root, pre, 0), pre, q);
            return q;
        }

        private void Collect(Node x, string pre, Queue<string> q)
        {
            if (x == null) return;
            if (x.Value != null) q.Enqueue(pre);

            for (char c = '0'; c < R; c++)
            {
                Collect(x.next[c], pre + c, q);
            }
        }

        public IEnumerable<string> KeysThatMatch(string pat)
        {
            var q = new Queue<string>();
            Collect(root, string.Empty, pat, q);
            return q;
        }

        public void Collect(Node x, string pre, string pat, Queue<string> q)
        {
            int d = pre.Length;
            if (x == null) return;
            if (d == pat.Length && x.Value != null) q.Enqueue(pre);
            if (d == pat.Length) return;

            char next = pat[d];

            for (char c = '0'; c < R; c++)
            {
                if (next == '.' || next == c)
                {
                    Collect(x.next[c], pre + c, pat, q);
                }
            }
        }

        public int Size()
        {
            return 0;
        }

        public IEnumerable<string> Keys()
        {
            return KeysWithPrefix(string.Empty);
        }
    }
}
