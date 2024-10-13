using Application.Commands;
using Application.UseCases.Produtos;
using Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Http;

namespace Application.Handlers
{
    public class AddCategoriaCommandHandler : IRequestHandler<AddCategoriaCommand, Unit>
    {
        private readonly IProdutoUseCase _produtoUseCase;

        public AddCategoriaCommandHandler(IProdutoUseCase produtoUseCase)
        {
            _produtoUseCase = produtoUseCase;
        }

        public async Task<Unit> Handle(AddCategoriaCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var categoria = await ConsultarCategoria(request);

                if (!categoria)
                {
                    new ArgumentException("Categoria já cadastrada no banco de dados");
                }

                var salvarCategoria = new Categoria(request.Nome, request.Tipo);

                await _produtoUseCase.Cadastrar(salvarCategoria);

                return Unit.Value;
            }
            catch (Exception)
            {
                throw;
            }
        }

        /// <summary>
        /// Verifica se a categoria informada existe no banco de dados
        /// </summary>
        /// <param name="request"></param>
        /// <returns>Retorna true se a categoria existir, caso contrário, false.</returns>
        /// <exception cref="ArgumentException"></exception>
        private async Task<bool> ConsultarCategoria(AddCategoriaCommand request)
        {
            if (string.IsNullOrWhiteSpace(request.Nome))
                throw new ArgumentException("Categoria não informada!");

            var categoria = await _produtoUseCase.ConsultarCategoria(request.Nome);

            return categoria != null;
        }
    }

}
