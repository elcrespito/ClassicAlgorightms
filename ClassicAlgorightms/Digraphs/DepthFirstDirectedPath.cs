using System.Collections.Generic;
using ClassicAlgorightms.Graphs;

namespace ClassicAlgorightms.Digraphs
{
    public class DepthFirstDirectedPath
    {
        private bool[] marked;
        private int[] edgeTo;
        private int s;
        private Queue<int> pre = new Queue<int>();
        private Queue<int> post = new Queue<int>();
        private Stack<int> reversPost = new Stack<int>();

        public DepthFirstDirectedPath(Digraph g, int s)
        {
            marked = new bool[g.V()];
            edgeTo = new int[g.V()];
            this.s = s;
            dfs(g, s);
        }

        private void dfs(Digraph graph, int v)
        {
            pre.Enqueue(v);
            marked[v] = true;

            foreach (int w in graph.Adj(v))
            {
                if (!marked[w])
                {
                    edgeTo[w] = v;
                    dfs(graph, w);
                }
            }

            post.Enqueue(v);
            reversPost.Push(v);
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

        public IEnumerable<int> Pre => pre;

        public IEnumerable<int> Post => post;

        public IEnumerable<int> ReversPost => reversPost;
    }
}
