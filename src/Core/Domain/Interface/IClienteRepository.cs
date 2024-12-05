using FoodOrder.Domain.Entities;

namespace FoodOrder.Domain.Interface;

public interface IClienteRepository
{
    Task<Cliente> Cadastrar(Cliente cliente);
    Task<Cliente> ConsultarPorCpf(string cpf);
}
