using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CabInvoiceGenerator
{
    public class CabInvoiceGeneratorException : Exception
    {
       public ExceptionType exceptionType;

        /// <summary>
        /// Enum for exectionType
        /// </summary>
        public enum ExceptionType
        {
            INVALID_TIME,
            INVALID_DISTANCE,
            NULL_RIDES
        }

        /// <summary>
        /// Constructor for custom exception
        /// </summary>
        /// <param name="exceptionType"></param>
        /// <param name="message"></param>
        public CabInvoiceGeneratorException(ExceptionType exceptionType, string message) : base(message)
        {
            this.exceptionType = exceptionType;
        }

    }
}
