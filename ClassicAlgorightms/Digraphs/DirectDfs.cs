using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassicAlgorightms.Digraphs
{
    public class DirectDfs
    {
        private bool[] marked;

        public DirectDfs(Digraph graph, int s)
        {
            marked = new bool[graph.V()];
            dfs(graph, s);
        }

        public DirectDfs(Digraph graph, IEnumerable<int> sources)
        {
            marked = new bool[graph.V()];
            for (int i = 0; i < sources.Count(); i++)
            {
                if (!marked[i])
                {
                    dfs(graph, i);
                }
            }
        }

        private void dfs(Digraph graph, int v)
        {
            foreach (int w in graph.Adj(v))
            {
                if (!marked[w])
                {
                    dfs(graph, w);
                }
            }
        }

        public bool Marked(int v)
        {
            return marked[v];
        }
    }
}
