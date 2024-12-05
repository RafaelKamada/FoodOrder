using FoodOrder.Domain.Entities;

namespace FoodOrder.Application.UseCases.Checkout
{
    public interface ICheckoutUseCase
    {
        Task<Pedido> Cadastrar(string cpf, List<int> produtosIds);
    }
}
