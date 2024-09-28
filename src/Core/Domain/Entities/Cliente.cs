using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Cliente
    {
        public Cliente(string cpf, string nome, string email)
        {
            CPF = cpf;
            Nome = nome;
            Email = email;

            ValidaEntidade();
        }

        public string CPF { get; set; }
        
        public string Nome { get; set; }

        public string Email { get; set; }

        public void ValidaEntidade()
        {
            if (string.IsNullOrEmpty(CPF))
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
