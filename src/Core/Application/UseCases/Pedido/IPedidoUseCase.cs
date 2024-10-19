using Domain.Entities;

namespace Application.UseCases.Pedidos
{
    public interface IPedidoUseCase
    {
        Task<List<Pedido>> ListarPedidos();
    }
}
