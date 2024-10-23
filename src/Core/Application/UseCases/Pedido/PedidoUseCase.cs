using Application.Output;
using Domain.Entities;
using Domain.Ports;

namespace Application.UseCases.Pedidos
{
    public class PedidoUseCase : IPedidoUseCase
    {
        private readonly IPedidoRepository _pedidosRepository;

        public PedidoUseCase(IPedidoRepository pedidosRepository)
        {
            _pedidosRepository = pedidosRepository;
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
                    pedidoOutput.ClienteId = item.Cliente.Id;
                    pedidoOutput.PagamentoId = item.Pagamento.Id;
                    pedidoOutput.PedidoStatusId = item.Pedido_Status.Id;
                    pedidoOutput.SacolaId = item.Sacola.Id;

                    ProdutoOutput produto = new ProdutoOutput();
                    produto.Id = 1;
                    produto.Nome = "teste";
                    produto.Descricao = "teste descr";
                    pedidoOutput.Produtos.Add(produto);
                    pedidosOutput.Add(pedidoOutput);
                }
            }

            return pedidosOutput;
        }
    }
}
