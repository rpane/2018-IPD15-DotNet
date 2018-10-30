using Microsoft.VisualStudio.TestTools.UnitTesting;
using DayX03TestedConverter;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ConverterTester
{
    [TestClass]
    
    public class UnitTest1
    {
        // Celcius
        [TestMethod]
        [ExpectedException(typeof(System.ArgumentException))]      
        public void CelBelowAbsoluteZero()
        {
            Program.CelToFaren(-273.17);            
        }

        [TestMethod]       
        public void CelZeroDegree()
        {
            Assert.AreEqual(Program.CelToFaren(0), 32, 0.00001, "Conversion Error");
        }
        // Farenheit
        [TestMethod]
        [ExpectedException(typeof(System.ArgumentException))]
        public void FarBelowAbsoluteZero()
        {
            Program.FarenToCel(-459.7);

        }
        [TestMethod]        
        public void FarFiveDegree()
        {
            Assert.AreEqual(Program.FarenToCel(5), -15, 0.0000001, "Conversion Error");
        }
        // Yards
        [TestMethod]
        [ExpectedException(typeof(System.ArgumentException))]        
        public void YardsToMeterAt0()
        {
            Program.YardToMeters(0);
            
        }

        [TestMethod]
        
        public void YardsAtNum()
        {
            Assert.AreEqual(Program.YardToMeters(5), 4.572, 0.005, "Conversion Error");
        }

        [TestMethod]
        [ExpectedException(typeof(System.ArgumentException))]
        

        public void YardsToMeterNegative()
        {
            Program.YardToMeters(-1);
            
        }


        // Meters
        [TestMethod]
        
        public void MeterAtNum()
        {
            Assert.AreEqual(Program.MetersToYard(5), 5.46807, 0.005, "Conversion Error");
        }

        [TestMethod]
        [ExpectedException(typeof(System.ArgumentException))]
        
        public void MeterToYardAt0()
        {
            Program.MetersToYard(0);
            
        }

        [TestMethod]
        [ExpectedException(typeof(System.ArgumentException))]
        
        public void MeterToYardNegative()
        {
            Program.MetersToYard(-1);
            
        }
    }
}