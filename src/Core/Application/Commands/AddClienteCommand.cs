using FoodOrder.Domain.Entities;
using MediatR;

namespace FoodOrder.Application.Commands
{
    public class AddClienteCommand : IRequest<Cliente>
    {
        public string Cpf { get; set; }
        public string Nome { get; set; }
        public string Email { get; set; }
    }
}
