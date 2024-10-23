using Domain.Entities;
using Domain.Ports;
using Infra.Data.Context;
using Microsoft.EntityFrameworkCore;

namespace Infra.Data.Repository
{
    public class SacolaRepository : ISacolaRepository
    {
        private readonly NpgsqlContext _context;

        public SacolaRepository(NpgsqlContext context)
        {
            _context = context;
        }

        public async Task<Sacola> Cadastrar(Sacola sacola)
        {
            if (sacola == null) throw new ArgumentNullException(nameof(sacola));

            _context.Sacola.Add(sacola);
            await _context.SaveChangesAsync();
            return sacola;
        }

        public async Task<Sacola> ResgatarUltimaSacola()
        {
            var sacola = await _context.Sacola.ToListAsync();
            return sacola.LastOrDefault();
        }
    }
}
