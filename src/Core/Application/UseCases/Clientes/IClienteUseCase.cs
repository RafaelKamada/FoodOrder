using Domain.Entities;

namespace Application.UseCases.Clientes
{
    public interface IClienteUseCase
    {
        Task<Cliente> Cadastrar(Cliente cliente);
        Task<Cliente> ConsultarPorCpf(string cpf);
    }
}
