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
    public class BreadthFirstPathsTests
    {
        [TestMethod()]
        public void BreadthFirstPathsTest()
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