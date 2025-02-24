using FoodOrder.Domain.Entities;

namespace FoodOrder.Application.UseCases.Produtos
{
    public interface ICategoriaUseCase
    {
        Task<Categoria> Cadastrar(Categoria categoria);
        Task<Categoria> Atualizar(Categoria categoria);
        Task<Categoria> Deletar(int id);
        Task<Categoria> Consultar(string categoria);
        Task<List<Categoria>> Consultar();
    }
}
