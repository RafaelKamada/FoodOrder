using Domain.Entities;
using MediatR;

namespace Application.Queries
{
    public class GetProdutoByCategoriaQuery : IRequest<List<ProdutoDto>>
    {
        public string Categoria { get; }

        public GetProdutoByCategoriaQuery(string categoria)
        {
            Categoria = categoria;
        }

    }
}
