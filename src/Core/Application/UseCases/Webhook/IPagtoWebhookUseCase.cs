
namespace FoodOrder.Application.UseCases.Webhook
{
    public interface IPagtoWebhookUseCase
    {
        Task<string> AtualizarStatusPagamento(string webhook);
    }
}
