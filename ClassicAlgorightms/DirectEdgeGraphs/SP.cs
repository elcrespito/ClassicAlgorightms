using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassicAlgorightms.DirectEdgeGraphs
{
    public abstract class SP
    {
        public SP(EdgeWeightedDigrap graph, int s)
        {

        }

        public abstract double DistTo(int v);

        public abstract bool HasPathTo(int v);

        public abstract IEnumerable<DirectedEdge> PathTo(int v);
    }
}
