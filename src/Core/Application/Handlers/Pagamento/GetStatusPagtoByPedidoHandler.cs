using FoodOrder.Application.Queries;
using FoodOrder.Application.UseCases.Pagamento;
using FoodOrder.Domain.Entities;
using MediatR;

namespace FoodOrder.Application.Handlers.Pagamento
{
    public class GetStatusPagtoByPedidoHandler : IRequestHandler<GetStatusPagtoByPedidoQuery, Domain.Entities.PagamentoStatus>
    {
        private readonly IPagamentoUseCase _pagamentoUseCase;

        public GetStatusPagtoByPedidoHandler(IPagamentoUseCase pagamentoStatusUseCase)
        {
            _pagamentoUseCase = pagamentoStatusUseCase;
        }

        public async Task<PagamentoStatus> Handle(GetStatusPagtoByPedidoQuery request, CancellationToken cancellationToken)
        {
            return await _pagamentoUseCase.ConsultarStatusPagamento(request.NumeroPedido);
        }
    }
}
