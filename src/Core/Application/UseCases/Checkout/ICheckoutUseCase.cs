using FoodOrder.Application.Output;

namespace FoodOrder.Application.UseCases.Checkout
{
    public interface ICheckoutUseCase
    {
        Task<CheckoutOutput> Cadastrar(string cpf, List<int> produtosIds);
    }
}
