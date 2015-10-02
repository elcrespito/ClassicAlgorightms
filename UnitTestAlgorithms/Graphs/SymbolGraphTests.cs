using Microsoft.VisualStudio.TestTools.UnitTesting;
using ClassicAlgorightms.Graphs;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassicAlgorightms.Graphs.Tests
{
    [TestClass()]
    public class SymbolGraphTests
    {
        [TestMethod()]
        public void SymbolGraphTest()
        {
            string path = @"D:\Projects\ClassicAlgorightms\ClassicAlgorightms\Files\movies.txt";

            TextReader reader = new StreamReader(path);
            List<string> graphData = new List<string>();

            string line;

            while ((line = reader.ReadLine()) != null)
            {
                graphData.Add(line);
            }

            SymbolGraph graph = new SymbolGraph(graphData.ToArray(), '/');
            Graph g = graph.G();

            StringBuilder builder = new StringBuilder();
            foreach (string s in graphData)
            {
                foreach (int w in g.Adj(graph.Index(s)))
                {
                    builder.AppendLine(" " + graph.Name(w));
                }
            }
        }

        [TestMethod()]
        public void ContainsTest()
        {

        }

        [TestMethod()]
        public void IndexTest()
        {

        }

        [TestMethod()]
        public void NameTest()
        {

        }

        [TestMethod()]
        public void GTest()
        {

        }
    }
}