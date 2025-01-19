using FoodOrder.Domain.Entities;
using FoodOrder.Domain.Entities.Result;

namespace FoodOrder.Domain.Ports
{
    public interface IMercadoPagoExternalService
    {
        Task<PaymentDetails> GetPagamentoDetalhesAsync(string paymentId);
        Task<PagamentoResult> CriaPagamentoAsync(decimal amount, string description);
        Task<PagamentoResult> CriaPagamentoAsync(Pedido pedido, decimal amount, string description);
    }
}
