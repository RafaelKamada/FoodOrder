using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace FoodOrder.Domain.Entities
{
    public class Cliente
    {
        public Cliente()
        {
            Cpf = string.Empty;
            Nome = string.Empty;
            Email = string.Empty;
            DataCadastro = DateTime.UtcNow;
        }

        public Cliente(string cpf, string nome, string email)
        {
            Cpf = cpf;
            Nome = nome;
            Email = email;
            DataCadastro = DateTime.UtcNow;
        }

        [Key]
        public Guid Id { get; set; }

        [Required(ErrorMessage = "O CPF é obrigatório")]
        public string Cpf { get; set; }

        [Required(ErrorMessage = "O Nome é obrigatório")]
        public string Nome { get; set; }

        [Required(ErrorMessage = "O Email é obrigatório")]
        public string Email { get; set; }

        [JsonIgnore]
        public DateTime DataCadastro { get; set; }

    }
}
