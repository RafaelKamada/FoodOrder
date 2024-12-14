using FoodOrder.Domain.Ports;
using FoodOrder.Infra.Data.Context;
using Microsoft.EntityFrameworkCore;

namespace FoodOrder.Data.Repositorio.Sacola
{
    public class SacolaRepository : ISacolaRepository
    {
        private readonly NpgsqlContext _context;

        public SacolaRepository(NpgsqlContext context)
        {
            _context = context;
        }

        public async Task<Domain.Entities.Sacola> Cadastrar(Domain.Entities.Sacola sacola)
        {
            if (sacola == null) throw new ArgumentNullException(nameof(sacola));

            _context.Sacola.Add(sacola);
            await _context.SaveChangesAsync();
            return sacola;
        }

        public async Task<Domain.Entities.Sacola> ResgatarUltimaSacola()
        {
            var sacola = await _context.Sacola.ToListAsync();
            return sacola.LastOrDefault();
        }
    }
}
