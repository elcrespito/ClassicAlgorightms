using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassicAlgorightms.DirectEdgeGraphs
{
    public class EdgeWeightedDigrap
    {
        public int V { get; }

        public int E { get; set; }

        private List<DirectedEdge>[] adj;

        public EdgeWeightedDigrap(int v)
        {
            V = v;
            E = 0;
            adj = new List<DirectedEdge>[v];

            for (int i = 0; i < V; i++)
            {
                adj[i] = new List<DirectedEdge>();
            }
        }

        public EdgeWeightedDigrap(int v, string[] graphItems) : this(v)
        {
            foreach (string graphItem in graphItems)
            {
                string[] items = graphItem.Split(' ');
                int v_ = int.Parse(items[0]);
                int w = int.Parse(items[1]);
                double weight = Double.Parse(items[2].Replace(".", ","));
                AddEdge(new DirectedEdge(v_, w, weight));
            }
        }

        public void AddEdge(DirectedEdge edge)
        {
            adj[edge.From].Add(edge);
            E++;
        }

        public IEnumerable<DirectedEdge> Adj(int v)
        {
            return adj[v];
        }

        public IEnumerable<DirectedEdge> Edges()
        {
            for (int v = 0; v < V; v++)
            {
                foreach (DirectedEdge directedEdge in adj[v])
                {
                    yield return directedEdge;
                }
            }
        }
    }
}
