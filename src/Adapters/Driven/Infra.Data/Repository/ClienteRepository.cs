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
            try
            {
                _context.Clientes.Add(cliente);
                await _context.SaveChangesAsync();
                return cliente;
            }
            catch (DbUpdateException dbEx)
            {
                if (dbEx.InnerException != null && dbEx.InnerException.Message.Contains("UN_Cliente_Cpf"))
                {
                    // Tratar o erro de CPF duplicado
                    throw new Exception("CPF já está cadastrado.");
                }
                throw;
            }
        }

        public async Task<Cliente> ConsultarPorCpf(string cpf)
        {
            var cliente = await _context.Clientes.FirstOrDefaultAsync(x => x.Cpf == cpf);
            return cliente;
        }
    }
}
