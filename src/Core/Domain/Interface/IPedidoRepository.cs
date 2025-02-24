using FoodOrder.Domain.Entities;

namespace FoodOrder.Domain.Ports
{
    public interface IPedidoRepository
    {
        Task<int> Cadastrar(Pedido pedido);
        Task<List<Pedido>> ListarPedidos(); 
        Task<Pedido> ConsultarPedidoPorNumero(int numeroPedido);
        Task Atualizar(Pedido pedido);
    }
}
