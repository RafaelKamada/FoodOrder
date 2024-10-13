using Domain.Entities;
using Domain.Ports;
using Infra.Data.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infra.Data.Repository
{
    public class ProdutoRepository : IProdutoRepository
    {
        private readonly NpgsqlContext _context;

        public ProdutoRepository(NpgsqlContext context)
        {
            _context = context;
        }

        public async Task<Produto> Cadastrar(Produto produto)
        {
            if (produto == null) throw new ArgumentNullException(nameof(produto));

            _context.Produtos.Add(produto);
            await _context.SaveChangesAsync();
            return produto;
        }

        public async Task<Categoria> Cadastrar(Categoria categoria)
        {
            if (categoria == null) throw new ArgumentNullException(nameof(categoria));

            _context.Categoria.Add(categoria);
            await _context.SaveChangesAsync();
            return categoria;
        }

        public async Task<Categoria> ConsultarCategoria(string categoria)
        {
            if (string.IsNullOrEmpty(categoria))
            {
                return new Categoria();
            }

            var dto = await _context.Categoria
                .FirstOrDefaultAsync(x => x.Nome == categoria);

            return dto ?? new Categoria();
        }


        public async Task<List<Produto>> ConsultarPorCategoria(string categoria)
        {
            if (string.IsNullOrEmpty(categoria))
            {
                return new List<Produto>();
            }

            var produtos = await _context.Produtos
                .Where(x => x.Categoria.Nome == categoria)
                .ToListAsync();

            return produtos;
        }
    }
}
