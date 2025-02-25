using FoodOrder.Domain.Entities;

namespace FoodOrder.Domain.Ports
{
    public interface IProdutoRepository
    {
        Task<Produto> Cadastrar(Produto produto);
        Task<List<ProdutoDto>> ConsultarPorCategoria(string categoria);
        Task<List<Produto>> ConsultarProdutoPorCategoriaId(int id);
        Task<Produto> Atualizar(Produto categoria);
        Task<Produto> Deletar(int id);
        Task<Produto> ConsultarPorId(int id);
    }
}
