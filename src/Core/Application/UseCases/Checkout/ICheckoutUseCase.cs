using Domain.Entities;

namespace Application.UseCases.Checkout
{
    public interface ICheckoutUseCase
    {
        Task<Pedido> Cadastrar(string cpf, List<int> produtosIds);
    }
}
