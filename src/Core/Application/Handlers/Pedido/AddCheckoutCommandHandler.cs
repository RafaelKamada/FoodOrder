using FoodOrder.Application.Commands;
using FoodOrder.Application.Output;
using FoodOrder.Application.UseCases.Checkout;
using MediatR;

namespace FoodOrder.Application.Handlers.Pedido
{
    public class AddCheckoutCommandHandler : IRequestHandler<AddCheckoutCommand, CheckoutOutput>
    {
        private readonly ICheckoutUseCase _checkoutUseCase;

        public AddCheckoutCommandHandler(ICheckoutUseCase checkoutUseCase)
        {
            _checkoutUseCase = checkoutUseCase;
        }

        public async Task<CheckoutOutput> Handle(AddCheckoutCommand request, CancellationToken cancellationToken)
        {
            return await _checkoutUseCase.Cadastrar(request.Cpf, request.Produtos);
        }
    }
}
