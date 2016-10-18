using System;
using System.Web.Script.Serialization;

namespace InstamojoAPI
{
    public class InvalidPaymentOrderException : BaseException
    {
		private InvalidOrderResponse errorResponse;

        public InvalidPaymentOrderException()
        {  }

        public InvalidPaymentOrderException(string message)
			: base(message)
        {
			try
			{
				JavaScriptSerializer ser = new JavaScriptSerializer();
				errorResponse = ser.Deserialize<InvalidOrderResponse>(message);
			}
			catch (Exception)
			{
				//nothing comes here since it failed everywhere
			}
		}

		public bool IsWebhookValid()
		{
			if (errorResponse == null)
			{
				return true;
			}

			if (errorResponse.webhook_url != null)
			{
				return false;
			}

			return true;
		}

		public bool IsTransactionIDValid()
		{
			if (errorResponse == null)
			{
				return true;
			}

			if (errorResponse.transaction_id != null)
			{
				return false;
			}

			return true;
		}

		public bool IsCurrencyValid()
		{
			if (errorResponse == null)
			{
				return true;
			}

			if (errorResponse.currency != null)
			{
				return false;
			}

			return true;
		}
              
    }

	class InvalidOrderResponse
	{
		public string[] transaction_id { get; set; }
		public string[] webhook_url { get; set; }
		public string[] currency { get; set; }
	}
}
