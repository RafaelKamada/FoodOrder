using Application.Commands;
using Application.UseCases.Produtos;
using Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Http;

namespace Application.Handlers
{
    public class AddProdutoCommandHandler : IRequestHandler<AddProdutoCommand, Unit>
    {
        private readonly IProdutoUseCase _produtoUseCase;

        public AddProdutoCommandHandler(IProdutoUseCase produtoUseCase)
        {
            _produtoUseCase = produtoUseCase;
        }

        public async Task<Unit> Handle(AddProdutoCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var categoria = await ConsultarCategoria(request);

                var produto = new Produto(request.Nome, categoria, request.Preco, request.Descricao, request.TempoPreparo);

                await AdicionarImagensAoProduto(request.Imagens, produto);

                await _produtoUseCase.Cadastrar(produto);

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
        private async Task<Categoria> ConsultarCategoria(AddProdutoCommand request)
        {
            if (string.IsNullOrWhiteSpace(request.Categoria))
                throw new ArgumentException("Categoria não informada!");

            var categoria = await _produtoUseCase.ConsultarCategoria(request.Categoria);

            return categoria ?? throw new KeyNotFoundException("Categoria não cadastrada!");
        }

        /// <summary>
        /// Carrega as imagens para o produto
        /// </summary>
        /// <param name="arquivos"></param>
        /// <param name="produto"></param>
        /// <returns></returns>
        private async Task AdicionarImagensAoProduto(IEnumerable<IFormFile> arquivos, Produto produto)
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
