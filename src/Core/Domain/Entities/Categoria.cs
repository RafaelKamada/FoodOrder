using System.ComponentModel.DataAnnotations;

namespace FoodOrder.Domain.Entities
{
    public class Categoria
    {
        public Categoria()
        {
            Nome = string.Empty; 
            Tipo = string.Empty;
        }

        public Categoria(string nome, string tipo)
        {
            Nome = nome;
            Tipo = tipo;
        }

        public Categoria(int id, string nome, string tipo)
        {
            Id = id;
            Nome = nome;
            Tipo = tipo;
        }

        [Key]
        public int Id { get; set; }
        [Required]
        public string Nome { get; set; }
        [Required]
        public string Tipo { get; set; }
    }
}
