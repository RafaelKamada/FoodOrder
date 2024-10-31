using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Ports
{
    public interface IProdutoRepository
    {
        Task<Produto> Cadastrar(Produto produto);
        Task<List<ProdutoDto>> ConsultarPorCategoria(string categoria);
        Task<List<Produto>> ConsultarProdutoPorCategoriaId(int id);
        Task<Produto> Atualizar(Produto categoria);
        Task<Produto> Deletar(int id);
        Task<Produto> ConsultarPorId(int id);
        Task<Categoria> Cadastrar(Categoria categoria);
        Task<Categoria> Atualizar(Categoria categoria);
        Task<Categoria> DeletarCategoria(int id);
        Task<Categoria> ConsultarCategoria(string categoria);
        Task<List<Categoria>> ConsultarCategoria();
    }
}
