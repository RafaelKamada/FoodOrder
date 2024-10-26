using Domain.Entities;
using Domain.Ports;
using Infra.Data.Context;
using Microsoft.EntityFrameworkCore;

namespace Infra.Data.Repository
{
    public class SacolaProdutoRepository : ISacolaProdutoRepository
    {
        private readonly NpgsqlContext _context;

        public SacolaProdutoRepository(NpgsqlContext context)
        {
            _context = context;
        }

        public async Task<List<SacolaProduto>> ConsultarPorSacola(int id)
        {
            var sacolaProduto = await _context.SacolasProdutos
               .Where(x => x.SacolaId == id)
               .ToListAsync();

            return sacolaProduto;
        }

        public async Task<SacolaProduto> Cadastrar(SacolaProduto sacolaProduto)
        {
            if (sacolaProduto == null) throw new ArgumentNullException(nameof(sacolaProduto));

            _context.SacolasProdutos.Add(sacolaProduto);
            await _context.SaveChangesAsync();
            return sacolaProduto;
        }
    }
}
