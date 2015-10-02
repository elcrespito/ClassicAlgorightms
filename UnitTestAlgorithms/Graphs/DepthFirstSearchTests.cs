using Microsoft.VisualStudio.TestTools.UnitTesting;
using ClassicAlgorightms.Graphs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassicAlgorightms.Graphs.Tests
{
    [TestClass()]
    public class DepthFirstSearchTests
    {
        [TestMethod()]
        public void DepthFirstSearchTest()
        {
            string[] graphEdges = new[] {
                "0 5",
                "2 4",
                "2 3",
                "1 2",
                "0 1",
                "3 4",
                "3 5",
                "0 2"};

            var graph = new Graph(6, 8, graphEdges);

            DepthFirstSearch search = new DepthFirstSearch(graph, 0);

            for (int v = 0; v < graph.V(); v++)
            {
                if (search.Marked(v))
                {
                    Console.WriteLine(v + " ");
                }
            }

            Console.WriteLine();
            bool isCohesion = true;
            if (search.Count() != graph.V())
            {
                isCohesion = false;
            }

            Assert.AreEqual(true, isCohesion);
        }

        [TestMethod()]
        public void MarkedTest()
        {

        }

        [TestMethod()]
        public void CountTest()
        {

        }
    }
}