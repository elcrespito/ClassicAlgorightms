using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ClassicAlgorightms.Sorting;

namespace ClassicAlgorightms.Mods
{
    public abstract class MST
    {
        protected bool[] marked;
        protected Queue<Edge> mst;
        protected MinPQ<Edge> pq;

        protected abstract void visit(EdgeWeightedGraph graph, int v);

        public virtual IEnumerable<Edge> edges()
        {
            return mst;
        }

        public virtual double Weight
        {
            get
            {
                return mst.Sum(edge => edge.Weight);
            }
        }
    }
}
