using Application.Queries;
using Domain.Entities;
using Domain.Ports;
using MediatR;

namespace Application.Handlers
{
    public class GetPedidoByQueryHandler : IRequestHandler<GetPedidoByQuery, List<Pedido>>
    {
        private readonly IPedidoRepository _pedidoRepository;

        public GetPedidoByQueryHandler(IPedidoRepository pedidoRepository)
        {
            _pedidoRepository = pedidoRepository;
        }

        public async Task<List<Pedido>> Handle(GetPedidoByQuery request, CancellationToken cancellationToken)
        {
            return await _pedidoRepository.ListarPedidos();
        }
    }
}
