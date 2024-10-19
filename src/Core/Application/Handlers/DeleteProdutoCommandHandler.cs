using Application.Commands;
using Application.UseCases.Produtos;
using Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Http;

namespace Application.Handlers
{
    public class DeleteProdutoCommandHandler : IRequestHandler<DeleteProdutoCommand, Unit>
    {
        private readonly IProdutoUseCase _produtoUseCase;

        public DeleteProdutoCommandHandler(IProdutoUseCase produtoUseCase)
        {
            _produtoUseCase = produtoUseCase;
        }

        public async Task<Unit> Handle(DeleteProdutoCommand request, CancellationToken cancellationToken)
        {
            try
            {
                if (!request.ValidateId())
                    new ArgumentException("Id é requerido!");

                await _produtoUseCase.DeletarCategoria(request.Id);

                return Unit.Value;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }

}
