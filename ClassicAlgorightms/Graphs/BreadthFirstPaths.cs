using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassicAlgorightms.Graphs
{
    public class BreadthFirstPaths
    {
        private bool[] marked;
        private int[] edgeTo;
        private int s;

        public BreadthFirstPaths(Graph graph, int s)
        {
            marked = new bool[graph.V()];
            edgeTo = new int[graph.V()];
            this.s = s;
            bfs(graph, s);
        }

        private void bfs(Graph graph, int s)
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
