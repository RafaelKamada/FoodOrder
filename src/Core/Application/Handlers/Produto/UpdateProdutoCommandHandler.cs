using FoodOrder.Application.Commands;
using FoodOrder.Application.UseCases.Produtos;
using FoodOrder.Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Http;

namespace FoodOrder.Application.Handlers.Produto
{
    public class UpdateProdutoCommandHandler : IRequestHandler<UpdateProdutoCommand, Unit>
    {
        private readonly IProdutoUseCase _produtoUseCase;
        private readonly ICategoriaUseCase _categoriaUseCase;

        public UpdateProdutoCommandHandler(IProdutoUseCase produtoUseCase, ICategoriaUseCase categoriaUseCase)
        {
            _produtoUseCase = produtoUseCase;
            _categoriaUseCase = categoriaUseCase;
        }

        public async Task<Unit> Handle(UpdateProdutoCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var categoria = await ConsultarCategoria(request);

                var produto = new FoodOrder.Domain.Entities.Produto(request.Nome, categoria, request.Preco, request.Descricao, request.TempoPreparo);

                await AdicionarImagensAoProduto(request.Imagens, produto);

                await _produtoUseCase.Atualizar(produto);

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
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
        private async Task<FoodOrder.Domain.Entities.Categoria> ConsultarCategoria(UpdateProdutoCommand request)
        {
            if (string.IsNullOrWhiteSpace(request.Categoria))
                throw new ArgumentException("Categoria não informada!");

            var categoria = await _categoriaUseCase.Consultar(request.Categoria);

            return categoria ?? throw new KeyNotFoundException("Categoria não cadastrada!");
        }

        /// <summary>
        /// Carrega as imagens para o produto
        /// </summary>
        /// <param name="arquivos"></param>
        /// <param name="produto"></param>
        /// <returns></returns>
        private async Task AdicionarImagensAoProduto(IEnumerable<IFormFile> arquivos, Domain.Entities.Produto produto)
        {
            if (arquivos != null)
            {
                foreach (var file in arquivos)
                {
                    using (var memoryStream = new MemoryStream())
                    {
                        await file.CopyToAsync(memoryStream);

                        var imagem = new Imagem
                        {
                            Data = memoryStream.ToArray(),
                            Nome = file.FileName,
                            Produto = produto
                        };

                        produto.Imagens.Add(imagem);
                    }
                }
            }
        }
    }

}
