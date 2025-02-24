using FoodOrder.Domain.Ports;

namespace FoodOrder.Application.UseCases.Webhook
{
    public class PagtoWebhookUseCase : IPagtoWebhookUseCase
    {
        private readonly IMercadoPagoExternalService _mercadoPagoExternalService;
        private readonly IPagamentoStatusRepository _pagamentoStatusRepository;
        private readonly IPagamentoRepository _pagamentoRepository;

        public PagtoWebhookUseCase(IMercadoPagoExternalService mercadoPagoExternalService, IPagamentoStatusRepository pagamentoStatusRepository, IPagamentoRepository pagamentoRepository)
        {
            _mercadoPagoExternalService = mercadoPagoExternalService;
            _pagamentoStatusRepository = pagamentoStatusRepository;
            _pagamentoRepository = pagamentoRepository;
        }

        public async Task<bool> ExecuteAsync(string paymentId)
        {
            try
            {
                // 1. Consulta o status real do pagamento no Mercado Pago
                var paymentDetails = await _mercadoPagoExternalService.GetPagamentoDetalhesAsync(paymentId);

                // 2. Mapeia o status
                var paymentStatus = _pagamentoStatusRepository.ConsultarPorStatus(paymentDetails.Status);

                // 3. Atualiza o status no repositório
                await _pagamentoRepository.AtualizarStatusPagamentoPorId(paymentId, paymentStatus.Id);

                return true;
            }
            catch (Exception)
            {
                // Log de erro
                return false;
            }
        }
    }
}
