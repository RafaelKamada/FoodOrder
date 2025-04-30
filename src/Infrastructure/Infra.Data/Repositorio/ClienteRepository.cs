using FoodOrder.Data.Context;
using FoodOrder.Domain.Entities;
using FoodOrder.Domain.Interface;
using Microsoft.EntityFrameworkCore;

namespace FoodOrder.Data.Repositorio;

public class ClienteRepository(NpgsqlContext context) : IClienteRepository
{
    private readonly NpgsqlContext _context = context;

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
                throw new Exception("CPF já está cadastrado.");
            }
            throw;
        }
    }

    public async Task<Cliente> ConsultarPorCpf(string cpf)
    {
        var cliente = await _context.Clientes.FirstOrDefaultAsync(x => x.Cpf == cpf);
        return cliente ?? new Cliente();
    }
}
