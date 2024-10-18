using Application.Commands;
using Application.UseCases.Produtos;
using Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Http;

namespace Application.Handlers
{
    public class GetAllCategoriaCommandHandler : IRequestHandler<GetAllCategoriaCommand, List<Categoria>>
    {
        private readonly IProdutoUseCase _produtoUseCase;

        public GetAllCategoriaCommandHandler(IProdutoUseCase produtoUseCase)
        {
            _produtoUseCase = produtoUseCase;
        }

        public async Task<List<Categoria>> Handle(GetAllCategoriaCommand request, CancellationToken cancellationToken)
        {
            try
            {
                return await _produtoUseCase.ConsultarCategoria();
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
