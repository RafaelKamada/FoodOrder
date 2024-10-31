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

        public async Task<List<ProdutoDto>> ConsultarPorCategoria(string categoria)
        {
            if (string.IsNullOrEmpty(categoria))
            {
                return new List<ProdutoDto>();
            }

            try
            {
                var produtos = await _context.Produtos
                    .Where(p => p.Categoria != null && p.Categoria.Nome == categoria)
                    .Include(p => p.Categoria)
                    .Include(p => p.Imagens)
                    .ToListAsync();

                return produtos.Select(p => new ProdutoDto
                {
                    Id = p.Id,
                    Nome = p.Nome,
                    Categoria = p.Categoria,
                    Descricao = p.Descricao,
                    Preco = p.Preco,
                    TempoPreparo = p.TempoPreparo,
                    Imagens = p.Imagens?
                        .Where(i => i.Data != null)
                        .Select(i => new ImagemDto
                        {
                            Id = i.Id,
                            Nome = i.Nome,
                            //Base64 = Convert.ToBase64String(i.Data)
                        }).ToList() ?? new List<ImagemDto>()
                }).ToList();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Erro ao consultar produtos: {ex.Message}");
                return new List<ProdutoDto>();
            }
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

        public async Task<Produto> ConsultarPorId(int id)
        {
            Produto produto = await _context.Produtos.Where(x => x.Id == id).FirstOrDefaultAsync();

            if (produto == null)
            {
                return new Produto();
            }

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
