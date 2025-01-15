using FoodOrder.Application.Output;
using FoodOrder.Domain.Entities;
using FoodOrder.Domain.Ports;

namespace FoodOrder.Application.UseCases.Pedidos
{
    public class PedidoUseCase : IPedidoUseCase
    {
        private readonly IPedidoRepository _pedidosRepository;
        private readonly ISacolaProdutoRepository _sacolaProdutoRepository;
        private readonly IProdutoRepository _produtoRepository;
        private readonly IPedidoStatusRepository _pedidoStatusRepository;

        public PedidoUseCase(IPedidoRepository pedidosRepository, ISacolaProdutoRepository sacolaProdutoRepository, IProdutoRepository produtoRepository, IPedidoStatusRepository pedidoStatusRepository)
        {
            _pedidosRepository = pedidosRepository;
            _sacolaProdutoRepository = sacolaProdutoRepository;
            _produtoRepository = produtoRepository;
            _pedidoStatusRepository = pedidoStatusRepository;
        }

        public async Task<PedidosOutput> ListarPedidos()
        {
            List<PedidoOutput> pedidosOutput = new List<PedidoOutput>();
            var pedidos = await _pedidosRepository.ListarPedidos();

            if (pedidos.Count == 0)
            {
                pedidos.Add(new Pedido());
                PedidoOutput pedidoOutput = new PedidoOutput();
                pedidoOutput.Produtos = new List<ProdutoOutput>();
                ProdutoOutput produto = new ProdutoOutput();
                PedidoStatusOutput pedidoStatus = new PedidoStatusOutput();
                pedidoStatus.Id = 1;
                pedidoStatus.Descricao = "Em preparação";
                produto.Id = 1;
                produto.Nome = "Nome";
                produto.Descricao = "Descricao";
                pedidoOutput.PedidoStatus = pedidoStatus;
                pedidoOutput.Produtos.Add(produto);
                pedidosOutput.Add(pedidoOutput);

            }
            else
            {
                foreach (var item in pedidos)
                {
                    PedidoOutput pedidoOutput = new PedidoOutput();
                    PedidoStatusOutput pedidoStatusOutput = new PedidoStatusOutput();
                    PedidoStatus pedidoStatusDados = await _pedidoStatusRepository.ConsultarPorId(item.PedidoStatusId);

                    pedidoOutput.Produtos = new List<ProdutoOutput>();
                    pedidoOutput.Id = item.Id;
                    pedidoOutput.NumeroPedido = item.NumeroPedido;
                    pedidoOutput.TempoEspera = item.TempoEspera;
                    pedidoOutput.ClienteId = (item.ClienteId == Guid.Empty) ? null : item.ClienteId;
                    pedidoOutput.PagamentoId = item.PagamentoId;
                    pedidoOutput.SacolaId = item.SacolaId;
                    pedidoOutput.PedidoStatus = pedidoStatusOutput;
                    pedidoOutput.PedidoStatus.Id = pedidoStatusDados.Id;
                    pedidoOutput.PedidoStatus.Descricao = pedidoStatusDados.Descricao;
                    pedidoOutput.DataCriacao = item.DataCriacao;

                    var sacolasProdutos = await _sacolaProdutoRepository.ConsultarPorSacola(item.SacolaId);

                    foreach (var itemSacolaProduto in sacolasProdutos)
                    {
                        var produtoBase = await _produtoRepository.ConsultarPorId(itemSacolaProduto.ProdutoId);
                        
                        if (produtoBase?.Id == null)
                        {
                            ProdutoOutput produtoOut = new ProdutoOutput();
                            produtoOut.Id = 1;
                            produtoOut.Nome = "Nome";
                            produtoOut.Descricao = "Descricao";
                            pedidoOutput.Produtos.Add(produtoOut);
                            continue;
                        }
                        else
                        {
                            ProdutoOutput produto = new ProdutoOutput();
                            produto.Id = produtoBase.Id;
                            produto.Nome = produtoBase.Nome;
                            produto.Descricao = produtoBase.Descricao;
                            pedidoOutput.Produtos.Add(produto);
                        }
                    }

                    pedidosOutput.Add(pedidoOutput);
                }
            }

            return OrdenarPedidos(pedidosOutput);
        }

        private PedidosOutput OrdenarPedidos(List<PedidoOutput> pedidos)
        {
            PedidosOutput pedidosOutput = new PedidosOutput();
            pedidosOutput.Pronto = new List<PedidoOutput>();
            pedidosOutput.EmPreparo = new List<PedidoOutput>();
            pedidosOutput.Recebido = new List<PedidoOutput>();

            pedidos = pedidos.OrderBy(x => x.DataCriacao).ToList();

            foreach (var item in pedidos)
            {
                if (item.PedidoStatus.Descricao == "Pronto")
                {
                    pedidosOutput.Pronto.Add(item);
                }
                else if (item.PedidoStatus.Descricao == "Em preparação")
                {
                    pedidosOutput.EmPreparo.Add(item);
                }
                else if (item.PedidoStatus.Descricao == "Recebido")
                {
                    pedidosOutput.Recebido.Add(item);
                }
            }

            return pedidosOutput;
        }
    }
}
