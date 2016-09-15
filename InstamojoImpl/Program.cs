using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Net;
using InstamojoAPI;

namespace InstamojoImpl
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
       
        static void Main1()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            string Insta_client_id = "tmLkZZ0zV41nJwhayBGBOI4m4I7bH55qpUBdEXGS",
				   Insta_client_secret = "IDejdccGqKaFlGav9bntKULvMZ0g7twVFolC9gdrh9peMS0megSFr7iDpWwWIDgFUc3W5SlX99fKnhxsoy6ipdAv9JeQwebmOU6VRvOEQnNMWwZnWglYmDGrfgKRheXs",
                   Insta_Endpoint = InstamojoConstants.INSTAMOJO_API_ENDPOINT,
                   Insta_Auth_Endpoint = InstamojoConstants.INSTAMOJO_AUTH_ENDPOINT;
            try
            {
                Instamojo objClass = InstamojoImplementation.getApi(Insta_client_id, Insta_client_secret, Insta_Endpoint, Insta_Auth_Endpoint);

                # region   1. Create Payment Order
                //  Create Payment Order
                //PaymentOrder objPaymentRequest = new PaymentOrder();
                ////Required POST parameters
                //objPaymentRequest.name = "ABCD";
                //objPaymentRequest.email = "foo@example.com";
                //objPaymentRequest.phone = "9969156561";
                //objPaymentRequest.amount = 9;
                //objPaymentRequest.currency = "Unsupported";

                //string randomName = Path.GetRandomFileName();
                //randomName = randomName.Replace(".", string.Empty);
                //objPaymentRequest.transaction_id = "test";

                //objPaymentRequest.redirect_url = "https://swaggerhub.com/api/saich/pay-with-instamojo/1.0.0";
                ////Extra POST parameters 

                //if (objPaymentRequest.validate())
                //{

                //    if (objPaymentRequest.nameInvalid)
                //    {
                //        MessageBox.Show("Name is not valid");
                //    }

                //}
                //else
                //{
                //    try
                //    {
                //        CreatePaymentOrderResponse objPaymentResponse = objClass.createNewPaymentRequest(objPaymentRequest);
                //        MessageBox.Show("Order Id = " + objPaymentResponse.order.id);
                //    }
                //    catch (ArgumentNullException ex)
                //    {
                //        MessageBox.Show(ex.Message);
                //    }
                //    catch (WebException ex)
                //    {
                //        MessageBox.Show(ex.Message);
                //    }
                //    catch (IOException ex)
                //    {
                //        MessageBox.Show(ex.Message);
                //    }
                //    catch (InvalidPaymentOrderException ex)
                //    {
                //        MessageBox.Show(ex.Message);
                //    }
                //    catch (ConnectionException ex)
                //    {
                //        MessageBox.Show(ex.Message);
                //    }
                //    catch (BaseException ex)
                //    {
                //        MessageBox.Show(ex.Message);
                //    }
                //    catch (Exception ex)
                //    {
                //        MessageBox.Show("Error:" + ex.Message);
                //    }
                //}
                #endregion

                # region   2. Get All your Payment Orders List
                //  Get All your Payment Orders
                //try
                //{
                //    PaymentOrderListRequest objPaymentOrderListRequest = new PaymentOrderListRequest();
                //    //Optional Parameters
                //    objPaymentOrderListRequest.limit = 21;
                //    objPaymentOrderListRequest.page = 3;

                //    PaymentOrderListResponse objPaymentRequestStatusResponse = objClass.getPaymentOrderList(objPaymentOrderListRequest);
                //    foreach (var item in objPaymentRequestStatusResponse.orders)
                //    {
                //        Console.WriteLine(item.email + item.description + item.amount);
                //    }
                //    MessageBox.Show("Order List = " + objPaymentRequestStatusResponse.orders.Count());
                //}
                //catch (ArgumentNullException ex)
                //{
                //    MessageBox.Show(ex.Message);
                //}
                //catch (WebException ex)
                //{
                //    MessageBox.Show(ex.Message);
                //}
                //catch (Exception ex)
                //{
                //    MessageBox.Show("Error:" + ex.Message);
                //}
                #endregion

                # region   3. Get details of this payment order Using Order Id
                ////  Get details of this payment order
                //try
                //{
                //    PaymentOrderDetailsResponse objPaymentRequestDetailsResponse = objClass.getPaymentOrderDetails("3189cff7c68245bface8915cac1f"); //"3189cff7c68245bface8915cac1f89df");
                //    MessageBox.Show("Transaction Id = " + objPaymentRequestDetailsResponse.transaction_id);
                //}
                //catch (ArgumentNullException ex)
                //{
                //    MessageBox.Show(ex.Message);
                //}
                //catch (WebException ex)
                //{
                //    MessageBox.Show(ex.Message);
                //}
                //catch (Exception ex)
                //{
                //    MessageBox.Show("Error:" + ex.Message);
                //}
                #endregion

                # region   4. Get details of this payment order Using TransactionId
                ////  Get details of this payment order Using TransactionId
                //try
                //{
                //    PaymentOrderDetailsResponse objPaymentRequestDetailsResponse = objClass.getPaymentOrderDetailsByTransactionId("test1");
                //    MessageBox.Show("Transaction Id = " + objPaymentRequestDetailsResponse.transaction_id);
                //}
                //catch (ArgumentNullException ex)
                //{
                //    MessageBox.Show(ex.Message);
                //}
                //catch (WebException ex)
                //{
                //    MessageBox.Show(ex.Message);
                //}
                //catch (Exception ex)
                //{
                //    MessageBox.Show("Error:" + ex.Message);
                //}
                #endregion

                # region   5. Create Refund
                //  Create Payment Order
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
                #endregion

                Application.Run();

            }
            catch (BaseException ex)
            {
                MessageBox.Show("CustomException" + ex.Message);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Exception" + ex.Message);
            }
        }
    }

}
