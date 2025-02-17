using FoodOrder.Application.Commands;
using FoodOrder.Application.DTOs;
using FoodOrder.Application.UseCases.Produtos;
using MediatR;

namespace FoodOrder.Application.Handlers.Categoria
{
    public class GetAllCategoriaQueryHandler : IRequestHandler<GetAllCategoriaQuery, List<CategoriaResponse>>
    {
        private readonly ICategoriaUseCase _categoriaUseCase;

        public GetAllCategoriaQueryHandler(ICategoriaUseCase categoriaUseCase)
        {
            _categoriaUseCase = categoriaUseCase;
        }

        public async Task<List<CategoriaResponse>> Handle(GetAllCategoriaQuery request, CancellationToken cancellationToken)
        {
            var categorias = await _categoriaUseCase.Consultar();

            return categorias.Select(c => new CategoriaResponse
            {
                Id = c.Id,
                Nome = c.Nome,
                Tipo = c.Tipo
            }).ToList();
        }
    }
}
