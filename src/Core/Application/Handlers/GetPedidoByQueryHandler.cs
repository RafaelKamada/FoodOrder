using Application.Output;
using Application.Queries;
using Application.UseCases.Pedidos;
using MediatR;

namespace Application.Handlers
{
    public class GetPedidoByQueryHandler : IRequestHandler<GetPedidoByQuery, List<PedidoOutput>>
    {
        private readonly IPedidoUseCase _pedidoUseCase;

        public GetPedidoByQueryHandler(IPedidoUseCase pedidoUseCase)
        {
            _pedidoUseCase = pedidoUseCase;
        }

        public async Task<List<PedidoOutput>> Handle(GetPedidoByQuery request, CancellationToken cancellationToken)
        {
            return await _pedidoUseCase.ListarPedidos();
        }
    }
}
