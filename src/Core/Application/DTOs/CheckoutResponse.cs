namespace FoodOrder.Application.DTOs
{
    public class CheckoutResponse
    {
        public int NumeroPedido { get; set; }
        public string QrCode { get; set; }
        public string QrCodeUrl { get; set; }
    }
}
