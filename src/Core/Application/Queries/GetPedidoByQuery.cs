using Domain.Entities;
using MediatR;

namespace Application.Queries
{
    public class GetPedidoByQuery : IRequest<List<Pedido>>
    {
    }
}
