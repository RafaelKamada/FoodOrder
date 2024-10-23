using Application.Output;
using MediatR;

namespace Application.Queries
{
    public class GetPedidoByQuery : IRequest<List<PedidoOutput>>
    {
    }
}
