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
            Console.ReadLine();
        }
    }
}
