using Application.Commands;
using Application.UseCases.Clientes;
using Domain.Entities;
using MediatR;

namespace Application.Handlers
{
    public class AddClienteCommandHandler : IRequestHandler<AddClienteCommand, Cliente>
    {
        private readonly IClienteUseCase _clienteUseCase;

        public AddClienteCommandHandler(IClienteUseCase clienteUseCase)
        {
            _clienteUseCase = clienteUseCase;
        }

        public async Task<Cliente> Handle(AddClienteCommand request, CancellationToken cancellationToken)
        {
            var cliente = new Cliente(request.Cpf, request.Nome, request.Email);

            var clienteCadastrado = await _clienteUseCase.Cadastrar(cliente);

            return clienteCadastrado;
        }

    }
}
