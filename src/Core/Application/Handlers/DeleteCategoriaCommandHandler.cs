﻿using Application.Commands;
using Application.UseCases.Produtos;
using Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Http;

namespace Application.Handlers
{
    public class DeleteCategoriaCommandHandler : IRequestHandler<DeleteCategoriaCommand, Unit>
    {
        private readonly IProdutoUseCase _produtoUseCase;

        public DeleteCategoriaCommandHandler(IProdutoUseCase produtoUseCase)
        {
            _produtoUseCase = produtoUseCase;
        }

        public async Task<Unit> Handle(DeleteCategoriaCommand request, CancellationToken cancellationToken)
        {
            try
            {
                if (!request.ValidateId())
                    new ArgumentException("Id é requerido!");

                var produto = await ValidarProduto(request.Id);

                if (!produto)
                    new ArgumentException("Existe produto salvo para essa categoria!");

                await _produtoUseCase.DeletarCategoria(request.Id);

                return Unit.Value;
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
