using FoodOrder.Application.Output;

namespace FoodOrder.Application.UseCases.Pedidos
{
    public interface IPedidoUseCase
    {
        Task<PedidosOutput> ListarPedidos();
        Task<PedidoOutput> Consultar(int numeroPedido);
        Task<PedidoStatusOutput> ConsultarStatus(string status);
        Task Atualizar(PedidoOutput pedido);
    }
}
