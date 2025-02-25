using FoodOrder.Domain.Entities;
using MediatR;

namespace FoodOrder.Application.Queries
{
    public class GetStatusPagtoByPedidoQuery : IRequest<PagamentoStatus>
    {
        public int NumeroPedido { get; }

        public GetStatusPagtoByPedidoQuery(int numeroPedido)
        {
            NumeroPedido = numeroPedido;
        }
    }
}