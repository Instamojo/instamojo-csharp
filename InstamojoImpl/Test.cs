using System;
using System.IO;
using System.Linq;
using System.Net;
using System.Windows.Forms;
using InstamojoAPI;

namespace InstamojoImpl
{
   static  class Test
    {
       [STAThread]
       static void Main()
       {
           	Application.EnableVisualStyles();
           	Application.SetCompatibleTextRenderingDefault(false);

           	string Insta_client_id = "tmLkZZ0zV41nJwhayBGBOI4m4I7bH55qpUBdEXGS",
                  Insta_client_secret = "IDejdccGqKaFlGav9bntKULvMZ0g7twVFolC9gdrh9peMS0megSFr7iDpWwWIDgFUc3W5SlX99fKnhxsoy6ipdAv9JeQwebmOU6VRvOEQnNMWwZnWglYmDGrfgKRheXs",
                  Insta_Endpoint = InstamojoConstants.INSTAMOJO_API_ENDPOINT,
                  Insta_Auth_Endpoint = InstamojoConstants.INSTAMOJO_AUTH_ENDPOINT;
			Instamojo objClass = InstamojoImplementation.getApi(Insta_client_id, Insta_client_secret, Insta_Endpoint, Insta_Auth_Endpoint);
           	CreatePaymentOrder(objClass);
           	CreatePaymentOrder_whenInvalidPaymentOrderIsMade(objClass);
			CreatePaymentOrder_whenWebhookIsInvalid(objClass);
			CreatePaymentOrder_whenSameTransactionIdIsGiven(objClass);
			GetAllPaymentOrdersList(objClass);
			GetPaymentOrderDetailUsingOrderId(objClass);
			GetPaymentOrderDetailUsingOrderId_WhenOrderIdIsNull(objClass);
			GetPaymentOrderDetailUsingOrderId_WhenOrderIdIsUnknown(objClass);
			GetPaymentOrderDetailsUsingTransactionId(objClass);
			GetPaymentOrderDetailsUsingTransactionId_WhenTransactionIdIsUnknown(objClass);
			CreateRefund(objClass);
			CreateRefund_WhenInvalidRefundIsMade(objClass);
			CreatePaymentOrder_whenWebhookContainsLocahost(objClass);
       }
       static void CreatePaymentOrder(Instamojo objClass)
       {
           PaymentOrder objPaymentRequest = new PaymentOrder();
           //Required POST parameters
        	objPaymentRequest.name = "ABCD";
           	objPaymentRequest.email = "foo@example.com";
           	objPaymentRequest.phone = "9969156561";
			objPaymentRequest.description = "Test description";
           	objPaymentRequest.amount = 9;
           	objPaymentRequest.currency = "USD";

           	string randomName = Path.GetRandomFileName();
           	randomName = randomName.Replace(".", string.Empty);
           	objPaymentRequest.transaction_id = "test" + randomName;

           	objPaymentRequest.redirect_url = "https://swaggerhub.com/api/saich/pay-with-instamojo/1.0.0";
			objPaymentRequest.webhook_url = "https://your.server.com/webhook";
           	//Extra POST parameters 

           	if (objPaymentRequest.validate())
           	{
               if (objPaymentRequest.emailInvalid)
               {
                   MessageBox.Show("Email is not valid");
               }
               if (objPaymentRequest.nameInvalid)
               {
                   MessageBox.Show("Name is not valid");
               }
               if (objPaymentRequest.phoneInvalid)
               {
                   MessageBox.Show("Phone is not valid");
               }
               if (objPaymentRequest.amountInvalid)
               {
                   MessageBox.Show("Amount is not valid");
               }
               if (objPaymentRequest.currencyInvalid)
               {
                   MessageBox.Show("Currency is not valid");
               }
               if (objPaymentRequest.transactionIdInvalid)
               {
                   MessageBox.Show("Transaction Id is not valid");
               }
               if (objPaymentRequest.redirectUrlInvalid)
               {
                   MessageBox.Show("Redirect Url Id is not valid");
               }
				if (objPaymentRequest.webhookUrlInvalid)
				{
					MessageBox.Show("Webhook URL is not valid");
				}

           }
           else
           {
               try
               {
                   CreatePaymentOrderResponse objPaymentResponse = objClass.createNewPaymentRequest(objPaymentRequest);
					MessageBox.Show("Payment URL = " + objPaymentResponse.payment_options.payment_url);
               }
               catch (ArgumentNullException ex)
               {
                   MessageBox.Show(ex.Message);
               }
               catch (WebException ex)
               {
                   MessageBox.Show(ex.Message);
               }
               catch (IOException ex)
               {
                   MessageBox.Show(ex.Message);
               }
               catch (InvalidPaymentOrderException ex)
               {
                   if (!ex.IsWebhookValid())
					{
						MessageBox.Show("Webhook is invalid");
					}

					if (!ex.IsCurrencyValid())
					{
						MessageBox.Show("Currency is Invalid");
					}

					if (!ex.IsTransactionIDValid())
					{
						MessageBox.Show("Transaction ID is Inavlid");
					}
               }
               catch (ConnectionException ex)
               {
                   MessageBox.Show(ex.Message);
               }
               catch (BaseException ex)
               {
                   MessageBox.Show(ex.Message);
               }
               catch (Exception ex)
               {
                   MessageBox.Show("Error:" + ex.Message);
               }
           }
       }

       static void CreatePaymentOrder_whenInvalidPaymentOrderIsMade(Instamojo objClass)
       {
           PaymentOrder objPaymentRequest = new PaymentOrder();
        //   objPaymentRequest.email = "foo@example.com";
           objPaymentRequest.phone = "9969156561";
           objPaymentRequest.amount = 9;
           objPaymentRequest.currency = "USD";
           string randomName = Path.GetRandomFileName();
           randomName = randomName.Replace(".", string.Empty);
           objPaymentRequest.transaction_id = "test" + randomName;

           objPaymentRequest.redirect_url = "https://swaggerhub.com/api/saich/pay-with-instamojo/1.0.0";
           //Extra POST parameters 

           if (objPaymentRequest.validate())
           {
               if (objPaymentRequest.emailInvalid)
               {
                   MessageBox.Show("Email is not valid");
               }
               if (objPaymentRequest.nameInvalid)
               {
                   MessageBox.Show("Name is not valid");
               }
               if (objPaymentRequest.phoneInvalid)
               {
                   MessageBox.Show("Phone is not valid");
               }
               if (objPaymentRequest.amountInvalid)
               {
                   MessageBox.Show("Amount is not valid");
               }
               if (objPaymentRequest.currencyInvalid)
               {
                   MessageBox.Show("Currency is not valid");
               }
               if (objPaymentRequest.transactionIdInvalid)
               {
                   MessageBox.Show("Transaction Id is not valid");
               }
               if(objPaymentRequest.redirectUrlInvalid)
               {
                   MessageBox.Show("Redirect Url Id is not valid");
               }
           }
        
       }

		static void CreatePaymentOrder_whenWebhookIsInvalid(Instamojo objClass)
		{
			PaymentOrder objPaymentRequest = new PaymentOrder();
			objPaymentRequest.email = "foo@example.com";
			objPaymentRequest.name = "Test Name";
			objPaymentRequest.description = "Test Description";
			objPaymentRequest.phone = "9334556657";
			objPaymentRequest.amount = 100;
			objPaymentRequest.currency = "INR";
			string randomName = Path.GetRandomFileName();
			randomName = randomName.Replace(".", string.Empty);
			objPaymentRequest.transaction_id = "test" + randomName;

			objPaymentRequest.redirect_url = "https://swaggerhub.com/api/saich/pay-with-instamojo/1.0.0";
			objPaymentRequest.webhook_url = "invalid web hook url";
			//Extra POST parameters 

			if (objPaymentRequest.validate())
			{
				if (objPaymentRequest.emailInvalid)
				{
					MessageBox.Show("Email is not valid");
				}
				if (objPaymentRequest.nameInvalid)
				{
					MessageBox.Show("Name is not valid");
				}
				if (objPaymentRequest.phoneInvalid)
				{
					MessageBox.Show("Phone is not valid");
				}
				if (objPaymentRequest.amountInvalid)
				{
					MessageBox.Show("Amount is not valid");
				}
				if (objPaymentRequest.currencyInvalid)
				{
					MessageBox.Show("Currency is not valid");
				}
				if (objPaymentRequest.transactionIdInvalid)
				{
					MessageBox.Show("Transaction Id is not valid");
				}
				if (objPaymentRequest.redirectUrlInvalid)
				{
					MessageBox.Show("Redirect Url Id is not valid");
				}

				if (objPaymentRequest.webhookUrlInvalid)
				{
					MessageBox.Show("Webhook URL is not valid");
				}
			}

		}

		static void CreatePaymentOrder_whenWebhookContainsLocahost(Instamojo objClass)
		{
			PaymentOrder objPaymentRequest = new PaymentOrder();
			objPaymentRequest.email = "foo@example.com";
			objPaymentRequest.name = "Test Name";
			objPaymentRequest.description = "Test Description";
			objPaymentRequest.phone = "9334556657";
			objPaymentRequest.amount = 100;
			objPaymentRequest.currency = "INR";
			string randomName = Path.GetRandomFileName();
			randomName = randomName.Replace(".", string.Empty);
			objPaymentRequest.transaction_id = "test" + randomName;

			objPaymentRequest.redirect_url = "https://swaggerhub.com/api/saich/pay-with-instamojo/1.0.0";
			objPaymentRequest.webhook_url = "http://localhost:8080/webhook";
			//Extra POST parameters 

			if (objPaymentRequest.validate())
			{
				if (objPaymentRequest.emailInvalid)
				{
					MessageBox.Show("Email is not valid");
				}
				if (objPaymentRequest.nameInvalid)
				{
					MessageBox.Show("Name is not valid");
				}
				if (objPaymentRequest.phoneInvalid)
				{
					MessageBox.Show("Phone is not valid");
				}
				if (objPaymentRequest.amountInvalid)
				{
					MessageBox.Show("Amount is not valid");
				}
				if (objPaymentRequest.currencyInvalid)
				{
					MessageBox.Show("Currency is not valid");
				}
				if (objPaymentRequest.transactionIdInvalid)
				{
					MessageBox.Show("Transaction Id is not valid");
				}
				if (objPaymentRequest.redirectUrlInvalid)
				{
					MessageBox.Show("Redirect Url Id is not valid");
				}

				if (objPaymentRequest.webhookUrlInvalid)
				{
					MessageBox.Show("Webhook URL is not valid");
				}
			}else
			{
				try
				{
					CreatePaymentOrderResponse objPaymentResponse = objClass.createNewPaymentRequest(objPaymentRequest);
					MessageBox.Show("Order Id = " + objPaymentResponse.order.id);
				}
				catch (ArgumentNullException ex)
				{
					MessageBox.Show(ex.Message);
				}
				catch (WebException ex)
				{
					MessageBox.Show(ex.Message);
				}
				catch (IOException ex)
				{
					MessageBox.Show(ex.Message);
				}
				catch (InvalidPaymentOrderException ex)
				{
					if (!ex.IsWebhookValid())
					{
						MessageBox.Show("Webhook is invalid");
					}

					if (!ex.IsCurrencyValid())
					{
						MessageBox.Show("Currency is Invalid");
					}

					if (!ex.IsTransactionIDValid())
					{
						MessageBox.Show("Transaction ID is Inavlid");
					}
				}
				catch (ConnectionException ex)
				{
					MessageBox.Show(ex.Message);
				}
				catch (BaseException ex)
				{
					MessageBox.Show(ex.Message);
				}
				catch (Exception ex)
				{
					MessageBox.Show("Error:" + ex.Message);
				}
			}

		}


       static void CreatePaymentOrder_whenSameTransactionIdIsGiven(Instamojo objClass)
       {
           PaymentOrder objPaymentRequest = new PaymentOrder();
           //Required POST parameters
           objPaymentRequest.name = "ABCD";
           objPaymentRequest.email = "foo@example.com";
           objPaymentRequest.phone = "9969156561";
           objPaymentRequest.amount = 9;
           objPaymentRequest.currency = "USD";       
           objPaymentRequest.transaction_id = "test"; // duplicate Transaction Id
           objPaymentRequest.redirect_url = "https://swaggerhub.com/api/saich/pay-with-instamojo/1.0.0";    
           
               try
               {
                   CreatePaymentOrderResponse objPaymentResponse = objClass.createNewPaymentRequest(objPaymentRequest);
                   MessageBox.Show("Order Id = " + objPaymentResponse.order.id);
               }
               catch (ArgumentNullException ex)
               {
                   MessageBox.Show(ex.Message);
               }
               catch (WebException ex)
               {
                   MessageBox.Show(ex.Message);
               }
               catch (IOException ex)
               {
                   MessageBox.Show(ex.Message);
               }
               catch (InvalidPaymentOrderException ex)
               {
					if (!ex.IsWebhookValid())
					{
						MessageBox.Show("Webhook is invalid");
					}

					if (!ex.IsCurrencyValid())
					{
						MessageBox.Show("Currency is Invalid");
					}

					if (!ex.IsTransactionIDValid())
					{
						MessageBox.Show("Transaction ID is Inavlid");
					}
               }
               catch (ConnectionException ex)
               {
                   MessageBox.Show(ex.Message);
               }
               catch (BaseException ex)
               {
                   MessageBox.Show(ex.Message);
               }
               catch (Exception ex)
               {
                   MessageBox.Show("Error:" + ex.Message);
               }
           
       }

       static void GetAllPaymentOrdersList(Instamojo objClass)
       {
           try
           {
               PaymentOrderListRequest objPaymentOrderListRequest = new PaymentOrderListRequest();
               //Optional Parameters
               objPaymentOrderListRequest.limit = 21;
               objPaymentOrderListRequest.page = 3;

               PaymentOrderListResponse objPaymentRequestStatusResponse = objClass.getPaymentOrderList(objPaymentOrderListRequest);
               foreach (var item in objPaymentRequestStatusResponse.orders)
               {
                   Console.WriteLine(item.email + item.description + item.amount );
               }
               MessageBox.Show("Order List = " + objPaymentRequestStatusResponse.orders.Count());
           }
           catch (ArgumentNullException ex)
           {
               MessageBox.Show(ex.Message);
           }
           catch (WebException ex)
           {
               MessageBox.Show(ex.Message);
           }
           catch (Exception ex)
           {
               MessageBox.Show("Error:" + ex.Message);
           }
       }

       static void GetPaymentOrderDetailUsingOrderId(Instamojo objClass)
       {   
           try
           {
               PaymentOrderDetailsResponse objPaymentRequestDetailsResponse = objClass.getPaymentOrderDetails("3189cff7c68245bface8915cac1f89df"); //"3189cff7c68245bface8915cac1f89df");
               MessageBox.Show("Transaction Id = " + objPaymentRequestDetailsResponse.transaction_id);
           }
           catch (ArgumentNullException ex)
           {
               MessageBox.Show(ex.Message);
           }
           catch (WebException ex)
           {
               MessageBox.Show(ex.Message);
           }
           catch (Exception ex)
           {
               MessageBox.Show("Error:" + ex.Message);
           }
       }

       static void GetPaymentOrderDetailUsingOrderId_WhenOrderIdIsNull(Instamojo objClass)
       {
           try
           {
               PaymentOrderDetailsResponse objPaymentRequestDetailsResponse = objClass.getPaymentOrderDetails(null); //"3189cff7c68245bface8915cac1f89df");
               MessageBox.Show("Transaction Id = " + objPaymentRequestDetailsResponse.transaction_id);
           }
           catch (ArgumentNullException ex)
           {
               MessageBox.Show(ex.Message);
           }
           catch (WebException ex)
           {
               MessageBox.Show(ex.Message);
           }
           catch (Exception ex)
           {
               MessageBox.Show("Error:" + ex.Message);
           }
       }

       static void GetPaymentOrderDetailUsingOrderId_WhenOrderIdIsUnknown(Instamojo objClass)
       {
           try
           {
               PaymentOrderDetailsResponse objPaymentRequestDetailsResponse = objClass.getPaymentOrderDetails("3189cff7c68245bface8915ca"); //"3189cff7c68245bface8915cac1f89df");
               MessageBox.Show("Transaction Id = " + objPaymentRequestDetailsResponse.transaction_id);
           }
           catch (ArgumentNullException ex)
           {
               MessageBox.Show(ex.Message);
           }
           catch (WebException ex)
           {
               MessageBox.Show(ex.Message);
           }
           catch (Exception ex)
           {
               MessageBox.Show("Error:" + ex.Message);
           }
       }

       static void GetPaymentOrderDetailsUsingTransactionId(Instamojo objClass)
       {
           try
           {
               PaymentOrderDetailsResponse objPaymentRequestDetailsResponse = objClass.getPaymentOrderDetailsByTransactionId("test1");
               MessageBox.Show("Transaction Id = " + objPaymentRequestDetailsResponse.transaction_id);
           }
           catch (ArgumentNullException ex)
           {
               MessageBox.Show(ex.Message);
           }
           catch (WebException ex)
           {
               MessageBox.Show(ex.Message);
           }
           catch (Exception ex)
           {
               MessageBox.Show("Error:" + ex.Message);
           }
       }

       static void GetPaymentOrderDetailsUsingTransactionId_WhenTransactionIdIsUnknown(Instamojo objClass)
       {
           try
           {
               PaymentOrderDetailsResponse objPaymentRequestDetailsResponse = objClass.getPaymentOrderDetailsByTransactionId("Unknown");
               MessageBox.Show("Transaction Id = " + objPaymentRequestDetailsResponse.transaction_id);
           }
           catch (ArgumentNullException ex)
           {
               MessageBox.Show(ex.Message);
           }
           catch (WebException ex)
           {
               MessageBox.Show(ex.Message);
           }
           catch (Exception ex)
           {
               MessageBox.Show("Error:" + ex.Message);
           }
       }

       static void CreateRefund(Instamojo objClass)
       {
           Refund objRefundRequest = new Refund();
           //Required POST parameters
           //objPaymentRequest.name = "ABCD";
           objRefundRequest.payment_id = "MOJO6701005J41260385";
           objRefundRequest.type = "TNR";
           objRefundRequest.body = "abcd";
           objRefundRequest.refund_amount = 9;

           if (objRefundRequest.validate())
           {
               if (objRefundRequest.payment_idInvalid)
               {
                   MessageBox.Show("payment_id is not valid");
               }
           }
           else
           {
               try
               {
                   CreateRefundResponce objRefundResponse = objClass.createNewRefundRequest(objRefundRequest);
                   MessageBox.Show("Refund Id = " + objRefundResponse.refund.id);
               }
               catch (ArgumentNullException ex)
               {
                   MessageBox.Show(ex.Message);
               }
               catch (WebException ex)
               {
                   MessageBox.Show(ex.Message);
               }
               catch (IOException ex)
               {
                   MessageBox.Show(ex.Message);
               }
               catch (InvalidPaymentOrderException ex)
               {
                   MessageBox.Show(ex.Message);
               }
               catch (ConnectionException ex)
               {
                   MessageBox.Show(ex.Message);
               }
               catch (BaseException ex)
               {
                   MessageBox.Show(ex.Message);
               }
               catch (Exception ex)
               {
                   MessageBox.Show("Error:" + ex.Message);
               }
           }
       }
       static void CreateRefund_WhenInvalidRefundIsMade(Instamojo objClass)
       {
           Refund objRefundRequest = new Refund();
           objRefundRequest.payment_id = "MOJO6701005J41260385";
           objRefundRequest.type = "TNR";
           objRefundRequest.body = "abcd";
           objRefundRequest.refund_amount = 9;

           if (objRefundRequest.validate())
           {
               if (objRefundRequest.payment_idInvalid)
               {
                   MessageBox.Show("payment_id is not valid");
               }
               if (objRefundRequest.typeInvalid)
               {
                   MessageBox.Show("type is not valid");
               }
               if (objRefundRequest.refund_amountInvalid)
               {
                   MessageBox.Show("refund amount is not valid");
               }
           }else
			{
				try
				{
					CreateRefundResponce objRefundResponse = objClass.createNewRefundRequest(objRefundRequest);
					MessageBox.Show("Refund Id = " + objRefundResponse.refund.id);
				}
				catch (ArgumentNullException ex)
				{
					MessageBox.Show(ex.Message);
				}
				catch (WebException ex)
				{
					MessageBox.Show(ex.Message);
				}
				catch (IOException ex)
				{
					MessageBox.Show(ex.Message);
				}
				catch (InvalidPaymentOrderException ex)
				{
					MessageBox.Show(ex.Message);
				}
				catch (ConnectionException ex)
				{
					MessageBox.Show(ex.Message);
				}
				catch (BaseException ex)
				{
					MessageBox.Show(ex.Message);
				}
				catch (Exception ex)
				{
					MessageBox.Show("Error:" + ex.Message);
				}
			}
       }
      
    }
}
