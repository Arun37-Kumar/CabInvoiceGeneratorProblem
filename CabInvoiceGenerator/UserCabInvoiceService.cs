using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CabInvoiceGenerator
{
    public class UserCabInvoiceService
    {
        public UserCabInvoiceService(List<Ride> rides, InvoiceSummary invoiceSummary1)
        {
            Rides = rides;
            InvoiceSummary = invoiceSummary1;
        }

        public List<Ride> Rides { get; }
        public InvoiceSummary InvoiceSummary { get; }

        //Method to check the specified object is equal to the instance
        public override bool Equals(object obj)
        {
            if (obj == null)
                return false;
            if (!(obj is UserCabInvoiceService))
                return false;
            UserCabInvoiceService userCabService = (UserCabInvoiceService)obj;
            return this.Rides == userCabService.Rides && this.InvoiceSummary.totalFare == userCabService.InvoiceSummary.totalFare;
        }
    }
}
