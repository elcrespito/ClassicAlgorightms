using System;
using System.Collections.Generic;

namespace ClassicAlgorightms.Graphs
{
    public class Graph
    {
        private int _versus;
        private int _edges;
        private List<Int32>[] adj;

        public Graph(int versus)
        {
            _versus = versus;
            adj = new List<int>[versus];

            for (int v = 0; v < _versus; v++)
            {
                adj[v] = new List<int>();
            }
        }

        public Graph(int versus, int edges, string[] text) : this(versus)
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
            return _versus;
        }

        public int E()
        {
            return _edges;
        }

        public void AddEdge(int v, int w)
        {
            adj[v].Add(w);
            adj[w].Add(v);
            _edges++;
        }

        public IEnumerable<int> Adj(int v)
        {
            return adj[v];
        }

        public static int Degree(Graph G, int v)
        {
            int degree = 0;

            foreach (int w in G.Adj(v)) degree++;
            return degree;
        }

        public static int MaxDegree(Graph g)
        {
            int max = 0;

            for (int v = 0; v < g.V(); v++)
            {
                if (Degree(g, v) > max)
                    max = Degree(g, v);
            }
            return max;
        }

        public static int AvgDegree(Graph g)
        {
            return 2 * g.E() / g.V();
        }

        public static int NumberOfSelfLoops(Graph g)
        {
            int count = 0;

            for (int v = 0; v < g.V(); v++)
            {
                foreach (int w in g.Adj(v))
                {
                    if (v == w) count++;
                }
            }
            return count / 2;
        }

        public override string ToString()
        {
            string s = V() + "Вершин, " + E() + " ребер\n";

            for (int v = 0; v < V(); v++)
            {
                s += v + ": ";

                foreach (int w in this.Adj(v))
                {
                    s += w + " ";
                }

                s += "\n";
            }

            return s;
        }
    }
}
