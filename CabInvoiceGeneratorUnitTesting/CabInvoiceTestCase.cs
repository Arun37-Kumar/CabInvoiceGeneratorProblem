using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using CabInvoiceGenerator;
using System.Collections.Generic;

namespace CabInvoiceGeneratorUnitTesting
{
    [TestClass]
    public class CabInvoiceTestCase
    {
        public CabInvoiceGenrator generateNormalFare,generatePremiumFare;

        [TestInitialize]
        public void SetUp()
        {
            generateNormalFare = new CabInvoiceGenrator(RideType.NORMAL_RIDE);
            generatePremiumFare = new CabInvoiceGenrator(RideType.PREMIUM_RIDE);
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

        // TC2.1, 3.1 - Given multiple rides should return invoice summary
        [TestMethod]
        [TestCategory("Multiple Rides")]
        public void GivenMultipleRidesReturnAggregateFare()
        {
            Ride[] cabRides = { new Ride(10, 15), new Ride(10, 15) };
            InvoiceSummary normal_Expected = new InvoiceSummary(cabRides.Length, 320);
            var normal_Actual = generateNormalFare.CalculateAgreegateFare(cabRides);
            Assert.AreEqual(normal_Actual, normal_Expected);

            InvoiceSummary premium_Expected = new InvoiceSummary(cabRides.Length, 490);
            var premium_Actual = generatePremiumFare.CalculateAgreegateFare(cabRides);
            Assert.AreEqual(premium_Actual, premium_Expected);
        }
        // TC2.2 - given no rides return custom exception
        [TestMethod]
        [TestCategory("Multiple Rides")]
        public void GivenNoRidesReturnCustomException()
        {
            Ride[] cabRides = { };
            var nullRidesException = Assert.ThrowsException<CabInvoiceGeneratorException>(() => generateNormalFare.CalculateAgreegateFare(cabRides));
            Assert.AreEqual(CabInvoiceGeneratorException.ExceptionType.NULL_RIDES, nullRidesException.exceptionType);
        }

        // TC 4.1, 5.1 - Given user Id should return invoice summary
        [TestMethod]
        [TestCategory("Invoice Service")]
        [DataRow(1, 2, 320, 10, 15, 10, 15)]
        public void GivenUserIdReturnInvoiceSummary(int userId, int cabRideCount, double totalFare, int time1, double distance1, int time2, double distance2)
        {
            RideRepository rideRepository = new RideRepository();
            Ride[] userRides = { new Ride(time1, distance1), new Ride(time2, distance2) };
            rideRepository.AddUserRidesToRepository(userId, userRides, RideType.NORMAL_RIDE);
            List<Ride> list = new List<Ride>();
            list.AddRange(userRides);
            InvoiceSummary userInvoice = new InvoiceSummary(cabRideCount, totalFare);

            UserCabInvoiceService expected = new UserCabInvoiceService(list, userInvoice);
            UserCabInvoiceService actual = rideRepository.ReturnInvoicefromRideRepository(userId);
            Assert.AreEqual(actual.InvoiceSummary.totalFare, expected.InvoiceSummary.totalFare);
        }

    }
}
