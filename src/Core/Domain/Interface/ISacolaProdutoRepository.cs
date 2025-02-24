using FoodOrder.Domain.Entities;

namespace FoodOrder.Domain.Ports
{
    public interface ISacolaProdutoRepository
    {
        Task<SacolaProduto> Cadastrar(SacolaProduto produto);
        Task<List<SacolaProduto>> ConsultarPorSacola(int id);
    }
}
