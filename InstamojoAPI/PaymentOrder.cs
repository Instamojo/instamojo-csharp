using System.Linq;
using System.Text.RegularExpressions;

namespace InstamojoAPI
{
	public class PaymentOrder
	{
		public PaymentOrder()
		{
			currency = "INR";
		}

		/** The Constant serialVersionUID. */
		private static long serialVersionUID = 4912793214890694717L;

		private static Regex TRANSACTION_ID_MATCHER = new Regex("[A-Za-z0-9_-]+");
		private static Regex EMAIL_MATCHER = new Regex("^[a-zA-Z0-9.!#$%&'*+/=?^_`{|}~-]+@((\\[[0-9]{1,3}\\.[0-9]{1,3}\\.[0-9]{1,3}\\.[0-9]{1,3}\\])|(([a-zA-Z\\-0-9]+\\.)+[a-zA-Z]{2,}))$");
		private static Regex PHONE_NUMBER_MATCHER = new Regex("^[0-9]{10}$");
		private static Regex URL_MATCHER = new Regex("^(https?|ftp|file)://[-a-zA-Z0-9+&@#/%?=~_|!:,.;]*[-a-zA-Z0-9+&@#/%=~_|]");
		private static double MIN_AMOUNT = 9.00;
		private static int MAX_TID_CHAR_LIMIT = 64;
		private static int MAX_EMAIL_CHAR_LIMIT = 75;
		private static int MAX_NAME_CHAR_LIMIT = 100;
		private static int MAX_DESCRIPTION_CHAR_LIMIT = 255;
		private static string[] CurrencyArray = { "INR", "USD" };


		//Required POST parameters
		public string name { get; set; }
		public string email { get; set; }
		public string phone { get; set; }
		public double? amount { get; set; }
		public string transaction_id { get; set; }
		public string redirect_url { get; set; }
		public string webhook_url { get; set;}
		public string currency { get; set; }

		//Extra POST parameters 

		public string description { get; set; }


		public bool nameInvalid;
		public bool emailInvalid;
		public bool phoneInvalid;
		public bool transactionIdInvalid;
		public bool descriptionInvalid;
		public bool currencyInvalid;
		public bool amountInvalid;
		public bool redirectUrlInvalid;
		public bool webhookUrlInvalid;


		/**
     * Validate.
     */
		public bool validate()
		{
			bool invalid = false;

			if (string.IsNullOrEmpty(transaction_id) || !TRANSACTION_ID_MATCHER.IsMatch(transaction_id) || transaction_id.Length > MAX_TID_CHAR_LIMIT)
			{
				invalid = true;
				transactionIdInvalid = true;
			}
			if (string.IsNullOrEmpty(email) || !EMAIL_MATCHER.IsMatch(email) || email.Length > MAX_EMAIL_CHAR_LIMIT)
			{
				invalid = true;
				emailInvalid = true;
			}

			if (string.IsNullOrEmpty(name) || name.Length > MAX_NAME_CHAR_LIMIT)
			{
				invalid = true;
				nameInvalid = true;
			}
			if (string.IsNullOrEmpty(currency) || !CurrencyArray.Any(currency.Contains))
			{
				invalid = true;
				currencyInvalid = true;
			}
			if (string.IsNullOrEmpty(phone) || !PHONE_NUMBER_MATCHER.IsMatch(phone))
			{
				invalid = true;
				phoneInvalid = true;
			}
			if (amount == null || amount < MIN_AMOUNT)
			{
				invalid = true;
				amountInvalid = true;
			}
			if (!string.IsNullOrEmpty(description) && description.Length > MAX_DESCRIPTION_CHAR_LIMIT)
			{
				invalid = true;
				descriptionInvalid = true;
			}
			if (string.IsNullOrEmpty(redirect_url) || !URL_MATCHER.IsMatch(redirect_url))
			{
				invalid = true;
				redirectUrlInvalid = true;
			}
			if (!string.IsNullOrEmpty(webhook_url) && !URL_MATCHER.IsMatch(webhook_url))
			{
				invalid = true;
				webhookUrlInvalid = true;
			}
				
			return invalid;
		}

	}
}
