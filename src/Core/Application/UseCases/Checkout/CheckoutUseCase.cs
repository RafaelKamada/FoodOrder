using FoodOrder.Application.Output;
using FoodOrder.Domain.Entities;
using FoodOrder.Domain.Interface;
using FoodOrder.Domain.Ports;

namespace FoodOrder.Application.UseCases.Checkout
{
    public class CheckoutUseCase : ICheckoutUseCase
    {
        private readonly IPedidoRepository _pedidoRepository;
        private readonly IClienteRepository _clienteRepository;
        private readonly ISacolaRepository _sacolaRepository;
        private readonly IProdutoRepository _produtoRepository;
        private readonly ISacolaProdutoRepository _sacolaProdutoRepository;
        private readonly IPagamentoRepository _pagamentoRepository;
        private readonly IPagamentoStatusRepository _pagamentoStatusRepository;
        private readonly IPedidoStatusRepository _pedidoStatusRepository;

        public CheckoutUseCase(ISacolaProdutoRepository sacolaProdutoRepository,
                                ISacolaRepository sacolaRepository,
                                IProdutoRepository produtoRepository,
                                IClienteRepository clienteRepository,
                                IPedidoRepository pedidoRepository,
                                IPagamentoRepository pagamentoRepository,
                                IPagamentoStatusRepository pagamentoStatusRepository,
                                IPedidoStatusRepository pedidoStatusRepository)
        {
            _sacolaProdutoRepository = sacolaProdutoRepository;
            _sacolaRepository = sacolaRepository;
            _produtoRepository = produtoRepository;
            _clienteRepository = clienteRepository;
            _pedidoRepository = pedidoRepository;
            _pagamentoRepository = pagamentoRepository;
            _pagamentoStatusRepository = pagamentoStatusRepository;
            _pedidoStatusRepository = pedidoStatusRepository;
        }

        public async Task<CheckoutOutput> Cadastrar(string cpf, List<int> produtosIds)
        {
            try
            {
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
                PagamentoStatus pagamentoStatus = new PagamentoStatus("Concluído");
                await _pagamentoStatusRepository.Cadastrar(pagamentoStatus);

                Pagamento pagamento = new Pagamento(valorTotal, pagamentoStatus);
                await _pagamentoRepository.Cadastrar(pagamento);

                Pedido pedido = new Pedido(tempoEsperaMinutos, cliente.Id, pagamento.Id, pedidoStatus.Id, sacola.Id);

                checkout.NumeroPedido = await _pedidoRepository.Cadastrar(pedido);

                return checkout;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
