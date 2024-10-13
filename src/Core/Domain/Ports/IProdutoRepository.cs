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
        Task<List<Produto>> ConsultarPorCategoria(string categoria);
        Task<Categoria> Cadastrar(Categoria categoria);
        Task<Categoria> ConsultarCategoria(string categoria);
    }
}
