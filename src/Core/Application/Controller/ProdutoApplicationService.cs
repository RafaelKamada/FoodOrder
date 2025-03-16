using FoodOrder.Application.Commands;
using FoodOrder.Application.DTOs;
using FoodOrder.Application.Queries;
using MediatR;

namespace FoodOrder.Application.Controller
{
    public class ProdutoApplicationService
    {
        private readonly IMediator _mediator;

        public ProdutoApplicationService(IMediator mediator)
        {
            _mediator = mediator;
        }

        public async Task<ProdutoResponse> AdicionarProduto(AddProdutoCommand command)
        {
            var produto = await _mediator.Send(command);
            return new ProdutoResponse(produto);
        }

        public async Task<ProdutoResponse> AtualizarProduto(UpdateProdutoCommand command)
        {
            var produto = await _mediator.Send(command);
            return new ProdutoResponse(produto);
        }

        public async Task DeletarProduto(DeleteProdutoCommand command)
        {
            await _mediator.Send(command);
        }

        public async Task<IEnumerable<ProdutoResponse>> ConsultarPorCategoria(string categoria)
        {
            var produtos = await _mediator.Send(new GetProdutoByCategoriaQuery(categoria));
            return produtos.Select(p => new ProdutoResponse(p));
        }
    }
}
