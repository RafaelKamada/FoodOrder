using FoodOrder.Domain.Entities;
using FoodOrder.Domain.Interface;
using FoodOrder.Infra.Data.Context;
using Microsoft.EntityFrameworkCore;

namespace FoodOrder.Infra.Data.Repository
{
    public class CategoriaRepository : ICategoriaRepository
    {
        private readonly NpgsqlContext _context;

        public CategoriaRepository(NpgsqlContext context)
        {
            _context = context;
        }

        #region CATEGORIA
        public async Task<Categoria> CadastrarAsync(Categoria categoria)
        {
            if (categoria == null) throw new ArgumentNullException(nameof(categoria));

            _context.Categoria.Add(categoria);
            await _context.SaveChangesAsync();
            return categoria;
        }

        public async Task<Categoria> AtualizarAsync(Categoria categoria)
        {
            if (categoria == null) throw new ArgumentNullException(nameof(categoria));

            _context.Categoria.Update(categoria);
            await _context.SaveChangesAsync();
            return categoria;
        }

        public async Task<Categoria> DeletarAsync(int id)
        {
            var categoria = await _context.Categoria.FindAsync(id);

            if (categoria == null) return null;

            _context.Categoria.Remove(categoria);
            await _context.SaveChangesAsync();
            return categoria;
        }

        public async Task<Categoria> ConsultarAsync(string categoria)
        {
            if (string.IsNullOrEmpty(categoria))
            {
                return new Categoria();
            }

            var dto = await _context.Categoria
                .FirstOrDefaultAsync(x => x.Nome == categoria);

            return dto ?? new Categoria();
        }

        public async Task<List<Categoria>> ConsultarCategoriasAsync()
        {
            var categoria = await _context.Categoria.ToListAsync();
            return categoria;
        }
        #endregion        
    }
}
