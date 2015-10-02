using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassicAlgorightms.Digraphs
{
    public class Digraph
    {
        private Int32 versus;
        private int edges;
        private List<int>[] adj;

        public Digraph(int v)
        {
            this.versus = v;
            this.edges = 0;

            adj = new List<int>[v];
            for (int i = 0; i < versus; i++)
            {
                adj[i] = new List<int>();
            }
        }

        public Digraph(int versus, int edges, string[] text) : this(versus)
        {
            int _edges = edges;
            foreach (string s in text)
            {
                string[] vals = s.Split(' ');
                int v = int.Parse(vals[0]);
                int w = int.Parse(vals[1]);

                AddEdge(v, w);
            }
        }

        public int V()
        {
            return versus;
        }

        public int E()
        {
            return edges;
        }

        public void AddEdge(int v, int w)
        {
            adj[v].Add(w);
            edges++;
        }

        public IEnumerable<int> Adj(int v)
        {
            return adj[v];
        }

        public Digraph Reverse()
        {
            Digraph r = new Digraph(versus);
            for (int v = 0; v < V(); v++)
            {
                foreach (int w in Adj(v))
                {
                    r.AddEdge(w, v);
                }
            }

            return r;
        }
    }
}
