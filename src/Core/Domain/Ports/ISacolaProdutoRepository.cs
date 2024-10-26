using Domain.Entities;

namespace Domain.Ports
{
    public interface ISacolaProdutoRepository
    {
        Task<SacolaProduto> Cadastrar(SacolaProduto produto);
        Task<List<SacolaProduto>> ConsultarPorSacola(int id);
    }
}
