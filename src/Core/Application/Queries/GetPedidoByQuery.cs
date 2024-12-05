using FoodOrder.Application.Output;
using MediatR;

namespace FoodOrder.Application.Queries
{
    public class GetPedidoByQuery : IRequest<List<PedidoOutput>>
    {
    }
}
