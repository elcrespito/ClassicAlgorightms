using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassicAlgorightms.Digraphs
{
    public class DirectedCycle
    {
        private bool[] marked;
        private int[] edgeTo;
        private Stack<int> cycle;
        private bool[] onStack;

        public DirectedCycle(Digraph g)
        {
            onStack = new bool[g.V()];
            edgeTo = new int[g.V()];
            marked = new bool[g.V()];

            for (int v = 0; v < g.V(); v++)
            {
                if (!marked[v]) dfs(g, v);
            }
        }

        private void dfs(Digraph g, int v)
        {
            onStack[v] = true;
            marked[v] = true;

            foreach (int w in g.Adj(v))
            {
                if (this.HasCycle()) return;
                else if (!marked[w])
                {
                    edgeTo[w] = v; dfs(g, w);
                }
                else if (onStack[w])
                {
                    cycle = new Stack<int>();

                    for (int x = v; x != w; x = edgeTo[x])
                        cycle.Push(x);
                    cycle.Push(w);
                    cycle.Push(v);
                }
            }

            onStack[v] = false;
        }

        public bool HasCycle()
        {
            return cycle != null;
        }

        public IEnumerable<int> Cycle()
        {
            return cycle;
        }
    }
}
