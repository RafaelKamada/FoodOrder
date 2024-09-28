using Domain.Entities;
using Domain.Ports;

namespace Application.UseCases.Clientes
{
    public class ClienteUseCase : IClienteUseCase
    {
        private readonly IClienteRepository _clienteRepository;

        public ClienteUseCase(IClienteRepository clienteRepository)
        {
            _clienteRepository = clienteRepository;
        }

        public Task<Cliente> Cadastrar(Cliente cliente)
        {
            return _clienteRepository.Cadastrar(cliente);
        }

        public Task<Cliente> ConsultarPorCpf(string cpf)
        {
            return _clienteRepository.ConsultarPorCpf(cpf);
        }
    }
}
