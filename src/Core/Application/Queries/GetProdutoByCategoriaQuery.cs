using Domain.Entities;
using MediatR;

namespace Application.Queries
{
    public class GetProdutoByCategoriaQuery : IRequest<List<Produto>>
    {
        public string Categoria { get; }

        public GetProdutoByCategoriaQuery(string categoria)
        {
            Categoria = categoria;
        }

    }
}
