using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ClassicAlgorightms.Sorting;

namespace ClassicAlgorightms.Mods
{
    public class LazyPrimMST : MST
    {
        public LazyPrimMST(EdgeWeightedGraph graph)
        {
            pq = new MinPQ<Edge>();
            marked = new bool[graph.V];
            mst = new Queue<Edge>();

            visit(graph, 0);

            while (!pq.isEmpty())
            {
                Edge e = pq.delMin();

                int v = e.Either, w = e.Other(v);

                if (marked[v] && marked[w]) continue;
                mst.Enqueue(e);
                if (!marked[v]) visit(graph, v);
                if (!marked[w]) visit(graph, w);
            }
        }
        protected override void visit(EdgeWeightedGraph graph, int v)
        {
            marked[v] = true;

            foreach (Edge edge in graph.Adj(v))
            {
                if (!marked[edge.Other(v)]) pq.insert(edge);
            }
        }
    }
}
