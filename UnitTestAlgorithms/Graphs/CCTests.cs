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
    public class CCTests
    {
        [TestMethod()]
        public void CCTest()
        {
            string[] graphEdges = new[] {
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
                "5 3"};

            var graph = new Graph(13, 13, graphEdges);

            CC cc = new CC(graph);
            int m = cc.Count();

            List<int>[] components = new List<int>[m];

            for (int i = 0; i < m; i++)
            {
                components[i] = new List<int>();
            }

            for (int v = 0; v < graph.V(); v++)
            {
                components[cc.Id(v)].Add(v);
            }

            StringBuilder builder = new StringBuilder();
            for (int i = 0; i < m; i++)
            {
                foreach (int v in components[i])
                {
                    builder.Append(v + " ");
                }

                builder.AppendLine();
            }
        }

        [TestMethod()]
        public void ConnectedTest()
        {

        }

        [TestMethod()]
        public void IdTest()
        {

        }

        [TestMethod()]
        public void CountTest()
        {

        }
    }
}