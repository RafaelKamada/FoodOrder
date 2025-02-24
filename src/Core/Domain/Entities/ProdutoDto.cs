using FoodOrder.Domain.Entities;

namespace FoodOrder.Domain.Entities
{
    public class ProdutoDto
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public Categoria Categoria { get; set; }
        public decimal Preco { get; set; }
        public string Descricao { get; set; }
        public List<ImagemDto>? Imagens { get; set; }
        public TimeSpan TempoPreparo { get; set; }
    }
}