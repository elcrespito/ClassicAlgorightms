using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassicAlgorightms.Graphs
{
    public class DepthFirstPath
    {
        private bool[] marked;
        private int[] edgeTo;
        private int s;

        public DepthFirstPath(Graph g, int s)
        {
            marked = new bool[g.V()];
            edgeTo = new int[g.V()];
            this.s = s;
            dfs(g, s);
        }

        private void dfs(Graph graph, int v)
        {
            marked[v] = true;

            foreach (int w in graph.Adj(v))
            {
                if (!marked[w])
                {
                    edgeTo[w] = v;
                    dfs(graph, w);
                }
            }
        }

        public bool HasPathTo(int v)
        {
            return marked[v];
        }

        public IEnumerable<int> PathTo(int v)
        {
            if (!HasPathTo(v)) return null;

            Stack<int> path = new Stack<int>();

            for (int x = v; x != s; x = edgeTo[x])
            {
                path.Push(x);
            }

            path.Push(s);

            return path;
        }
    }
}
