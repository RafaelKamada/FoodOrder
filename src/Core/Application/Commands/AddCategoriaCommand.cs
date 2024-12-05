using MediatR;

namespace FoodOrder.Application.Commands
{
    public class AddCategoriaCommand : IRequest<Unit>
    {
        public string Nome { get; set; }
        public string Tipo { get; set; }
    }
}
