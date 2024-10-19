using Domain.Entities;

namespace Domain.Ports
{
    public interface IPedidoRepository
    {
        Task<List<Pedido>> ListarPedidos();
    }
}
