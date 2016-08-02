using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InstamojoAPI
{
    public class CreatePaymentOrderResponse
    {
        public Order order { get; set; }
        public PaymentOptions payment_options { get; set; }
    }
}
