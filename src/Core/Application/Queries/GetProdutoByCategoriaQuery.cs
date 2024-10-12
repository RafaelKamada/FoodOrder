using Domain.Entities;
using MediatR;

namespace Application.Queries
{
    public class GetProdutoByCategoriaQuery : IRequest<Produto>
    {
        private string Categoria { get; }

        public GetProdutoByCategoriaQuery(string categoria)
        {
            Categoria = categoria;
        }

    }
}
