namespace FoodOrder.Domain.Entities.Result
{
    public class PagamentoResult
    {
        public string PaymentId { get; set; }
        public string QrCode { get; set; }
        public string QrCodeUrl { get; set; }
        public bool Success { get; set; }
    }
}
