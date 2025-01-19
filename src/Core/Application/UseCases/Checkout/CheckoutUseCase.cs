using FoodOrder.Application.Output;
using FoodOrder.Domain.Entities;
using FoodOrder.Domain.Entities.Result;
using FoodOrder.Domain.Interface;
using FoodOrder.Domain.Ports;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;

namespace FoodOrder.Application.UseCases.Checkout
{
    public class CheckoutUseCase : ICheckoutUseCase
    {
        private readonly ILogger<CheckoutUseCase> _logger;
        private readonly IPedidoRepository _pedidoRepository;
        private readonly IClienteRepository _clienteRepository;
        private readonly ISacolaRepository _sacolaRepository;
        private readonly IProdutoRepository _produtoRepository;
        private readonly ISacolaProdutoRepository _sacolaProdutoRepository;
        private readonly IPagamentoRepository _pagamentoRepository;
        private readonly IPagamentoStatusRepository _pagamentoStatusRepository;
        private readonly IPedidoStatusRepository _pedidoStatusRepository;
        private readonly IMercadoPagoExternalService _mercadoPagoExternalService;
        private readonly IConfiguration _configuration;

        public CheckoutUseCase(ISacolaProdutoRepository sacolaProdutoRepository,
                                ISacolaRepository sacolaRepository,
                                IProdutoRepository produtoRepository,
                                IClienteRepository clienteRepository,
                                IPedidoRepository pedidoRepository,
                                IPagamentoRepository pagamentoRepository,
                                IPagamentoStatusRepository pagamentoStatusRepository,
                                IPedidoStatusRepository pedidoStatusRepository,
                                IMercadoPagoExternalService mercadoPagoExternalService,
                                ILogger<CheckoutUseCase> logger,
                                IConfiguration configuration)
        {
            _sacolaProdutoRepository = sacolaProdutoRepository;
            _sacolaRepository = sacolaRepository;
            _produtoRepository = produtoRepository;
            _clienteRepository = clienteRepository;
            _pedidoRepository = pedidoRepository;
            _pagamentoRepository = pagamentoRepository;
            _pagamentoStatusRepository = pagamentoStatusRepository;
            _pedidoStatusRepository = pedidoStatusRepository;
            _mercadoPagoExternalService = mercadoPagoExternalService;
            _logger = logger;
            _configuration = configuration;
        }

        public async Task<CheckoutOutput> Cadastrar(string cpf, List<int> produtosIds)
        {
            try
            {
                _logger.LogInformation("Iniciando checkout para CPF {Cpf} com {ProdutosCount} produtos", cpf, produtosIds.Count);

                var checkout = new CheckoutOutput();
                Decimal valorTotal = 0;
                TimeSpan tempoEsperaMinutos = TimeSpan.Zero;

                Cliente cliente = await _clienteRepository.ConsultarPorCpf(cpf);

                if (cliente == null)
                {
                    cliente = new Cliente(cpf, "não informado", "não informado");
                }

                Sacola sacola = await _sacolaRepository.ResgatarUltimaSacola();

                if (sacola == null)
                {
                    sacola = new Sacola();
                    sacola.Id = 1;
                    sacola = await _sacolaRepository.Cadastrar(sacola);
                }
                else
                {
                    sacola.Id++;
                    sacola = await _sacolaRepository.Cadastrar(sacola);
                }

                if (produtosIds == null || !produtosIds.Any())
                {
                    _logger.LogWarning("Tentativa de checkout sem produtos");
                    throw new ArgumentException("Deve haver pelo menos um produto no pedido", nameof(produtosIds));
                }

                foreach (int id in produtosIds)
                {
                    Produto produto = await _produtoRepository.ConsultarPorId(id);

                    if (produto == null || produto?.Id <= 0)
                    {
                        throw new Exception($"Produto com ID: {id} não encontrado.");
                    }

                    valorTotal += produto.Preco;
                    tempoEsperaMinutos += TimeSpan.FromMinutes(produto.TempoPreparo.Minutes);
                    SacolaProduto sacolaProduto = new SacolaProduto(sacola.Id, produto.Id);
                    await _sacolaProdutoRepository.Cadastrar(sacolaProduto);
                }

                PedidoStatus pedidoStatus = new PedidoStatus("Em preparação");
                pedidoStatus = await _pedidoStatusRepository.Cadastrar(pedidoStatus);

                //TODO: Validar quais status serão utilizados no status do pagamento.
                PagamentoStatus pagamentoStatus = new PagamentoStatus("pending");
                pagamentoStatus = await _pagamentoStatusRepository.Cadastrar(pagamentoStatus);

                Domain.Entities.Pagamento pagamento = new Domain.Entities.Pagamento(valorTotal, pagamentoStatus.Id);
                await _pagamentoRepository.Cadastrar(pagamento);

                Pedido pedido = new Pedido(tempoEsperaMinutos, cliente.Id, pagamento.Id, pedidoStatus.Id, sacola.Id);

                checkout.NumeroPedido = await _pedidoRepository.Cadastrar(pedido);

                try
                {

                    bool mercadoPagoEnabled = _configuration.GetValue<bool>("MercadoPago:Ativo");
                    var resultado = new PagamentoResult();

                    if (mercadoPagoEnabled)
                    {
                        resultado = await _mercadoPagoExternalService.CriaPagamentoAsync(pedido, valorTotal, "Pedido_" + checkout.NumeroPedido);
                    }
                    else
                    {
                        resultado = await _mercadoPagoExternalService.CriaPagamentoAsync(valorTotal, "Pedido_" + checkout.NumeroPedido);
                    }


                    await _pagamentoRepository.VincularIdMercadoPago(resultado.PaymentId, pagamento.Id);

                    checkout.QrCode = resultado.QrCode;
                    checkout.QrCodeUrl = resultado.QrCodeUrl;

                    _logger.LogInformation("Checkout concluído com sucesso. Pedido {NumeroPedido}, Valor {ValorTotal}", checkout.NumeroPedido, valorTotal);

                }
                catch (Exception ex)
                {
                    _logger.LogError(ex, "Erro ao processar pagamento para o pedido. Valor: {ValorTotal}, Pedido: {NumeroPedido}",
                    valorTotal, checkout.NumeroPedido);

                    // Pode adicionar uma lógica para reverter o pedido ou marcar como falha
                    throw new ApplicationException("Falha ao processar pagamento", ex);
                }
                return checkout;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Erro durante o processo de checkout para CPF {Cpf}", cpf);
                // Lançar uma exceção de domínio personalizada
                throw new Domain.Exceptions.CheckoutException("Falha no processo de checkout", ex);
            }
        }
    }
}
