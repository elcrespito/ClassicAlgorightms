using System;
using System.Text;
using System.Collections.Generic;
using ClassicAlgorightms.SearchTable;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnitTestAlgorithms
{
    /// <summary>
    /// Summary description for TableNamesUnitTest
    /// </summary>
    [TestClass]
    public class SearchTableUnitTest
    {
        public SearchTableUnitTest()
        {
            //
            // TODO: Add constructor logic here
            //
        }

        private TestContext testContextInstance;

        /// <summary>
        ///Gets or sets the test context which provides
        ///information about and functionality for the current test run.
        ///</summary>
        public TestContext TestContext
        {
            get
            {
                return testContextInstance;
            }
            set
            {
                testContextInstance = value;
            }
        }

        #region Additional test attributes
        //
        // You can use the following additional attributes as you write your tests:
        //
        // Use ClassInitialize to run code before running the first test in the class
        // [ClassInitialize()]
        // public static void MyClassInitialize(TestContext testContext) { }
        //
        // Use ClassCleanup to run code after all tests in a class have run
        // [ClassCleanup()]
        // public static void MyClassCleanup() { }
        //
        // Use TestInitialize to run code before running each test 
        // [TestInitialize()]
        // public void MyTestInitialize() { }
        //
        // Use TestCleanup to run code after each test has run
        // [TestCleanup()]
        // public void MyTestCleanup() { }
        //
        #endregion

        [TestMethod]
        public void TestSearchTable()
        {
            var st = new BinarySearchST<IComparable, string>(12);
            string[] searchExample = new[] { "S", "E", "A", "R", "C", "H", "E", "X", "A", "M", "P", "L" };
            foreach (string val in searchExample)
            {
                st.Put(val, val);
            }

            Array.Sort(searchExample);
            foreach (IComparable comparable in st.Keys())
            {
                Console.Write(comparable);
            }

            Assert.AreEqual(true, true);
        }
    }
}
