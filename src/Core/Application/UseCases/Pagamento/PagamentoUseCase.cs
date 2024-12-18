using FoodOrder.Domain.Entities;
using FoodOrder.Domain.Ports;

namespace FoodOrder.Application.UseCases.Pagamento
{
    public class PagamentoUseCase : IPagamentoUseCase
    {
        private readonly IPagamentoRepository _pagamentoRepository;
        private readonly IPedidoRepository _pedidoRepository;
        private readonly IPagamentoStatusRepository _pagamentoStatusRepository;

        public PagamentoUseCase(IPagamentoRepository pagamentoRepository, IPedidoRepository pedidoRepository, IPagamentoStatusRepository pagamentoStatusRepository)
        {
            _pagamentoRepository = pagamentoRepository;
            _pedidoRepository = pedidoRepository;
            _pagamentoStatusRepository = pagamentoStatusRepository;
        }

        public async Task<PagamentoStatus> ConsultarStatusPagamento(int numeroPedido)
        {
            var pedido = await _pedidoRepository.ConsultarPedidoPorNumero(numeroPedido);

            if (pedido == null) throw new KeyNotFoundException("Pedido não encontrado!");

            var pagamento = await _pagamentoRepository.ConsultarPagamentoPorId(pedido.PagamentoId);

            if (pagamento == null) throw new KeyNotFoundException("Pagamento nao encontrado!");

            var pagamentoStatus = await _pagamentoStatusRepository.ConsultarPorId(pagamento.PagamentoStatusId);

            return pagamentoStatus;
        }
    }
}