# C# wrapper for Instamojo API

Table of Contents
=================
* [Preface](#preface)
* [Requirements](#requirements)
* [Integration](#integration)
* [Authentication Keys](#authentication-keys)
* [Payments API](#payments-api)
    * [Create new Payment Order](#create-new-payment-order)
      * [Payment Order Creation Parameters](#payment-order-creation-parameters)
          * [Required](#required)
          * [Optional](#optional)
    * [Get list of a Payment order](#get-list-of-a-payment-order)
      *[Payment Order List Parameters](#payment-order-list-parameters)
	  * [Optional](#optional-1)	
    * [Details of Payment order using OrderId](#details-of-payment-order-using-order-id)
    * [Details of Payment order using TransactionId](#details-of-payment-order-using-transaction-id)
* [Refund API](#refund-api)
    * [Create a refund](#create-a-refund)
      * [Refund Creation Parameters](#refund-creation-parameters)
          * [Required](#required-1)

## PrefaceInstamojo DotNet wrapper for the Instamojo API assists you to programmatically create and list payment orders and refunds on Instamojo.

## RequirementsDotNet Version: 4.0+

## IntegrationTo integrate the Instamojo API into your application, add the `InstamojoWrapperApplication.dll` to the classpath of the application.

## Authentication Keys
Please raise a support ticket to receive `CLIENT_ID` and `CLIENT_SECRET` for test and production environments.

## Payments API### Create new Payment Order
``` c#
/***** Create a new payment order *******/Instamojo objClass = InstamojoImplementation.getApi( “[client_id]”, “[client_secret]”, “[endpoint]”, “[auth_endpoint]”); PaymentOrder objPaymentRequest = new PaymentOrder();  //Required POST parameters  objPaymentRequest.name = "ABCD";  objPaymentRequest.email = "foo@example.com";  objPaymentRequest.phone = "0123456789";  objPaymentRequest.amount = 9;  objPaymentRequest.transaction_id = "test"; // Unique Id to be provided  objPaymentRequest.redirect_url = “redirect_url”;try {   CreatePaymentOrderResponse objPaymentResponse = objClass.createNewPaymentRequest(objPaymentRequest);   MessageBox.Show("Order Id = " + objPaymentResponse.order.id); } catch (Exception ex) {   MessageBox.Show("Error:" + ex.Message); }
```

#### Payment Order Creation Parameters##### Required1. Name:  Name of the customer (max 100 characters).2. Email:  Email address of the customer (max 75 characters).3. Phone:  Phone number of the customer. It is recommended to use `E.164` number formatting for all phone numbers.4. Currency:  String identifier for the currency. Currently, only INR (for Indian 	Rupee) is supported.5. Amount:  Amount the customer has to pay. Numbers upto 2 decimal places are supported.6. Transaction_id:  Unique identifier for the order (max 64 characters). Identifier can contain alphanumeric characters, hyphens and underscores only. This is generally the unique order id (or primary key) in your system.7. Redirect_url:  Full URL to which the customer is redirected after payment. Redirection happens even if payment wasn't successful. This URL shouldn't contain any query parameters.##### Optional1. Description:  Short description of the order (max 255 characters). If provided, this information is sent to backend gateways, wherever possible.

### Get list of a Payment order
``` c#
/***** Get list of a payment order *******/Instamojo objClass = InstamojoImplementation.getApi( “[client_id]”, “[client_secret]”, “[endpoint]”, “[auth_endpoint]”);try{  PaymentOrderListRequest objPaymentOrderListRequest = new PaymentOrderListRequest();  //Optional Parameters  objPaymentOrderListRequest.limit = 20;  objPaymentOrderListRequest.page = 3;  PaymentOrderListResponse objPaymentRequestStatusResponse =  objClass.getPaymentOrderList(objPaymentOrderListRequest);  MessageBox.Show("Order Count = " + objPaymentRequestStatusResponse.orders.Count());}catch (Exception ex){  MessageBox.Show("Error:" + ex.Message);}
```

#### Payment Order List Parameters
##### Optional1. Id:  Search for payment orders by id.2. Transaction_id:  Search for payment orders by your transaction_id.3. Page:  Page number of the results to retrieve from.4. Limit:  Limit the number of results returned per page. Defaults to 50 results per page. Max limit allowed is 500.

### Details of Payment order using OrderId``` c#
/***** Get Details of Payment order using OrderId. *******/Instamojo objClass = InstamojoImplementation.getApi( “[client_id]”, “[client_secret]”, “[endpoint]”, “[auth_endpoint]”);try{ PaymentOrderDetailsResponse objPaymentRequestDetailsResponse = objClass.getPaymentOrderDetails("[Order_Id]");  MessageBox.Show("Transaction Id = " + objPaymentRequestDetailsResponse.transaction_id);}catch (Exception ex) {   MessageBox.Show("Error:" + ex.Message);}```

### Details of Payment order using TransactionId``` c#
/***** Details of Payment order using TransactionId. *******/Instamojo objClass = InstamojoImplementation.getApi( “[client_id]”, “[client_secret]”, “[endpoint]”, “[euth_endpoint]”);try{  PaymentOrderDetailsResponse objPaymentRequestDetailsResponse = objClass.getPaymentOrderDetailsByTransactionId("[Transaction_Id]");  MessageBox.Show("Transaction Id = " + objPaymentRequestDetailsResponse.transaction_id);}catch (Exception ex) {   MessageBox.Show("Error:" + ex.Message);}```
## Refund API### Create a refund``` c#
Refund objRefundRequest = new Refund();objRefundRequest.payment_id = "MOJO6701005J41260385";objRefundRequest.type = "TNR";objRefundRequest.body = "abcd";objRefundRequest.refund_amount = 9;if (objRefundRequest.validate()){  if (objRefundRequest.payment_idInvalid)  {      MessageBox.Show("payment_id is not valid");  }}else{  try  {         CreateRefundResponce objRefundResponse = objClass.createNewRefundRequest(objRefundRequest);         MessageBox.Show("Refund Id = " + objRefundResponse.refund.id);  }  catch (ArgumentNullException ex)  {         MessageBox.Show(ex.Message);  }  catch (WebException ex)  {         MessageBox.Show(ex.Message);  }  catch (IOException ex)  {         MessageBox.Show(ex.Message);  }  catch (InvalidPaymentOrderException ex)  {         MessageBox.Show(ex.Message);  }  catch (ConnectionException ex)  {         MessageBox.Show(ex.Message);  }  catch (BaseException ex)  {         MessageBox.Show(ex.Message);  }  catch (Exception ex)  {         MessageBox.Show("Error:" + ex.Message);  }  catch (BaseException ex)  {         MessageBox.Show("CustomException" + ex.Message);  }  catch (Exception ex)  {  MessageBox.Show("Exception" + ex.Message);  }
}
```

#### Refund Creation Parameters##### Required1. payment_id:  Id of the payment.2. type:  A three letter short-code identifying the reason for this case.3. body: payment_idAdditional text explaining the refund.4. refund_amount:  This field can be used to specify the refund amount. For instance, you may want to issue a refund for an amount lesser than what was paid.