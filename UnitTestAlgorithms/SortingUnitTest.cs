using System;
using ClassicAlgorightms.Sorting;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnitTestAlgorithms
{
    [TestClass]
    public class SortingUnitTest
    {
        [TestMethod]
        public void TestSelection()
        {
            Selection selectionSort = new Selection();
            string[] a = { "S", "O", "R", "T", "E", "X", "A", "M", "P", "L", "E" };
            selectionSort.Sort(a);
            Assert.AreEqual(selectionSort.isSorted(a), true);
        }

        [TestMethod]
        public void TestShell()
        {
            ShellSorting selectionSort = new ShellSorting();
            string[] a = { "S", "O", "R", "T", "E", "X", "A", "M", "P", "L", "E" };
            selectionSort.Sort(a);
            Assert.AreEqual(selectionSort.isSorted(a), true);
        }

        [TestMethod]
        public void TestShellInArray()
        {
            ShellInArray selectionSort = new ShellInArray();
            string[] a = { "S", "O", "R", "T", "E", "X", "A", "M", "P", "L", "E" };
            selectionSort.Sort(a);
            Assert.AreEqual(selectionSort.isSorted(a), false);
        }


        [TestMethod]
        public void TestMergeSortingArray()
        {
            var selectionSort = new MergeSorting();
            string[] a = { "M", "E", "R", "G", "E", "S", "O", "R", "T", "E", "X", "A", "M", "P", "L", "E" };
            selectionSort.Sort(a);
            Assert.AreEqual(selectionSort.isSorted(a), true);
        }

        [TestMethod]
        public void TestQuickSorting()
        {
            var sort = new QuickSorting();
            string[] a = { "K", "R", "A", "T", "E", "L", "E", "P", "U", "I", "M", "Q", "C", "X", "O", "S" };
            sort.Sort(a);
            Assert.AreEqual(sort.isSorted(a), true);
        }

        [TestMethod]
        public void TestHeapSorting()
        {
            var sort = new HeapSorting();
            string[] a = { "", "K", "R", "A", "T", "E", "L", "E", "P", "U", "I", "M", "Q", "C", "X", "O", "S" };
            sort.sort(a);
            Assert.AreEqual(sort.isSorted(a), true);
        }
    }
}
