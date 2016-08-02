using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace InstamojoAPI
{
    public interface Instamojo
    {
        /**
          * Create a Payment Order request Create a Payment Order request response.
          *
          * @param paymentRequest the payment request
          * @return the create payment request response
          */
        CreatePaymentOrderResponse createNewPaymentRequest(PaymentOrder objPaymentRequest);

        /**
          * Get all your payment orders.
          *
          * @return the payment request status
          */
        PaymentOrderListResponse getPaymentOrderList(PaymentOrderListRequest objPaymentOrderListRequest);

        /**
          * Get details of this payment order.
          *
          * @param strPaymentId        the payment id
          * @return the payment status
          */
        PaymentOrderDetailsResponse getPaymentOrderDetails(string strOrderId);

        /**
          * Get details of this payment order of TransactionId
          *
          * @return the payment request list
          */
        PaymentOrderDetailsResponse getPaymentOrderDetailsByTransactionId(string strTransactionId);

        /**
         * Create a Refund request.
         *
         * @return the Sucess
         */
        CreateRefundResponce createNewRefundRequest(Refund objRefund);
    }
}
