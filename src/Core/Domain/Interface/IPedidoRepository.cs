using FoodOrder.Domain.Entities;

namespace FoodOrder.Domain.Ports
{
    public interface IPedidoRepository
    {
        Task<Pedido> Cadastrar(Pedido pedido);
        Task<List<Pedido>> ListarPedidos();
    }
}
