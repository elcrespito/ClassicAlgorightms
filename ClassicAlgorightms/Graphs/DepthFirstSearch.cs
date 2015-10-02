using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassicAlgorightms.Graphs
{
    public class DepthFirstSearch
    {
        private bool[] marked;
        private int count;

        public DepthFirstSearch(Graph g, int s)
        {
            marked = new bool[g.V()];
            dfs(g, s);
        }

        private void dfs(Graph graph, int v)
        {
            marked[v] = true;
            count++;
            foreach (int w in graph.Adj(v))
            {
                if (!marked[w]) dfs(graph, w);
            }
        }

        public bool Marked(int w)
        {
            return marked[w];
        }

        public int Count()
        {
            return count;
        }
    }
}
