using System.ComponentModel.DataAnnotations;

namespace Domain.Entities
{
    public class Sacola
    {
        public Sacola()
        {
            DataCriacao = DateTime.UtcNow;
        }

        [Key]
        public int Id { get; set; }

        public DateTime DataCriacao { get; set; }
    }
}