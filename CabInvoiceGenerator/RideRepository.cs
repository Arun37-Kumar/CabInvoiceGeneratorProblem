using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CabInvoiceGenerator
{
    public class RideRepository
    {

        Dictionary<int, List<Ride>> userCabRides;
        Dictionary<int, InvoiceSummary> userCabInvoice;

        public RideRepository()
        {
            this.userCabRides = new Dictionary<int, List<Ride>>();
            this.userCabInvoice = new Dictionary<int, InvoiceSummary>();
        }

        //UC4 - Method to store invoice of all rides by user id
        public void AddUserRidesToRepository(int userId, Ride[] rides, RideType rideType)
        {
            bool rideList = this.userCabRides.ContainsKey(userId);
            try
            {
                if (!rideList)
                {
                    List<Ride> list = new List<Ride>();
                    list.AddRange(rides);
                    this.userCabRides.Add(userId, list);
                    CabInvoiceGenrator cabInvoice = new CabInvoiceGenrator(rideType);
                    InvoiceSummary invoiceSummary = cabInvoice.CalculateAgreegateFare(rides);
                    userCabInvoice.Add(userId, invoiceSummary);
                }
            }
            catch (CabInvoiceGeneratorException)
            {
                throw new CabInvoiceGeneratorException(CabInvoiceGeneratorException.ExceptionType.NULL_RIDES, "No Rides Found");
            }
        }

        //Method to return invoice summary of a particular user by providing id
        public UserCabInvoiceService ReturnInvoicefromRideRepository(int userId)
        {
            return new UserCabInvoiceService(userCabRides[userId], userCabInvoice[userId]);
        }
    }
}
