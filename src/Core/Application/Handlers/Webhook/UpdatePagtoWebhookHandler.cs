using FoodOrder.Application.Commands;
using FoodOrder.Application.UseCases.Webhook;
using MediatR;

namespace FoodOrder.Application.Handlers.Webhook
{
    public class UpdatePagtoWebhookHandler : IRequestHandler<UpdatePagtoWebhookCommand, Unit>
    {
        private readonly IPagtoWebhookUseCase _pagtoWebHookUseCase;

        public UpdatePagtoWebhookHandler(IPagtoWebhookUseCase pagtoWebHookUseCase)
        {
            _pagtoWebHookUseCase = pagtoWebHookUseCase;
        }

        public async Task<Unit> Handle(UpdatePagtoWebhookCommand request, CancellationToken cancellationToken)
        {
            await _pagtoWebHookUseCase.ExecuteAsync(request.Data.Id);
            return Unit.Value;
        }
    }
}
