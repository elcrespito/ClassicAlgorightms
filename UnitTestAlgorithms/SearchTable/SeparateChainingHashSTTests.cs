using Microsoft.VisualStudio.TestTools.UnitTesting;
using ClassicAlgorightms.SearchTable;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassicAlgorightms.SearchTable.Tests
{
    [TestClass()]
    public class SeparateChainingHashSTTests
    {
        [TestMethod()]
        public void SeparateChainingHashSTTest()
        {
            SeparateChainingHashST<IComparable, string> st = new SeparateChainingHashST<IComparable, string>();
            string[] searchExample = new[] { "S", "E", "A", "R", "C", "H", "E", "X", "A", "M", "P", "L" };
            foreach (string val in searchExample)
            {
                st.Put(val, val);
            }

            foreach (string s in searchExample)
            {
                Assert.AreEqual(st.Get(s), s);
            }
        }

        [TestMethod()]
        public void SeparateChainingHashSTTest1()
        {
            Assert.Fail();
        }

        [TestMethod()]
        public void GetTest()
        {
            Assert.Fail();
        }

        [TestMethod()]
        public void PutTest()
        {
            Assert.Fail();
        }
    }
}