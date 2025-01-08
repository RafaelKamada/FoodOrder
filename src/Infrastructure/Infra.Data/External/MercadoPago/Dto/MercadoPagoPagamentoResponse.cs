namespace FoodOrder.Data.External.MercadoPago.Dto
{
    public class MercadoPagoPagamentoResponse
    {
        public string id { get; set; }
        public string status { get; set; }
        public Point_of_interaction point_of_interaction { get; set; }
    }
    public class Point_of_interaction
    {
        public Transaction_data transaction_data { get; set; }
    }

    public class Transaction_data
    {
        public string qr_code { get; set; }
        public string qr_code_base64 { get; set; }
    }
}
