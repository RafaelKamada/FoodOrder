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

        public async Task<Cliente> Cadastrar(Cliente cliente)
        {
            return await _clienteRepository.Cadastrar(cliente);
        }

        public async Task<Cliente> ConsultarPorCpf(string cpf)
        {
            var cliente = await _clienteRepository.ConsultarPorCpf(cpf);

            if (cliente == null) throw new ArgumentException($"CPF {cpf} não localizado no banco de dados!");

            return cliente;
        }
    }
}
