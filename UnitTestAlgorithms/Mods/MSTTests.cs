﻿using Microsoft.VisualStudio.TestTools.UnitTesting;
using ClassicAlgorightms.Mods;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassicAlgorightms.Mods.Tests
{
    [TestClass()]
    public class MSTTests
    {
        [TestMethod()]
        public void LazyPrimMSTTest()
        {
            string[] graphItems = {
                "4 5 0.35",
                "4 7 0.37",
                "5 7 0.28",
                "0 7 0.16",
                "1 5 0.32",
                "0 4 0.38",
                "2 3 0.17",
                "1 7 0.19",
                "0 2 0.26",
                "1 2 0.36",
                "1 3 0.29",
                "2 7 0.34",
                "6 2 0.40",
                "3 6 0.52",
                "6 0 0.58",
                "6 4 0.93"
            };
            var graph = new EdgeWeightedGraph(8, 16, graphItems);

            MST mst = new LazyPrimMST(graph);

            var builder = new StringBuilder();
            foreach (Edge edge in mst.edges())
            {
                builder.AppendFormat("Edge {0}", edge);
            }

            Assert.AreEqual(1.81, mst.Weight);
        }

        [TestMethod()]
        public void PrimMSTTest()
        {
            string[] graphItems = {
                "4 5 0.35",
                "4 7 0.37",
                "5 7 0.28",
                "0 7 0.16",
                "1 5 0.32",
                "0 4 0.38",
                "2 3 0.17",
                "1 7 0.19",
                "0 2 0.26",
                "1 2 0.36",
                "1 3 0.29",
                "2 7 0.34",
                "6 2 0.40",
                "3 6 0.52",
                "6 0 0.58",
                "6 4 0.93"
            };

            var graph = new EdgeWeightedGraph(8, 16, graphItems);

            MST mst = new PrimMST(graph);

            var builder = new StringBuilder();
            foreach (Edge edge in mst.edges())
            {
                builder.AppendFormat("Edge {0}", edge);
            }

            Assert.AreEqual(1.81, mst.Weight);
        }
    }
}