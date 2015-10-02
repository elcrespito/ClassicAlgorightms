using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.CSharp.RuntimeBinder;

namespace ClassicAlgorightms.Mods
{
    public class Edge : IComparable<Edge>
    {
        private int w;
        private int v;

        public Edge(int v, int w, double weight)
        {
            this.v = v;
            this.w = w;
            this.Weight = weight;
        }

        public double Weight { get; }

        public int Either => v;

        public int Other(int vertex)
        {
            if (vertex == v) return w;
            else if (vertex == w) return v;
            throw new RuntimeBinderException("Недопустимое ребро");
        }

        public int CompareTo(Edge that)
        {
            if (this.Weight < that.Weight) return -1;
            else if (this.Weight > that.Weight) return 1;
            return 0;
        }

        public override string ToString()
        {
            return $"{Either}-{w} {Weight}";
        }
    }
}
