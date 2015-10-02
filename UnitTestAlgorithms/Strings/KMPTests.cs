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
    public class KMPTests
    {
        [TestMethod()]
        public void SearchTest()
        {
            var kmp = new KMP("ABABAC");
            Assert.AreEqual(true, kmp.Search("BCBAABACAABABACAA"));
        }
    }
}