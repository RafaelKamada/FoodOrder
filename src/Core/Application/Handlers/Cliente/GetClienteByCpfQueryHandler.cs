using FoodOrder.Application.Queries;
using FoodOrder.Application.UseCases.Clientes;
using FoodOrder.Domain.Entities;
using MediatR;

namespace FoodOrder.Application.Handlers.Cliente
{
    public class GetClienteByCpfQueryHandler : IRequestHandler<GetClienteByCpfQuery, Domain.Entities.Cliente>
    {
        private readonly IClienteUseCase _clienteUseCase;

        public GetClienteByCpfQueryHandler(IClienteUseCase clienteUseCase)
        {
            _clienteUseCase = clienteUseCase;
        }

        public async Task<Domain.Entities.Cliente> Handle(GetClienteByCpfQuery request, CancellationToken cancellationToken)
        {
            return await _clienteUseCase.ConsultarPorCpf(request.Cpf);
        }
    }
}
