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

        #region PRODTUO
        public async Task<Produto> Cadastrar(Produto produto)
        {
            if (produto == null) throw new ArgumentNullException(nameof(produto));

            _context.Produtos.Add(produto);
            await _context.SaveChangesAsync();
            return produto;
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

        public async Task<List<Produto>> ConsultarProdutoPorCategoriaId(int id)
        {
            var produtos = await _context.Produtos
                .Where(x => x.Categoria.Id == id)
                .ToListAsync();

            return produtos;
        }

        public async Task<Produto> Atualizar(Produto categoria)
        {
            if (categoria == null) throw new ArgumentNullException(nameof(categoria));

            _context.Produtos.Update(categoria);
            await _context.SaveChangesAsync();
            return categoria;
        }

        public async Task<Produto> Deletar(int id)
        {
            var produto = await _context.Produtos.FindAsync(id);

            if (produto == null) return null;

            _context.Produtos.Remove(produto);
            await _context.SaveChangesAsync();
            return produto;
        }

        #endregion

        #region CATEGORIA
        public async Task<Categoria> Cadastrar(Categoria categoria)
        {
            if (categoria == null) throw new ArgumentNullException(nameof(categoria));

            _context.Categoria.Add(categoria);
            await _context.SaveChangesAsync();
            return categoria;
        }

        public async Task<Categoria> Atualizar(Categoria categoria)
        {
            if (categoria == null) throw new ArgumentNullException(nameof(categoria));

            _context.Categoria.Update(categoria);
            await _context.SaveChangesAsync();
            return categoria;
        }

        public async Task<Categoria> DeletarCategoria(int id)
        {
            var categoria = await _context.Categoria.FindAsync(id);

            if (categoria == null) return null;

            _context.Categoria.Remove(categoria);
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

        public async Task<List<Categoria>> ConsultarCategoria()
        {
            var categoria = await _context.Categoria.ToListAsync();
            return categoria;
        }
        #endregion        
    }
}
