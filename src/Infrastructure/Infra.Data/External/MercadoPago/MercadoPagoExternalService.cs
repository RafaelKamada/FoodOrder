using FoodOrder.Data.External.MercadoPago.Dto;
using FoodOrder.Domain.Entities;
using FoodOrder.Domain.Entities.Result;
using FoodOrder.Domain.Ports;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using System.Net.Http.Headers;
using System.Net.Http.Json;
using System.Text.Json;

namespace FoodOrder.Data.External.MercadoPago
{
    public class MercadoPagoExternalService : IMercadoPagoExternalService
    {
        private readonly HttpClient _httpClient;
        private readonly IConfiguration _configuration;
        private readonly ILogger<MercadoPagoExternalService> _logger;

        public MercadoPagoExternalService(
            HttpClient httpClient,
            IConfiguration configuration,
            ILogger<MercadoPagoExternalService> logger)
        {
            _httpClient = httpClient;
            _configuration = configuration;
            _logger = logger;
        }

        public async Task<PagamentoResult> CriaPagamentoAsync(decimal amount, string description)
        {
            try
            {
                var accessToken = _configuration["MercadoPago:AccessToken"];
                var url = _configuration["MercadoPago:EndPoints:CriarPagamento"];

                _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", accessToken);

                // Converte para o DTO específico do Mercado Pago
                var mercadoPagoRequest = ConvertToMercadoPagoRequest(amount, description);

                // Chama API externa
                var response = await _httpClient.PostAsJsonAsync(url, mercadoPagoRequest);
                response.EnsureSuccessStatusCode();

                var content = await response.Content.ReadAsStringAsync();
                var paymentResponse = JsonSerializer.Deserialize<MercadoPagoPagamentoResponse>(content);

                // Converte resposta da API para PaymentResult genérico
                return ConvertToPaymentResult(paymentResponse);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Erro ao gerar pagamento {amount} - {description}");
                throw;
            }

        }

        public async Task<PagamentoResult> CriaPagamentoAsync(Pedido pedido, decimal amount, string description)
        {
            try
            {
                var accessToken = _configuration["MercadoPago:AccessToken"];
                var url = _configuration["MercadoPago:EndPoints:CriarPagamento"]
                            .Replace("{{user_id}}", "183150839")
                            .Replace("{{external_pos_id}}", "FIAP001POS001");

                _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", accessToken);

                // Converte para o DTO específico do Mercado Pago
                var mercadoPagoRequest = ConvertToMercadoPagoRequest(amount, description, pedido);

                // Chama API externa
                var response = await _httpClient.PostAsJsonAsync(url, mercadoPagoRequest);
                response.EnsureSuccessStatusCode();

                var content = await response.Content.ReadAsStringAsync();
                //var paymentResponse = JsonSerializer.Deserialize<MercadoPagoPagamentoResponse>(content);
                var paymentResponse = JsonSerializer.Deserialize<CriarPagamentoResponse>(content);

                // Converte resposta da API para PaymentResult genérico
                return ConvertToPaymentResult(paymentResponse);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Erro ao gerar pagamento {amount} - {description}");
                throw;
            }
        }

        public async Task<PaymentDetails> GetPagamentoDetalhesAsync(string paymentId)
        {
            try
            {
                var accessToken = _configuration["MercadoPago:AccessToken"];
                var url = _configuration["MercadoPago:EndPoints:DetalhesPagamento"];
                //var url = $"https://api.mercadopago.com/v1/payments/{paymentId}";

                _httpClient.DefaultRequestHeaders.Authorization =
                    new AuthenticationHeaderValue("Bearer", accessToken);

                var response = await _httpClient.GetAsync(url);
                response.EnsureSuccessStatusCode();

                var content = await response.Content.ReadAsStringAsync();
                var externalDto = JsonSerializer.Deserialize<MercadoPagoPaymentDto>(content);

                // Mapeia para o domínio
                return new PaymentDetails
                {
                    Id = externalDto.Id,
                    Status = externalDto.Status.ToString(),
                    Amount = externalDto.Amount
                };
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Erro ao buscar detalhes do pagamento {paymentId}");
                throw;
            }
        }

        // Método de conversão para request específico
        private MercadoPagoPagamentoRequest ConvertToMercadoPagoRequest(decimal amount, string description)
        {
            return new MercadoPagoPagamentoRequest
            {
                transaction_amount = amount,
                description = description,
                payment_method_id = "pix",
                payer = new Payer { email = "cliente@exemplo.com" }
            };
        }

        // Método de conversão para request específico
        private CriarPagamentoRequest ConvertToMercadoPagoRequest(decimal amount, string description, Pedido pedido)
        {
            return new CriarPagamentoRequest
            {
                ExternalReference = pedido.NumeroPedido.ToString(),
                NotificationUrl = "https://www.yourdomain.com/ipn",
                TotalAmount = amount,
                Title = description,
                Description = description,
                Items = new List<MercadoPagoQrCodeItem>
                {
                    new MercadoPagoQrCodeItem
                    {
                        Title = "teste",
                        Quantity = 1,
                        UnitMeasure = "unit",
                        UnitPrice = amount,
                        TotalAmount = amount
                    }
                }
            };
        }

        // Método de conversão para result genérico
        private PagamentoResult ConvertToPaymentResult(MercadoPagoPagamentoResponse apiResponse)
        {
            return new PagamentoResult
            {
                PaymentId = apiResponse.id,
                QrCode = apiResponse.point_of_interaction?.transaction_data?.qr_code,
                QrCodeUrl = apiResponse.point_of_interaction?.transaction_data?.qr_code_base64,
                Success = apiResponse.status == "approved"
            };
        }

        // Método de conversão para result genérico
        private PagamentoResult ConvertToPaymentResult(CriarPagamentoResponse apiResponse)
        {
            return new PagamentoResult
            {
                PaymentId = apiResponse.in_store_order_id,
                QrCode = apiResponse.qr_data
            };
        }
    }
}
