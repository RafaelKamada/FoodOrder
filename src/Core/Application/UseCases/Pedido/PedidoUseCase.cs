﻿using Application.Output;
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
                    pedidoOutput.ClienteId = item.Cliente?.Id;
                    pedidoOutput.PagamentoId = item.Pagamento?.Id;
                    pedidoOutput.PedidoStatusId = item.Pedido_Status?.Id;
                    pedidoOutput.SacolaId = item.Sacola?.Id;

                    var sacolasProdutos = await _sacolaProdutoRepository.ConsultarPorSacola(item.Sacola?.Id ?? 0);

                    foreach (var itemSacolaProduto in sacolasProdutos)
                    {
                        var produtoBase = await _produtoRepository.ConsultarPorId(itemSacolaProduto.Produto.Id);

                        if (produtoBase == null)
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

                    //ProdutoOutput produto = new ProdutoOutput();
                    //produto.Id = 1;
                    //produto.Nome = "teste";
                    //produto.Descricao = "teste descr";
                    //pedidoOutput.Produtos.Add(produto);
                    pedidosOutput.Add(pedidoOutput);
                }
            }

            return pedidosOutput;
        }
    }
}
