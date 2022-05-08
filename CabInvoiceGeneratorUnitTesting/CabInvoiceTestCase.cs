using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using CabInvoiceGenerator;

namespace CabInvoiceGeneratorUnitTesting
{
    [TestClass]
    public class CabInvoiceTestCase
    {
        public CabInvoiceGenrator generateNormalFare;

        [TestInitialize]
        public void SetUp()
        {
            generateNormalFare = new CabInvoiceGenrator(RideType.NORMAL_RIDE);
        }

        // TC1.1 Positive Testcase
        [TestMethod]
        [TestCategory("Calculate Fare")]
        [DataRow(1, 1.0, 11)]
        [DataRow(10, 15, 160)]
        public void GivenDistanceAndTimeReturnTotalFare(int time, double distance, double expected)
        {
            double actual = generateNormalFare.CalculateFare(time, distance);
            Assert.AreEqual(actual, expected);
        }

        // TC 1.2 Given Invalid Time And Distance Return Custom Exception
        [TestMethod]
        [TestCategory("Calculate Fare")]
        public void GivenInvalidTimeAndDistanceReturnCustomException()
        {
            var invalidTimeException = Assert.ThrowsException<CabInvoiceGeneratorException>(() => generateNormalFare.CalculateFare(0, 5));
            Assert.AreEqual(CabInvoiceGeneratorException.ExceptionType.INVALID_TIME, invalidTimeException.exceptionType);
            var invalidDistanceException = Assert.ThrowsException<CabInvoiceGeneratorException>(() => generateNormalFare.CalculateFare(12, -1));
            Assert.AreEqual(CabInvoiceGeneratorException.ExceptionType.INVALID_DISTANCE, invalidDistanceException.exceptionType);
        }
    }
}
