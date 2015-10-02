using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassicAlgorightms.Mods
{
    public class EdgeWeightedGraph
    {
        private List<Edge>[] adj;

        public EdgeWeightedGraph(int v)
        {
            this.V = v;
            this.E = 0;
            this.adj = new List<Edge>[v];

            for (int i = 0; i < v; i++)
            {
                adj[i] = new List<Edge>();
            }
        }

        public EdgeWeightedGraph(int v, int e, string[] graphItems) : this(v)
        {
            foreach (string graphItem in graphItems)
            {
                string[] items = graphItem.Split(' ');
                int v_ = int.Parse(items[0]);
                int w = int.Parse(items[1]);
                double weight = Double.Parse(items[2].Replace(".", ","));
                AddEdge(new Edge(v_, w, weight));
            }
        }

        public int V { get; }

        public int E { get; set; }

        public void AddEdge(Edge e)
        {
            int v = e.Either, w = e.Other(v);
            adj[v].Add(e);
            adj[w].Add(e);
            E++;
        }

        public IEnumerable<Edge> Adj(int v)
        {
            return adj[v];
        }

        public IEnumerable<Edge> Edges()
        {
            var list = new List<Edge>();
            for (int v = 0; v < V; v++)
            {
                foreach (Edge edge in Adj(v))
                {
                    if (edge.Other(v) > v) list.Add(edge);
                }
            }

            return list;
        }
    }
}
