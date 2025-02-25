using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace FoodOrder.Domain.Entities
{
    public class PedidoStatus
    {
        public PedidoStatus()
        {
        }

        public PedidoStatus(string descricao)
        {
            Descricao = descricao;
            DataCriacao = DateTime.UtcNow;
        }

        [Key]
        public int Id { get; set; }

        [Required]
        public string Descricao { get; set; }

        [JsonIgnore]
        public DateTime DataCriacao { get; set; }
    }
}