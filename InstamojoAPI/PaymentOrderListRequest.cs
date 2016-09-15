namespace InstamojoAPI
{
	public class PaymentOrderListRequest
	{
		public PaymentOrderListRequest()
		{
			// Default Values
			page = 1;
			limit = 50;
		}

		public string id { get; set; }
		public string transaction_id { get; set; }
		public int page { get; set; }
		public int limit { get; set; }
	}
}
