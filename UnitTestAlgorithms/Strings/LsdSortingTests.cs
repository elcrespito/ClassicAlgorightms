using Microsoft.VisualStudio.TestTools.UnitTesting;
using ClassicAlgorightms.Strings;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassicAlgorightms.Strings.Tests
{
    [TestClass()]
    public class LsdSortingTests
    {
        [TestMethod()]
        public void SortTest()
        {
            string[] array = "bed bug dad yes zoo now for tip ilk dim tag jot sob nob sky hut men egg few jay owl joy rap gig wee was wad fee tap tar dug jam all bad yet".Split(' ');
            LsdSorting.Sort(array, 3);
            Assert.AreEqual(array[array.Length - 1], "zoo");
        }
    }
}