namespace InstamojoAPI
{
    public class CreatePaymentOrderResponse
    {
        public Order order { get; set; }
        public PaymentOptions payment_options { get; set; }
    }
}
