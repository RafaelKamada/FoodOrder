using Application.Output;
using Domain.Entities;
using Domain.Ports;

namespace Application.UseCases.Pedidos
{
    public class PedidoUseCase : IPedidoUseCase
    {
        private readonly IPedidoRepository _pedidosRepository;
        private readonly ISacolaProdutoRepository _sacolaProdutoRepository;
        private readonly IProdutoRepository _produtoRepository;

        public PedidoUseCase(IPedidoRepository pedidosRepository, ISacolaProdutoRepository sacolaProdutoRepository, IProdutoRepository produtoRepository)
        {
            _pedidosRepository = pedidosRepository;
            _sacolaProdutoRepository = sacolaProdutoRepository;
            _produtoRepository = produtoRepository;
        }

        public async Task<List<PedidoOutput>> ListarPedidos()
        {
            List<PedidoOutput> pedidosOutput = new List<PedidoOutput>();
            var pedidos = await _pedidosRepository.ListarPedidos();

            if (pedidos.Count == 0)
            {
                pedidos.Add(new Pedido());
                PedidoOutput pedidoOutput = new PedidoOutput();
                pedidoOutput.Produtos = new List<ProdutoOutput>();
                ProdutoOutput produto = new ProdutoOutput();
                produto.Id = 1;
                produto.Nome = "Nome";
                produto.Descricao = "Descricao";
                pedidoOutput.Produtos.Add(produto);
                pedidosOutput.Add(pedidoOutput);
            }
            else
            {
                foreach (var item in pedidos)
                {
                    PedidoOutput pedidoOutput = new PedidoOutput();
                    pedidoOutput.Produtos = new List<ProdutoOutput>();
                    pedidoOutput.Id = item.Id;
                    pedidoOutput.NumeroPedido = item.NumeroPedido;
                    pedidoOutput.TempoEspera = item.TempoEspera;
                    pedidoOutput.ClienteId = (item.ClienteId == Guid.Empty) ? null : item.ClienteId;
                    pedidoOutput.PagamentoId = item.PagamentoId;
                    pedidoOutput.PedidoStatusId = item.PedidoStatusId;
                    pedidoOutput.SacolaId = item.SacolaId;

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

            return pedidosOutput;
        }
    }
}
