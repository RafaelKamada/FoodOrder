using Application.Queries;
using Application.UseCases.Clientes;
using Domain.Entities;
using MediatR;

namespace Application.Handlers
{
    public class GetClienteByCpfQueryHandler : IRequestHandler<GetClienteByCpfQuery, Cliente>
    {
        private readonly IClienteUseCase _clienteUseCase;

        public GetClienteByCpfQueryHandler(IClienteUseCase clienteUseCase)
        {
            _clienteUseCase = clienteUseCase;
        }

        public async Task<Cliente> Handle(GetClienteByCpfQuery request, CancellationToken cancellationToken)
        {
            return await _clienteUseCase.ConsultarPorCpf(request.Cpf);
        }
    }
}
