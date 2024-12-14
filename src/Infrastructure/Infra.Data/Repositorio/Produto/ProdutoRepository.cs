using FoodOrder.Domain.Entities;
using FoodOrder.Domain.Ports;
using FoodOrder.Infra.Data.Context;
using Microsoft.EntityFrameworkCore;

namespace FoodOrder.Data.Repositorio.Produto
{
    public class ProdutoRepository : IProdutoRepository
    {
        private readonly NpgsqlContext _context;

        public ProdutoRepository(NpgsqlContext context)
        {
            _context = context;
        }

        #region PRODTUO
        public async Task<Domain.Entities.Produto> Cadastrar(Domain.Entities.Produto produto)
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
                    .Where(p => p.Categoria != null && p.Categoria.Nome == categoria.ToLower().Trim())
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
                            Nome = i.Nome
                        }).ToList() ?? new List<ImagemDto>()
                }).ToList();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Erro ao consultar produtos: {ex.Message}");
                return new List<ProdutoDto>();
            }
        }

        public async Task<List<Domain.Entities.Produto>> ConsultarProdutoPorCategoriaId(int id)
        {
            var produtos = await _context.Produtos
                .Where(x => x.Categoria.Id == id)
                .ToListAsync();

            return produtos;
        }

        public async Task<Domain.Entities.Produto> Atualizar(Domain.Entities.Produto categoria)
        {
            if (categoria == null) throw new ArgumentNullException(nameof(categoria));

            _context.Produtos.Update(categoria);
            await _context.SaveChangesAsync();
            return categoria;
        }

        public async Task<Domain.Entities.Produto> Deletar(int id)
        {
            var produto = await _context.Produtos.FindAsync(id);

            if (produto == null) return null;

            _context.Produtos.Remove(produto);
            await _context.SaveChangesAsync();
            return produto;
        }

        public async Task<Domain.Entities.Produto> ConsultarPorId(int id)
        {
            Domain.Entities.Produto produto = await _context.Produtos.Where(x => x.Id == id).FirstOrDefaultAsync();

            if (produto == null)
            {
                return new Domain.Entities.Produto();
            }

            return produto;
        }
        #endregion
    }
}
