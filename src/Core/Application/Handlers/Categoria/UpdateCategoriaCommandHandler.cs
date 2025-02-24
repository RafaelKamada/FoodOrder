using FoodOrder.Application.UseCases.Produtos;
using FoodOrder.Domain.Entities;
using FoodOrder.Application.Commands;
using MediatR;
using Microsoft.AspNetCore.Http;

namespace FoodOrder.Application.Handlers.Categoria
{
    public class UpdateCategoriaCommandHandler : IRequestHandler<UpdateCategoriaCommand, Unit>
    {
        private readonly ICategoriaUseCase _produtoUseCase;

        public UpdateCategoriaCommandHandler(ICategoriaUseCase produtoUseCase)
        {
            _produtoUseCase = produtoUseCase;
        }

        public async Task<Unit> Handle(UpdateCategoriaCommand request, CancellationToken cancellationToken)
        {
            try
            {
                if (!request.ValidateId())
                    new ArgumentException("Id é requerido!");

                var dto = new Domain.Entities.Categoria(request.Id, request.Nome, request.Tipo);

                await _produtoUseCase.Atualizar(dto);

                return Unit.Value;
            }
            catch (Exception)
            {
                throw;
            }
        }
    }

}
