using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FoodOrder.Domain.Entities
{
    public class SacolaProduto
    {
        public SacolaProduto()
        {

        }

        public SacolaProduto(int sacolaId, int produtoId)
        {
            SacolaId = sacolaId;
            ProdutoId = produtoId;
        }


        [Key]
        public int Id { get; set; }

        [ForeignKey("SacolaId")]
        public int SacolaId { get; set; }

        [ForeignKey("ProdutoId")]
        public int ProdutoId { get; set; }
    }
}
