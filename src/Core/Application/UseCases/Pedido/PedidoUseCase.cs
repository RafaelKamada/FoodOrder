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
                    PedidoOutput pedidoOutput = await BuildPedidoOutput(item);

                    pedidosOutput.Add(pedidoOutput);
                }
            }

            return OrdenarPedidos(pedidosOutput);
        }

        public async Task<PedidoOutput> Consultar(int numeroPedido)
        {
            var pedido = await _pedidosRepository.ConsultarPedidoPorNumero(numeroPedido);
            return await BuildPedidoOutput(pedido);
        }

        public async Task<PedidoStatusOutput> ConsultarStatus(string status)
        {
            if (string.IsNullOrWhiteSpace(status))
                throw new ArgumentException("Status não informado!");

            status = status.ToLower() switch
            {
                "pronto" => "Pronto",
                "em preparacao" => "Em preparação",
                "em preparação" => "Em preparação",
                "recebido" => "Recebido",
                "finalizado" => "Finalizado",
                "cancelado" => "Cancelado",
                _ => throw new ArgumentException("Status inválido!")
            };

            PedidoStatus pedidoStatus = new PedidoStatus(status);
            var pedidoStatusDados = await _pedidoStatusRepository.Cadastrar(pedidoStatus);

            PedidoStatusOutput pedidoStatusOutput = new PedidoStatusOutput();
            pedidoStatusOutput.Id = pedidoStatusDados.Id;
            pedidoStatusOutput.Descricao = pedidoStatusDados.Descricao;

            return pedidoStatusOutput;
        }

        public async Task Atualizar(PedidoOutput pedidoAtualizado)
        {
            var pedido = await _pedidosRepository.ConsultarPedidoPorNumero(pedidoAtualizado.NumeroPedido);

            pedido.NumeroPedido = pedidoAtualizado.NumeroPedido;
            pedido.TempoEspera = pedidoAtualizado.TempoEspera;
            pedido.ClienteId = pedidoAtualizado.ClienteId ?? Guid.Empty;
            pedido.PagamentoId = pedidoAtualizado.PagamentoId ?? 0;
            pedido.SacolaId = pedidoAtualizado.SacolaId ?? 0;
            pedido.PedidoStatusId = pedidoAtualizado.PedidoStatus?.Id ?? 0;
            pedido.DataCriacao = pedidoAtualizado.DataCriacao;

            await _pedidosRepository.Atualizar(pedido);
        }

        private async Task<PedidoOutput> BuildPedidoOutput(Pedido pedido)
        {
            PedidoOutput pedidoOutput = new PedidoOutput();
            PedidoStatusOutput pedidoStatusOutput = new PedidoStatusOutput();
            PedidoStatus pedidoStatusDados = await _pedidoStatusRepository.ConsultarPorId(pedido.PedidoStatusId);

            pedidoOutput.Produtos = new List<ProdutoOutput>();
            pedidoOutput.Id = pedido.Id;
            pedidoOutput.NumeroPedido = pedido.NumeroPedido;
            pedidoOutput.TempoEspera = pedido.TempoEspera;
            pedidoOutput.ClienteId = (pedido.ClienteId == Guid.Empty) ? null : pedido.ClienteId;
            pedidoOutput.PagamentoId = pedido.PagamentoId;
            pedidoOutput.SacolaId = pedido.SacolaId;
            pedidoOutput.PedidoStatus = pedidoStatusOutput;
            pedidoOutput.PedidoStatus.Id = pedidoStatusDados.Id;
            pedidoOutput.PedidoStatus.Descricao = pedidoStatusDados.Descricao;
            pedidoOutput.DataCriacao = pedido.DataCriacao;

            var sacolasProdutos = await _sacolaProdutoRepository.ConsultarPorSacola(pedido.SacolaId);

            foreach (var SacolaProduto in sacolasProdutos)
            {
                var produtoBase = await _produtoRepository.ConsultarPorId(SacolaProduto.ProdutoId);
                
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

            return pedidoOutput;
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
