namespace FoodOrder.Data.External.MercadoPago.Dto
{
    public class MercadoPagoPagamentoRequest
    {
        public decimal transaction_amount { get; set; }
        public string description { get; set; }
        public string payment_method_id { get; set; }
        public Payer payer { get; set; }
    }
    public class Payer
    {
        public string email { get; set; }
    }
}
