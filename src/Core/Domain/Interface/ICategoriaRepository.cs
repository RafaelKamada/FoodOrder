using FoodOrder.Domain.Entities;

namespace FoodOrder.Domain.Interface
{
    public interface ICategoriaRepository
    {
        Task<Categoria> CadastrarAsync(Categoria categoria);
        Task<Categoria> AtualizarAsync(Categoria categoria);
        Task<Categoria> DeletarAsync(int id);
        Task<Categoria> ConsultarAsync(string categoria);
        Task<List<Categoria>> ConsultarCategoriasAsync();
    }
}
