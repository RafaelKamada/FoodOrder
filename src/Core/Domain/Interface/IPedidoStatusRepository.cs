using FoodOrder.Domain.Entities;

namespace FoodOrder.Domain.Ports
{
    public interface IPedidoStatusRepository
    {
        Task<PedidoStatus> Cadastrar(PedidoStatus pedidoStatus);

        Task<PedidoStatus> ConsultarPorId(int id);
    }
}
