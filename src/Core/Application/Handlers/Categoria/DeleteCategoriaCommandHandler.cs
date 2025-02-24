using FoodOrder.Application.UseCases.Produtos;
using FoodOrder.Application.Commands;
using MediatR;

namespace FoodOrder.Application.Handlers.Categoria
{
    public class DeleteCategoriaCommandHandler : IRequestHandler<DeleteCategoriaCommand, Unit>
    {
        private readonly IProdutoUseCase _produtoUseCase;
        private readonly ICategoriaUseCase _useCase;

        public DeleteCategoriaCommandHandler(ICategoriaUseCase useCase,
                                             IProdutoUseCase produtoUseCase)
        {
            _useCase = useCase;
            _produtoUseCase = produtoUseCase;
        }

        public async Task<Unit> Handle(DeleteCategoriaCommand request, CancellationToken cancellationToken)
        {
            try
            {
                if (!request.ValidateId())
                    new ArgumentException("Id é requerido!");

                var produto = await ValidarProduto(request.Id);

                if (!produto)
                    new ArgumentException("Existe produto salvo para essa categoria!");

                await _useCase.Deletar(request.Id);

                return Unit.Value;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<bool> ValidarProduto(int id)
        {
            var produto = await _produtoUseCase.ConsultarPorCategoriaId(id);

            return produto.Count != 0;
        }
    }

}
