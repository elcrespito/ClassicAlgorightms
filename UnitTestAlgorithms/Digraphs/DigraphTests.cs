using Microsoft.VisualStudio.TestTools.UnitTesting;
using ClassicAlgorightms.Digraphs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassicAlgorightms.Digraphs.Tests
{
    [TestClass()]
    public class DigraphTests
    {
        [TestMethod()]
        public void MarkedTest()
        {
            var graph = new Digraph(13, 22, new[]
            {
                "4 2",
                "2 3",
                "3 2",
                "6 0",
                "0 1",
                "2 0",
                "11 12",
                "12 9",
                "9 10",
                "9 11",
                "8 9",
                "10 12",
                "11 4",
                "4 3",
                "3 5",
                "7 8",
                "8 7",
                "5 4",
                "0 5",
                "6 4",
                "6 9",
                "7 6"
            });

            int[] sources = { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13 };

            var reachable = new DirectDfs(graph, sources);

            StringBuilder builder = new StringBuilder();
            for (int v = 0; v < graph.V(); v++)
            {
                if (reachable.Marked(v))
                {
                    builder.AppendLine(v + " ");
                }
            }
        }

        [TestMethod()]
        public void HaNoCycleTest()
        {
            var graph = new Digraph(13, 13, new[]
            {
                "0 5",
                "4 3",
                "0 1",
                "9 12",
                "6 4",
                "5 4",
                "0 2",
                "11 12",
                "9 10",
                "0 6",
                "7 8",
                "9 11",
                "5 3"
            });

            var directedCycle = new DirectedCycle(graph);

            Assert.AreEqual(false, directedCycle.HasCycle());

            var cycle = directedCycle.Cycle();
        }

        [TestMethod()]
        public void HasCycleTest()
        {
            var graph = new Digraph(13, 12, new[]
            {
                "0 1",
                "4 3",
                "0 1",
                "9 12",
                "6 4",
                "5 4",
                "0 2",
                "11 12",
                "9 10",
                "0 6",
                "7 8",
                "9 11",
                "5 3"
            });

            var directedCycle = new DirectedCycle(graph);

            Assert.AreEqual(false, directedCycle.HasCycle());

            var cycle = directedCycle.Cycle();
        }

        [TestMethod()]
        public void HasPathToTest()
        {
            var graph = new Digraph(6, 8, new[]
            {
                "0 5",
                "2 4",
                "2 3",
                "1 2",
                "0 1",
                "3 4",
                "3 5",
                "0 2"
            });

            var path = new DepthFirstDirectedPath(graph, 0);

            Assert.AreEqual(path.HasPathTo(1), true);
            Assert.AreEqual(path.HasPathTo(2), true);
            Assert.AreEqual(path.HasPathTo(3), true);
            Assert.AreEqual(path.HasPathTo(4), true);
            Assert.AreEqual(path.HasPathTo(5), true);


            var builder = new StringBuilder();

            foreach (int i in path.PathTo(4))
            {
                builder.AppendFormat(" -> {0}", i);
            }

            builder.AppendLine();
        }

        [TestMethod()]
        public void BreadthFirstDirectedPathsTest()
        {
            var graph = new Digraph(13, 22, new[]
            {
                "4 2",
                "2 3",
                "3 2",
                "6 0",
                "0 1",
                "2 0",
                "11 12",
                "12 9",
                "9 10",
                "9 11",
                "8 9",
                "10 12",
                "11 4",
                "4 3",
                "3 5",
                "7 8",
                "8 7",
                "5 4",
                "0 5",
                "6 4",
                "6 9",
                "7 6"
            });

            var path = new DirectedCycle(graph);

            Assert.AreEqual(true, path.HasCycle());

            var cycle = path.Cycle();
        }
    }
}