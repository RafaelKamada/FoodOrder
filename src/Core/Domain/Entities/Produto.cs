using FoodOrder.Domain.Entities;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FoodOrder.Domain.Entities
{
    public class Produto
    {
        public Produto()
        {
        }

        public Produto(string nome, Categoria categoria, decimal preco, string descricao, TimeSpan tempoPreparo)
        {
            Nome = nome;
            Categoria = categoria;
            Preco = preco;
            Descricao = descricao;
            TempoPreparo = tempoPreparo;
        }

        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "O nome do produto é obrigatório")]
        [StringLength(100, ErrorMessage = "O nome pode ter no máximo 100 caracteres")]
        public string Nome { get; set; }

        [Required(ErrorMessage = "A categoria do produto é obrigatória")]
        [ForeignKey("CategoriaId")]
        public Categoria Categoria { get; set; }

        [Required(ErrorMessage = "O preço é obrigatório")]
        [Range(0.01, 9999.99, ErrorMessage = "O preço deve estar entre 0.01 e 9999.99")]
        public decimal Preco { get; set; }

        [StringLength(500, ErrorMessage = "A descrição pode ter no máximo 500 caracteres")]
        public string Descricao { get; set; }

        public List<Imagem>? Imagens { get; set; } = new List<Imagem>();

        [Required(ErrorMessage = "O tempo de preparo é obrigatório")]
        public TimeSpan TempoPreparo { get; set; }
    }
}