using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.UseCases.Produtos
{
    public interface IProdutoUseCase
    {
        Task<Produto> Cadastrar(Produto produto);
        Task<List<Produto>> ConsultarPorCategoria(string categoria);
        Task<Categoria> Cadastrar(Categoria categoria);
        Task<Categoria> Atualizar(Categoria categoria);
        Task<Categoria> DeletarCategoria(int id);
        Task<Categoria> ConsultarCategoria(string categoria);
        Task<List<Categoria>> ConsultarCategoria();
        Task<List<Produto>> ConsultarPorCategoriaId(int id);
    }
}
