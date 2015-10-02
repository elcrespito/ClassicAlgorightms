using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassicAlgorightms.DirectEdgeGraphs
{
    public class DirectedEdge
    {
        public DirectedEdge(int v, int w, double weight)
        {
            this.From = v;
            this.To = w;
            this.Weight = weight;
        }

        public double Weight { get; }

        public int From { get; }

        public int To { get; }

        public new string ToString()
        {
            return string.Format("{0}->{1} {2}", From, To, Weight);
        }
    }
}
