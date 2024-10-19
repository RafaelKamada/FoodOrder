using Application.Commands;
using Application.UseCases.Clientes;
using Domain.Entities;
using MediatR;

namespace Application.Handlers
{
    public class AddClienteCommandHandler : IRequestHandler<AddClienteCommand, Unit>
    {
        private readonly IClienteUseCase _clienteUseCase;

        public AddClienteCommandHandler(IClienteUseCase clienteUseCase)
        {
            _clienteUseCase = clienteUseCase;
        }

        public async Task<Unit> Handle(AddClienteCommand request, CancellationToken cancellationToken)
        {
            var cliente = new Cliente(request.Cpf, request.Nome, request.Email);

            var clienteBase = await _clienteUseCase.ConsultarPorCpf(request.Cpf);
            
            if (clienteBase != null)
            {
                throw new Exception("CPF ja cadastrado!");
            }

            await _clienteUseCase.Cadastrar(cliente);

            return Unit.Value;
        }

    }
}
