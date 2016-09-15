using System.Linq;

namespace InstamojoAPI
{
	public class Refund
	{
		public Refund()
		{
			// Default Values
			total_amount = 9;
		}

		private static string[] typeArray = { "RFD", "TNR", "QFL", "QNR", "EWN", "TAN", "PTH" };
		private static double MIN_AMOUNT = 9.00;

		public string id { get; set; }
		public string payment_id { get; set; }
		public string status { get; set; }
		public string type { get; set; }
		public string body { get; set; }
		public double? refund_amount { get; set; }
		public double? total_amount { get; set; }
		public string created_at { get; set; }


		public bool idInvalid;
		public bool payment_idInvalid;
		public bool statusInvalid;
		public bool typeInvalid;
		public bool bodyInvalid;
		public bool refund_amountInvalid;
		public bool total_amountInvalid;
		public bool created_atInvalid;

		/**
		* Validate.
		*/
		public bool validate()
		{
			bool invalid = false;

			if (string.IsNullOrEmpty(payment_id))
			{
				invalid = true;
				payment_idInvalid = true;
			}
			if (string.IsNullOrEmpty(type) || !typeArray.Any(type.Contains))
			{
				invalid = true;
				typeInvalid = true;
			}
			if (string.IsNullOrEmpty(body))
			{
				invalid = true;
				bodyInvalid = true;
			}
			if (refund_amount == null || refund_amount < MIN_AMOUNT)
			{
				invalid = true;
				refund_amountInvalid = true;
			}
			return invalid;
		}

	}
}
