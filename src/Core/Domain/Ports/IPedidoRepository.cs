using Domain.Entities;

namespace Domain.Ports
{
    public interface IPedidoRepository
    {
        Task<Pedido> Cadastrar(Pedido pedido);
        Task<List<Pedido>> ListarPedidos();
    }
}
