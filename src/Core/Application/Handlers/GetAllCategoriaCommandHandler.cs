using Application.Commands;
using Application.UseCases.Produtos;
using Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Http;

namespace Application.Handlers
{
    public class GetAllCategoriaCommandHandler : IRequestHandler<GetAllCategoriaQuery, List<Categoria>>
    {
        private readonly IProdutoUseCase _produtoUseCase;

        public GetAllCategoriaCommandHandler(IProdutoUseCase produtoUseCase)
        {
            _produtoUseCase = produtoUseCase;
        }

        public async Task<List<Categoria>> Handle(GetAllCategoriaQuery request, CancellationToken cancellationToken)
        {
            try
            {
                var categoria = await _produtoUseCase.ConsultarCategoria();
                return categoria;
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
