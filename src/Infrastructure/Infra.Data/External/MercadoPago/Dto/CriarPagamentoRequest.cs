using System.Text.Json.Serialization;

namespace FoodOrder.Data.External.MercadoPago.Dto
{
    public class CriarPagamentoRequest
    {
        [JsonPropertyName("external_reference")]
        public string ExternalReference { get; set; }

        [JsonPropertyName("notification_url")]
        public string NotificationUrl { get; set; }

        [JsonPropertyName("total_amount")]
        public decimal TotalAmount { get; set; }

        [JsonPropertyName("items")]
        public List<MercadoPagoQrCodeItem> Items { get; set; }

        [JsonPropertyName("title")]
        public string Title { get; set; }

        [JsonPropertyName("description")]
        public string Description { get; set; }
    }

    public class MercadoPagoQrCodeItem
    {
        [JsonPropertyName("sku_number")]
        public string SkuNumber { get; set; }

        [JsonPropertyName("category")]
        public string Category { get; set; }

        [JsonPropertyName("title")]
        public string Title { get; set; }

        [JsonPropertyName("description")]
        public string Description { get; set; }

        [JsonPropertyName("quantity")]
        public int Quantity { get; set; }

        [JsonPropertyName("unit_measure")]
        public string UnitMeasure { get; set; }

        [JsonPropertyName("unit_price")]
        public decimal UnitPrice { get; set; }

        [JsonPropertyName("total_amount")]
        public decimal TotalAmount { get; set; }
    }
}
