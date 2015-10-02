using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassicAlgorightms.Graphs
{
    public class CC
    {
        private bool[] marked;
        private int[] id;
        private int count;

        public CC(Graph g)
        {
            marked = new bool[g.V()];
            id = new int[g.V()];

            for (int s = 0; s < g.V(); s++)
            {
                if (!marked[s])
                {
                    dfs(g, s);
                    count++;
                }
            }
        }

        private void dfs(Graph graph, int v)
        {
            marked[v] = true;
            id[v] = count;
            foreach (int w in graph.Adj(v))
            {
                if (!marked[w])
                    dfs(graph, w);
            }
        }

        public bool Connected(int v, int w)
        {
            return id[v] == id[w];
        }

        public int Id(int v)
        {
            return id[v];
        }

        public int Count()
        {
            return count;
        }
    }
}
