using System.Collections.Generic;
using System.Linq;
using ClassicAlgorightms.Graphs;

namespace ClassicAlgorightms.Digraphs
{
    public class BreadthFirstDirectedPaths
    {
        private bool[] marked;
        private int[] edgeTo;
        private int s;

        public BreadthFirstDirectedPaths(Digraph graph, int s)
        {
            marked = new bool[graph.V()];
            edgeTo = new int[graph.V()];
            this.s = s;
            bfs(graph, s);
        }

        private void bfs(Digraph graph, int s)
        {
            Queue<int> queue = new Queue<int>();
            marked[s] = true;
            queue.Enqueue(s);
            while (queue.Any())
            {
                int v = queue.Dequeue();

                foreach (int w in graph.Adj(v))
                {
                    if (!marked[w])
                    {
                        edgeTo[w] = v;
                        marked[w] = true;
                        queue.Enqueue(w);
                    }
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
