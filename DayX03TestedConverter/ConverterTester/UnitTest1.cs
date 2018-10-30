using NUnit.Framework;
using DayX03TestedConverter;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ConverterTester
{
    [TestFixture]
    public class UnitTest1
    {
        // Celcius
        [Test]        
        public void CelBelowAbsoluteZero()
        {
            Assert.That(Program.CelToFaren(-273.17),Throws.ArgumentException);
        }          
        
        [Test]
        public void CelZeroDegree()
        {
            Assert.AreEqual(Program.CelToFaren(0), 32, 0.00001, "Conversion Error");
        }
        // Farenheit
        [Test]        
        public void FarBelowAbsoluteZero()
        {
            Assert.That(Program.FarenToCel(-459.7),Throws.ArgumentException);
        }

        [Test]
            public void FarFiveDegree()
        {
            Assert.AreEqual(Program.FarenToCel(5), -15, 0.0000001, "Conversion Error");
        }
        // Yards
        [Test]       
        public void YardsToMeterAt0()
        {
            Assert.That(Program.YardToMeters(0), Throws.ArgumentException);
        }

        [Test]
        public void YardsAtNum()
        {
            Assert.AreEqual(Program.YardToMeters(5), 4.572, 0.005, "Conversion Error");
        }

        [Test]
        
        public void YardsToMeterNegative()
        {
            Assert.That(Program.YardToMeters(-1),Throws.ArgumentException);
        }


        // Meters
        [Test]
        public void MeterAtNum()
        {
            Assert.AreEqual(Program.MetersToYard(5), 5.46807, 0.005, "Conversion Error");
        }

        [Test]        
        public void MeterToYardAt0()
        {
            Assert.That(Program.MetersToYard(0),Throws.ArgumentException);
        }

        [Test]        
        public void MeterToYardNegative()
        {
            Assert.That(Program.MetersToYard(-1), Throws.ArgumentException);
        }
    }
}
