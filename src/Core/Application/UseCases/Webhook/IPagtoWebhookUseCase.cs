
namespace FoodOrder.Application.UseCases.Webhook
{
    public interface IPagtoWebhookUseCase
    {
        Task<bool> ExecuteAsync(string paymentId);
    }
}
