using System;
using System.Text;
using System.Collections.Generic;
using ClassicAlgorightms.SearchTable;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnitTestAlgorithms
{
    /// <summary>
    /// Summary description for HashingTest
    /// </summary>
    [TestClass]
    public class HashingTest
    {
        public HashingTest()
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
        public void TesBasicHash()
        {
            char[] hashArray = { 'S', 'E', 'A', 'R', 'C', 'H', 'X', 'M', 'P', 'L' };

            int[] fiveArray = { 2, 0, 0, 4, 4, 4, 2, 4, 3, 3 };
            int[] sixteenArray = { 6, 10, 4, 14, 5, 4, 15, 1, 14, 6 };

            int[] fiveArrayTest = new int[10];
            int[] sixteenArrayTest = new int[10];

            var hasch = new Hashing<char>();
            for (int i = 0; i < 10; i++)
            {
                fiveArrayTest[i] = hasch.Hash(hashArray[i], 5);
                sixteenArrayTest[i] = hasch.Hash(hashArray[i], 16);
            }

            Assert.AreEqual(fiveArray, fiveArrayTest);
            Assert.AreEqual(sixteenArray, sixteenArrayTest);
        }
    }
}
