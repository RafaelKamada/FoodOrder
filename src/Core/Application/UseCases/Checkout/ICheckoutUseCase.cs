using FoodOrder.Application.Output;
using FoodOrder.Domain.Entities;

namespace FoodOrder.Application.UseCases.Checkout
{
    public interface ICheckoutUseCase
    {
        Task<CheckoutOutput> Cadastrar(string cpf, List<int> produtosIds);
    }
}
