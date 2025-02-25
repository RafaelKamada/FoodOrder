using FoodOrder.Domain.Entities;

namespace FoodOrder.Application.UseCases.Produtos
{
    public interface IProdutoUseCase
    {
        Task<Produto> Cadastrar(Produto produto);
        Task<List<ProdutoDto>> ConsultarPorCategoria(string categoria);
        Task<List<Produto>> ConsultarPorCategoriaId(int id);
        Task<Produto> Atualizar(Produto categoria);
        Task<Produto> Deletar(int id);
    }
}
