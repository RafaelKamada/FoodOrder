using FoodOrder.Application.UseCases.Produtos;
using FoodOrder.Application.Commands;
using FoodOrder.Domain.Entities;
using MediatR;

namespace FoodOrder.Application.Handlers.Categoria
{
    public class AddCategoriaCommandHandler : IRequestHandler<AddCategoriaCommand, Unit>
    {
        private readonly ICategoriaUseCase _useCase;

        public AddCategoriaCommandHandler(ICategoriaUseCase produtoUseCase)
        {
            _useCase = produtoUseCase;
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

                var salvarCategoria = new Domain.Entities.Categoria(request.Nome.ToLower().Trim(), request.Tipo);

                await _useCase.Cadastrar(salvarCategoria);

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

            var categoria = await _useCase.Consultar(request.Nome.ToLower().Trim());

            return categoria != null;
        }
    }

}
