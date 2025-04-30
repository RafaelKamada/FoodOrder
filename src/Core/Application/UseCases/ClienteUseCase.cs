using FoodOrder.Domain.Entities;
using FoodOrder.Domain.Interface;

namespace FoodOrder.Application.UseCases;

public class ClienteUseCase(IClienteRepository clienteRepository) : IClienteUseCase
{
    private readonly IClienteRepository _clienteRepository = clienteRepository;

    public async Task<Cliente> Cadastrar(Cliente cliente)
    {
        return await _clienteRepository.Cadastrar(cliente);
    }

    public async Task<Cliente> ConsultarPorCpf(string cpf)
    {
        var cliente = await _clienteRepository.ConsultarPorCpf(cpf);

        return cliente ?? throw new ArgumentException($"CPF {cpf} não localizado no banco de dados!");
    }
}
