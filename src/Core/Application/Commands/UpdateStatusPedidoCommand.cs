using MediatR;

namespace FoodOrder.Application.Commands
{
    public class UpdateStatusPedidoCommand : IRequest<Unit>
    {
        public int NumeroPedido { get; set; }
        public string Status { get; set; }
    }
}
