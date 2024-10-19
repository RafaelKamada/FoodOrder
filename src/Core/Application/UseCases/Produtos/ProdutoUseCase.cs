using Domain.Entities;
using Domain.Ports;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.UseCases.Produtos
{
    public class ProdutoUseCase : IProdutoUseCase
    {
        private readonly IProdutoRepository _produtoRepository;

        public ProdutoUseCase(IProdutoRepository produtoRepository)
        {
            _produtoRepository = produtoRepository;
        }
        #region PRODUTO
        public Task<Produto> Cadastrar(Produto produto)
        {
            return _produtoRepository.Cadastrar(produto);
        }

        public Task<List<Produto>> ConsultarPorCategoria(string categoria)
        {
            return _produtoRepository.ConsultarPorCategoria(categoria);
        }

        public Task<List<Produto>> ConsultarPorCategoriaId(int id)
        {
            return _produtoRepository.ConsultarProdutoPorCategoriaId(id);
        }
        public Task<Produto> Atualizar(Produto categoria)
        {
            return _produtoRepository.Atualizar(categoria);
        }

        public Task<Produto> Deletar(int id)
        {
            return _produtoRepository.Deletar(id);
        }

        #endregion

        #region CATEGORIA
        public Task<Categoria> Cadastrar(Categoria categoria)
        {
            return _produtoRepository.Cadastrar(categoria);
        }

        public Task<Categoria> Atualizar(Categoria categoria)
        {
            return _produtoRepository.Atualizar(categoria);
        }

        public Task<Categoria> DeletarCategoria(int id)
        {
            return _produtoRepository.DeletarCategoria(id);
        }

        public Task<Categoria> ConsultarCategoria(string categoria)
        {
            return _produtoRepository.ConsultarCategoria(categoria);
        }

        public Task<List<Categoria>> ConsultarCategoria()
        {
            return _produtoRepository.ConsultarCategoria();
        }
        #endregion
    }
}
