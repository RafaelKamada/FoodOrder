using FoodOrder.Application.Commands;
using FoodOrder.Application.UseCases.Checkout;
using MediatR;

namespace FoodOrder.Application.Handlers.Pedido
{
    public class AddCheckoutCommandHandler : IRequestHandler<AddCheckoutCommand, Unit>
    {
        private readonly ICheckoutUseCase _checkoutUseCase;

        public AddCheckoutCommandHandler(ICheckoutUseCase checkoutUseCase)
        {
            _checkoutUseCase = checkoutUseCase;
        }

        public async Task<Unit> Handle(AddCheckoutCommand request, CancellationToken cancellationToken)
        {
            await _checkoutUseCase.Cadastrar(request.Cpf, request.Produtos);
            return Unit.Value;
        }
    }
}
