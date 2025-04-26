using FoodOrder.Application.UseCases;
using FoodOrder.Domain.Entities;
using MediatR;

namespace FoodOrder.Application.Features;

public class ClienteCollectionQuery(string cpf) : IRequest<Cliente>
{
    public string Cpf { get; } = cpf;
}

public class ClienteCollectionQueryHandler(IClienteUseCase clienteUseCase) : IRequestHandler<ClienteCollectionQuery, Cliente>
{
    private readonly IClienteUseCase _clienteUseCase = clienteUseCase;

    public async Task<Domain.Entities.Cliente> Handle(ClienteCollectionQuery request, CancellationToken cancellationToken)
    {
        return await _clienteUseCase.ConsultarPorCpf(request.Cpf);
    }
}
