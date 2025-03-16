using FoodOrder.Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Http;

namespace FoodOrder.Application.DTOs
{
    public class ProdutoResponse
    {
        private Unit produto;

        public int Id { get; set; }
        public string Nome { get; set; }
        public Categoria Categoria { get; set; }
        public decimal Preco { get; set; }
        public string Descricao { get; set; }
        public List<ImagemDto>? Imagens { get; set; }
        public TimeSpan TempoPreparo { get; set; }

        public ProdutoResponse(Produto produto)
        {
            Id = produto.Id;
            Nome = produto.Nome;
            Categoria = produto.Categoria;
            Preco = produto.Preco;
            Descricao = produto.Descricao;
            //Imagens = produto.Imagens ?? new List<Imagem>();
            TempoPreparo = produto.TempoPreparo;
        }

        public ProdutoResponse(ProdutoDto produto)
        {
            Id = produto.Id;
            Nome = produto.Nome;
            Categoria = produto.Categoria;
            Preco = produto.Preco;
            Descricao = produto.Descricao;
            //Imagens = produto.Imagens ?? new List<Imagem>();
            TempoPreparo = produto.TempoPreparo;
        }

        public ProdutoResponse(Unit produto)
        {
            this.produto = produto;
        }
    }
}
