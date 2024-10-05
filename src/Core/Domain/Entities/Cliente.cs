using System.ComponentModel.DataAnnotations;

namespace Domain.Entities
{
    public class Cliente
    {
        [Key]
        public Guid Id { get; set; }

        public string Cpf { get; set; }

        public string Nome { get; set; }

        public string Email { get; set; }

        public Cliente(string cpf, string nome, string email)
        {
            Cpf = cpf;
            Nome = nome;
            Email = email;

            ValidaEntidade();
        }

        public void ValidaEntidade()
        {
            if (string.IsNullOrEmpty(Cpf))
            {
                throw new Exception("CPF inválido");
            }

            if (string.IsNullOrEmpty(Nome))
            {
                throw new Exception("Nome inválido");
            }

            if (string.IsNullOrEmpty(Email))
            {
                throw new Exception("Email inválido");
            }
        }
    }
}
