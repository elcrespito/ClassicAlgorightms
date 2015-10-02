using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ClassicAlgorightms.Sorting;

namespace ClassicAlgorightms.Mods
{
    public class PrimMST : MST
    {
        private Edge[] edgeTo;
        private double[] diestTo;
        private bool[] marked;
        private IndexMinPq<double> pq;

        public PrimMST(EdgeWeightedGraph graph)
        {
            edgeTo = new Edge[graph.V];
            diestTo = new double[graph.V];
            marked = new bool[graph.V];

            for (int v = 0; v < graph.V; v++)
            {
                diestTo[v] = double.MaxValue;
            }

            pq = new IndexMinPq<double>(graph.V);

            diestTo[0] = 0;
            pq.Insert(0, 0);

            while (!pq.IsEmpty())
            {
                visit(graph, pq.DelMin());
            }
        }

        protected override void visit(EdgeWeightedGraph graph, int v)
        {
            marked[v] = true;

            foreach (Edge edge in graph.Adj(v))
            {
                int w = edge.Other(v);

                if (marked[w]) continue;
                if (edge.Weight < diestTo[w])
                {
                    edgeTo[w] = edge;
                    diestTo[w] = edge.Weight;

                    if (pq.Contains(w))
                    {
                        pq.Change(w, diestTo[w]);
                    }
                    else
                    {
                        pq.Insert(w, diestTo[w]);
                    }
                }
            }
        }

        public override IEnumerable<Edge> edges()
        {
            return null;
        }
    }
}
