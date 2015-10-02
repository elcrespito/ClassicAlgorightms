using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ClassicAlgorightms.Sorting;

namespace ClassicAlgorightms.DirectEdgeGraphs
{
    public class DijkstraSP
    {
        private double[] distTo;
        private DirectedEdge[] edgeTo;
        private IndexMinPq<double> minPq;

        public DijkstraSP(EdgeWeightedDigrap graph, int s)
        {
            distTo = new double[graph.V];
            edgeTo = new DirectedEdge[graph.V];
            minPq = new IndexMinPq<double>(graph.V);

            for (int i = 0; i < graph.V; i++)
            {
                distTo[i] = Double.MaxValue;
            }

            distTo[s] = 0;

            minPq.Insert(0, 0);
            while (!minPq.IsEmpty())
            {
                Visit(graph, minPq.DelMin());
            }
        }

        private void Visit(EdgeWeightedDigrap graph, int v)
        {
            foreach (DirectedEdge edge in graph.Adj(v))
            {
                int w = edge.To;

                if (distTo[w] > distTo[v] + edge.Weight)
                {
                    edgeTo[w] = edge;
                    distTo[w] = distTo[v] + edge.Weight;

                    if (minPq.Contains(w))
                    {
                        minPq.Change(w, distTo[w]);
                    }
                    else
                    {
                        minPq.Insert(w, distTo[w]);
                    }
                }
            }
        }


        public double DistTo(int v)
        {
            return distTo[v];
        }

        public bool HasPathTo(int v)
        {
            return distTo[v] < double.MaxValue;
        }

        public IEnumerable<DirectedEdge> PathTo(int v)
        {
            if (!HasPathTo(v)) return null;
            var edges = new Stack<DirectedEdge>();
            for (DirectedEdge edge = edgeTo[v]; edge != null; edge = edgeTo[edge.From])
            {
                edges.Push(edge);
            }

            return edges;
        }
    }
}
