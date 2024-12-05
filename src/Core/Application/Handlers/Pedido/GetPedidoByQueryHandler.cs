using FoodOrder.Application.Output;
using FoodOrder.Application.Queries;
using FoodOrder.Application.UseCases.Pedidos;
using MediatR;

namespace FoodOrder.Application.Handlers.Pedido
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
