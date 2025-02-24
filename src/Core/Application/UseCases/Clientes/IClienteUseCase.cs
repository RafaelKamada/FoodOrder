using FoodOrder.Domain.Entities;

namespace FoodOrder.Application.UseCases.Clientes
{
    public interface IClienteUseCase
    {
        Task<Cliente> Cadastrar(Cliente cliente);
        Task<Cliente> ConsultarPorCpf(string cpf);
    }
}
