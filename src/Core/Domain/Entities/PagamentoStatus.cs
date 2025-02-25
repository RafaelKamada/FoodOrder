using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace FoodOrder.Domain.Entities
{
    public class PagamentoStatus
    {
        public PagamentoStatus()
        {
        }
        public PagamentoStatus(string descricao)
        {
            Descricao = descricao;
            DataCriacao = DateTime.UtcNow;
        }

        [Key, JsonIgnore]
        public int Id { get; set; }

        [Required]
        public string Descricao { get; set; }

        [JsonIgnore]
        public DateTime DataCriacao { get; set; }

    }
}