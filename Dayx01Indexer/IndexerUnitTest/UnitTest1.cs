using Microsoft.VisualStudio.TestTools.UnitTesting;
using Dayx01Indexer;
using System;

namespace IndexerUnitTest
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void PrimeArrayFast_NegativeIndexException()
        {
            PrimeArray paf = new PrimeArray();
            long result = paf[-1]; //should throw ArgumentOutOfRangeException
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void ZeroIndexException()
        {
            PrimeArray paf = new PrimeArray();
            long result = paf[0]; //should throw ArgumentOutOfRangeException
        }

        [TestMethod]        
        public void OneIndex()
        {
            PrimeArray paf = new PrimeArray();            
            Assert.AreEqual(paf[1], 2, "paf[1] - First prime must be 2");
        }
    }
}
