using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Imagem
    {
        [Key] 
        public int Id { get; set; }

        [Required]
        public byte[] Data { get; set; }

        [Required] 
        [StringLength(255)] 
        public string Nome { get; set; } 

        [Required]
        public int ProdutoId { get; set; }

        [ForeignKey("ProdutoId")]
        public Produto Produto { get; set; }
    }

}
