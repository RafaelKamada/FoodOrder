using Domain.Entities;
using Domain.Ports;

namespace Application.UseCases.Pedidos
{
    public class PedidoUseCase : IPedidoUseCase
    {
        private readonly IPedidoRepository _pedidosRepository;

        public PedidoUseCase(IPedidoRepository pedidosRepository)
        {
            _pedidosRepository = pedidosRepository;
        }

        public Task<List<Pedido>> ListarPedidos()
        {
            return _pedidosRepository.ListarPedidos();
        }
    }
}
