using FoodOrder.Application.Commands;
using FoodOrder.Application.UseCases.Produtos;
using MediatR;

namespace FoodOrder.Application.Handlers.Categoria
{
    public class GetAllCategoriaCommandHandler : IRequestHandler<GetAllCategoriaQuery, List<Domain.Entities.Categoria>>
    {
        private readonly ICategoriaUseCase _produtoUseCase;

        public GetAllCategoriaCommandHandler(ICategoriaUseCase produtoUseCase)
        {
            _produtoUseCase = produtoUseCase;
        }

        public async Task<List<Domain.Entities.Categoria>> Handle(GetAllCategoriaQuery request, CancellationToken cancellationToken)
        {
            try
            {
                var categoria = await _produtoUseCase.Consultar();
                return categoria;
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
