using Application.Output;

namespace Application.UseCases.Pedidos
{
    public interface IPedidoUseCase
    {
        Task<List<PedidoOutput>> ListarPedidos();
    }
}
