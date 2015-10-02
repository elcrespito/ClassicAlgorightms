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
    public class DepthFirstPathTests
    {
        [TestMethod()]
        public void DepthFirstPathTest()
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

            DepthFirstPath search = new DepthFirstPath(graph, 0);

            var pathBuilder = new StringBuilder();
            for (int v = 0; v < graph.V(); v++)
            {
                if (search.HasPathTo(v))
                {
                    foreach (int x in search.PathTo(v))
                    {
                        if (x == 0)
                            pathBuilder.Append(x);
                        else
                        {
                            pathBuilder.Append(" - " + x);
                        }
                    }
                }
            }
        }

        [TestMethod()]
        public void HasPathToTest()
        {

        }

        [TestMethod()]
        public void PathToTest()
        {

        }
    }
}