using Domain.Entities;
using Domain.Ports;

namespace Application.UseCases.Checkout
{
    public class CheckoutUseCase : ICheckoutUseCase
    {
        private readonly IPedidoRepository _pedidoRepository;
        private readonly IClienteRepository _clienteRepository;
        private readonly ISacolaRepository _sacolaRepository;
        private readonly IProdutoRepository _produtoRepository;
        private readonly ISacolaProdutoRepository _sacolaProdutoRepository;

        public CheckoutUseCase(ISacolaProdutoRepository sacolaProdutoRepository, 
                                ISacolaRepository sacolaRepository, 
                                IProdutoRepository produtoRepository, 
                                IClienteRepository clienteRepository, 
                                IPedidoRepository pedidoRepository)
        {
            _sacolaProdutoRepository = sacolaProdutoRepository;
            _sacolaRepository = sacolaRepository;
            _produtoRepository = produtoRepository;
            _clienteRepository = clienteRepository;
            _pedidoRepository = pedidoRepository;
        }

        public async Task<Pedido> Cadastrar(string cpf, List<int> produtosIds)
        {
            try
            {
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
                }

                foreach (int id in produtosIds)
                {
                    Produto produto = await _produtoRepository.ConsultarPorId(id);

                    if (produto == null)
                    {
                        throw new Exception($"Produto com ID: {id} não encontrado.");
                    }

                    valorTotal += produto.Preco;
                    tempoEsperaMinutos += TimeSpan.FromMinutes(produto.TempoPreparo.Minutes);
                    SacolaProduto sacolaProduto = new SacolaProduto(sacola, produto);
                    await _sacolaProdutoRepository.Cadastrar(sacolaProduto);
                }

                PedidoStatus pedidoStatus = new PedidoStatus("Em preparação");
                //TODO: Validar quais status serão utilizados no status do pagamento.
                PagamentoStatus pagamentoStatus = new PagamentoStatus("Concluído");
                Pagamento pagamento = new Pagamento(valorTotal, pagamentoStatus);
                Pedido pedido = new Pedido(numeroPedido: 1, tempoEsperaMinutos, cliente, pagamento, pedidoStatus, sacola);

                var pedidoCadastrado = await _pedidoRepository.Cadastrar(pedido);

                return pedidoCadastrado;
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
