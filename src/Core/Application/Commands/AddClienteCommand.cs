using MediatR;

namespace Application.Commands
{
    public class AddClienteCommand : IRequest<Unit>
    {
        public string Cpf { get; set; }
        public string Nome { get; set; }
        public string Email { get; set; }
    }
}
