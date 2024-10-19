using Application.Queries;
using Application.UseCases.Pedidos;
using Domain.Entities;
using MediatR;

namespace Application.Handlers
{
    public class GetPedidoByQueryHandler : IRequestHandler<GetPedidoByQuery, List<Pedido>>
    {
        private readonly IPedidoUseCase _pedidoUseCase;

        public GetPedidoByQueryHandler(IPedidoUseCase pedidoUseCase)
        {
            _pedidoUseCase = pedidoUseCase;
        }

        public async Task<List<Pedido>> Handle(GetPedidoByQuery request, CancellationToken cancellationToken)
        {
            return await _pedidoUseCase.ListarPedidos();
        }
    }
}
