using FoodOrder.Domain.Interface;
using FoodOrder.Infra.Data.Context;
using Microsoft.EntityFrameworkCore;

namespace FoodOrder.Data.Repositorio.Cliente
{
    public class ClienteRepository : IClienteRepository
    {
        private readonly NpgsqlContext _context;

        public ClienteRepository(NpgsqlContext context)
        {
            _context = context;
        }

        public async Task<Domain.Entities.Cliente> Cadastrar(Domain.Entities.Cliente cliente)
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

        public async Task<Domain.Entities.Cliente> ConsultarPorCpf(string cpf)
        {
            var cliente = await _context.Clientes.FirstOrDefaultAsync(x => x.Cpf == cpf);
            return cliente;
        }
    }
}
