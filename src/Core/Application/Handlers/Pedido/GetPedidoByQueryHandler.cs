using FoodOrder.Application.Output;
using FoodOrder.Application.Queries;
using FoodOrder.Application.UseCases.Pedidos;
using MediatR;

namespace FoodOrder.Application.Handlers.Pedido
{
    public class GetPedidoByQueryHandler : IRequestHandler<GetPedidoByQuery, PedidosOutput>
    {
        private readonly IPedidoUseCase _pedidoUseCase;

        public GetPedidoByQueryHandler(IPedidoUseCase pedidoUseCase)
        {
            _pedidoUseCase = pedidoUseCase;
        }

        public async Task<PedidosOutput> Handle(GetPedidoByQuery request, CancellationToken cancellationToken)
        {
            return await _pedidoUseCase.ListarPedidos();
        }
    }
}
