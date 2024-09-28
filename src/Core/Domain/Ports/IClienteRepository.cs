using Domain.Entities;

namespace Domain.Ports;

public interface IClienteRepository
{
    Task<Cliente> Cadastrar(Cliente cliente);
    Task<Cliente> ConsultarPorCpf(string cpf);
}
