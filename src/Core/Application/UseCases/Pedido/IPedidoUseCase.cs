using FoodOrder.Application.Output;

namespace FoodOrder.Application.UseCases.Pedidos
{
    public interface IPedidoUseCase
    {
        Task<List<PedidoOutput>> ListarPedidos();
    }
}
