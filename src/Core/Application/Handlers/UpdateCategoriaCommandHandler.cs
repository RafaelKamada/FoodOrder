using Application.Commands;
using Application.UseCases.Produtos;
using Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Http;

namespace Application.Handlers
{
    public class UpdateCategoriaCommandHandler : IRequestHandler<UpdateCategoriaCommand, Unit>
    {
        private readonly IProdutoUseCase _produtoUseCase;

        public UpdateCategoriaCommandHandler(IProdutoUseCase produtoUseCase)
        {
            _produtoUseCase = produtoUseCase;
        }

        public async Task<Unit> Handle(UpdateCategoriaCommand request, CancellationToken cancellationToken)
        {
            try
            {
                if (!request.ValidateId())
                    new ArgumentException("Id é requerido!");

                var dto = new Categoria(request.Id, request.Nome, request.Tipo);

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
