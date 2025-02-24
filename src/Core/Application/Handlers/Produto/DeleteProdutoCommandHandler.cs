using FoodOrder.Application.Commands;
using FoodOrder.Application.UseCases.Produtos;
using MediatR;

namespace FoodOrder.Application.Handlers.Produto
{
    public class DeleteProdutoCommandHandler : IRequestHandler<DeleteProdutoCommand, Unit>
    {
        private readonly ICategoriaUseCase _produtoUseCase;

        public DeleteProdutoCommandHandler(ICategoriaUseCase produtoUseCase)
        {
            _produtoUseCase = produtoUseCase;
        }

        public async Task<Unit> Handle(DeleteProdutoCommand request, CancellationToken cancellationToken)
        {
            try
            {
                if (!request.ValidateId())
                    new ArgumentException("Id é requerido!");

                await _produtoUseCase.Deletar(request.Id);

                return Unit.Value;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }

}
