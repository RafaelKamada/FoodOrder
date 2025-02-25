using FoodOrder.Application.Queries;
using FoodOrder.Domain.Entities;
using FoodOrder.Domain.Ports;
using MediatR;

namespace FoodOrder.Application.Handlers.Produto
{
    public class GetProdutoByCategoriaQueryHandler : IRequestHandler<GetProdutoByCategoriaQuery, List<ProdutoDto>>
    {
        private readonly IProdutoRepository _produtoRepository;

        public GetProdutoByCategoriaQueryHandler(IProdutoRepository produtoRepository)
        {
            _produtoRepository = produtoRepository;
        }

        public async Task<List<ProdutoDto>> Handle(GetProdutoByCategoriaQuery request, CancellationToken cancellationToken)
        {
            return await _produtoRepository.ConsultarPorCategoria(request.Categoria);
        }
    }
}
