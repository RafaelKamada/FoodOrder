using FoodOrder.Domain.Entities;
using FoodOrder.Domain.Ports;

namespace FoodOrder.Application.UseCases.Produtos
{
    public class ProdutoUseCase : IProdutoUseCase
    {
        private readonly IProdutoRepository _produtoRepository;

        public ProdutoUseCase(IProdutoRepository produtoRepository)
        {
            _produtoRepository = produtoRepository;
        }
        #region PRODUTO
        public Task<Produto> Cadastrar(Produto produto)
        {
            return _produtoRepository.Cadastrar(produto);
        }

        public Task<List<ProdutoDto>> ConsultarPorCategoria(string categoria)
        {
            return _produtoRepository.ConsultarPorCategoria(categoria);
        }

        public Task<List<Produto>> ConsultarPorCategoriaId(int id)
        {
            return _produtoRepository.ConsultarProdutoPorCategoriaId(id);
        }
        public Task<Produto> Atualizar(Produto categoria)
        {
            return _produtoRepository.Atualizar(categoria);
        }

        public Task<Produto> Deletar(int id)
        {
            return _produtoRepository.Deletar(id);
        }

        #endregion
    }
}
