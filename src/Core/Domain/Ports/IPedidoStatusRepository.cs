using Domain.Entities;

namespace Domain.Ports
{
    public interface IPedidoStatusRepository
    {
        Task<PedidoStatus> Cadastrar(PedidoStatus pedidoStatus);
    }
}
