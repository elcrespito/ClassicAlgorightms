using Microsoft.VisualStudio.TestTools.UnitTesting;
using ClassicAlgorightms.DirectEdgeGraphs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassicAlgorightms.DirectEdgeGraphs.Tests
{
    [TestClass()]
    public class DijkstraSPTests
    {
        [TestMethod()]
        public void DijkstraSPTest()
        {
            var graph = new EdgeWeightedDigrap(8, new[]
            {
                "4 5 0.35",
                "5 4 0.35",
                "4 7 0.37",
                "5 7 0.28",
                "7 5 0.28",
                "5 1 0.32",
                "0 4 0.38",
                "0 2 0.26",
                "7 3 0.39",
                "1 3 0.29",
                "2 7 0.34",
                "6 2 0.40",
                "3 6 0.52",
                "6 0 0.58",
                "6 4 0.93"
            });

            var dijkstra = new DijkstraSP(graph, 0);
            Assert.AreEqual(dijkstra.HasPathTo(6), true);
            dijkstra.DistTo(6);

            var builder = new StringBuilder();
            foreach (var data in dijkstra.PathTo(6))
            {
                builder.AppendFormat("->{0}", data.To);
            }
        }
    }
}