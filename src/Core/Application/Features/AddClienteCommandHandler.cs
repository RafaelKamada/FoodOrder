using FoodOrder.Application.UseCases;
using FoodOrder.Domain.Entities;
using MediatR;

namespace FoodOrder.Application.Features;

public class AddClienteCommand : IRequest<Cliente>
{
    public required string Cpf { get; set; }
    public required string Nome { get; set; }
    public required string Email { get; set; }
}

public class AddClienteCommandHandler(IClienteUseCase clienteUseCase) : IRequestHandler<AddClienteCommand, Cliente>
{
    private readonly IClienteUseCase _clienteUseCase = clienteUseCase;

    public async Task<Cliente> Handle(AddClienteCommand request, CancellationToken cancellationToken)
    {
        var cliente = new Cliente(request.Cpf, request.Nome, request.Email);

        var clienteCadastrado = await _clienteUseCase.Cadastrar(cliente);

        return clienteCadastrado;
    }

}
