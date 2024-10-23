using Application.Commands;
using Application.UseCases.Checkout;
using MediatR;

namespace Application.Handlers
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
