using FoodOrder.Application.UseCases.Clientes;
using FoodOrder.Application.Commands;
using MediatR;

namespace FoodOrder.Application.Handlers.Cliente
{
    public class AddClienteCommandHandler : IRequestHandler<AddClienteCommand, Domain.Entities.Cliente>
    {
        private readonly IClienteUseCase _clienteUseCase;

        public AddClienteCommandHandler(IClienteUseCase clienteUseCase)
        {
            _clienteUseCase = clienteUseCase;
        }

        public async Task<Domain.Entities.Cliente> Handle(AddClienteCommand request, CancellationToken cancellationToken)
        {
            var cliente = new Domain.Entities.Cliente(request.Cpf, request.Nome, request.Email);

            var clienteCadastrado = await _clienteUseCase.Cadastrar(cliente);

            return clienteCadastrado;
        }

    }
}
