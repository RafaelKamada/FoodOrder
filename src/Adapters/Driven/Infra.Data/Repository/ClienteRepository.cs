using Domain.Entities;
using Domain.Ports;
using Infra.Data.Context;
using Microsoft.EntityFrameworkCore;

namespace Infra.Data.Repository
{
    public class ClienteRepository : IClienteRepository
    {
        private readonly NpgsqlContext _context;

        public ClienteRepository(NpgsqlContext context)
        {
            _context = context;
        }

        public async Task<Cliente> Cadastrar(Cliente cliente)
        {
            if (cliente == null)
            {
                throw new ArgumentNullException(nameof(cliente));
            }

            _context.Clientes.Add(cliente);
            await _context.SaveChangesAsync();
            return cliente;
        }

        public async Task<Cliente> ConsultarPorCpf(string cpf)
        {
            var cliente = await _context.Clientes.FirstOrDefaultAsync(x => x.CPF == cpf);

            if (cliente == null)
            {
                throw new ArgumentNullException(nameof(cliente));
            }
            else
            {
                return cliente;
            }
        }
    }
}
