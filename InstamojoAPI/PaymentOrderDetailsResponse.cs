namespace InstamojoAPI
{
	public class PaymentOrderDetailsResponse
	{
		public PaymentOrderDetailsResponse()
		{
			status = "pending";
			currency = "INR";
		}

		public string id { get; set; }
		public string transaction_id { get; set; }
		public string status { get; set; }
		public string currency { get; set; }
		public decimal? amount { get; set; }
		public string name { get; set; }
		public string email { get; set; }
		public string phone { get; set; }
		public string description { get; set; }
		public string redirect_url { get; set; }

		public object payments { get; set; }

		public string created_at { get; set; }
		public string resource_uri { get; set; }
	}
}
