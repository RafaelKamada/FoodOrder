namespace FoodOrder.Domain.Entities
{
    public class PaymentDetails
    {
        public string Id { get; set; }
        public string Status { get; set; }
        public decimal Amount { get; set; }
    }
}
