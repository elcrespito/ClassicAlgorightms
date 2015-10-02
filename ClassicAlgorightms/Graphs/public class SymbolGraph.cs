using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ClassicAlgorightms.SearchTable;
using ClassicAlgorightms.TableNames;

namespace ClassicAlgorightms.Graphs
{
    public class SymbolGraph
    {
        private BST<string, string> st;
        private string[] keys;
        private Graph graph;

        public SymbolGraph(string[] graphData, char sp)
        {
            st = new BST<string, string>();

            for (int i = 0; i < graphData.Length; i++)
            {
                string[] a = graphData[i].Split(sp);
                foreach (string s in a)
                {
                    if (!st.Contains(s))
                    {
                        st.Put(s, st.Size().ToString());
                    }
                }
            }

            keys = new string[st.Size()];

            foreach (string key in st.Keys())
            {
                keys[int.Parse(st.Get(key))] = key;
            }

            graph = new Graph(st.Size());

            foreach (string data in graphData)
            {
                string[] a = data.Split(sp);
                int v = int.Parse(st.Get(a[0]));
                for (int i = 1; i < a.Length; i++)
                {
                    graph.AddEdge(v, int.Parse(st.Get(a[i])));
                }
            }
        }

        public bool Contains(string s)
        {
            return st.Contains(s);
        }

        public int Index(string s)
        {
            return int.Parse(st.Get(s));
        }

        public string Name(int v)
        {
            return keys[v];
        }

        public Graph G()
        {
            return graph;
        }
    }
}
