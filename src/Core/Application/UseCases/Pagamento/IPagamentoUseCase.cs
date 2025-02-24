using FoodOrder.Domain.Entities;

namespace FoodOrder.Application.UseCases.Pagamento
{
    public interface IPagamentoUseCase
    {
        Task<PagamentoStatus> ConsultarStatusPagamento(int numeroPedido);
    }
}