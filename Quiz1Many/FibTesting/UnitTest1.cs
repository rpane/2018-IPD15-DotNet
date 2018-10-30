using System;
using Quiz1Many;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace FibTesting
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void AtZero()
        {
            FibNums test1 = new FibNums();
            long result = test1[0];
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void NegativeNumber()
        {
            FibNums test2 = new FibNums();
            long result = test2[-1];
        }

        [TestMethod]
        public void FebNumTest()
        {
            FibNums test3 = new FibNums();
            Assert.AreEqual(test3[3], 2, "Incorrect Calculation");
        }       
    }
}
