using Application.Queries;
using Domain.Entities;
using Domain.Ports;
using MediatR;

namespace Application.Handlers
{
    public class GetProdutoByCategoriaQueryHandler : IRequestHandler<GetProdutoByCategoriaQuery, List<Produto>>
    {
        private readonly IProdutoRepository _produtoRepository;

        public GetProdutoByCategoriaQueryHandler(IProdutoRepository produtoRepository)
        {
            _produtoRepository = produtoRepository;
        }

        public async Task<List<Produto>> Handle(GetProdutoByCategoriaQuery request, CancellationToken cancellationToken)
        {
            return await _produtoRepository.ConsultarPorCategoria(request.Categoria);
        }
    }
}
