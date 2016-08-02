using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InstamojoAPI
{
    public class InvalidPaymentOrderException : BaseException
    {
        public InvalidPaymentOrderException()
        {  }

        public InvalidPaymentOrderException(string message)
            : base()
        { }
              
    }
}
