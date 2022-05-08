using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CabInvoiceGenerator
{
    public class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to Cab Invoice Generator Program");

            CabInvoiceGenrator cabInvoiceGenerator = new CabInvoiceGenrator(RideType.NORMAL_RIDE);
            Console.WriteLine(cabInvoiceGenerator.CalculateFare(10, 15));

            Ride[] multiRides = { new Ride(10, 15), new Ride(10, 15) };
            Console.WriteLine(cabInvoiceGenerator.CalculateAgreegateFare(multiRides));

            InvoiceSummary invoice = new InvoiceSummary(10,20);
            double result1 = invoice.averageFare;
            Console.WriteLine("The average Fare is : " + result1);
            Console.ReadLine();
        }
    }
}
