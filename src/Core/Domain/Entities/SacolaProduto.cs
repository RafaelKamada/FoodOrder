using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Entities
{
    public class SacolaProduto
    {
        public SacolaProduto()
        {

        }

        public SacolaProduto(Sacola sacola, Produto produto)
        {
            Sacola = sacola;
            Produto = produto;
        }


        [Key]
        public int Id { get; set; }

        [ForeignKey("SacolaId")]
        public Sacola Sacola { get; set; }

        [ForeignKey("ProdutoId")]
        public Produto Produto { get; set; }
    }
}
