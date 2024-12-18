using FoodOrder.Domain.Entities;

namespace FoodOrder.Domain.Ports
{
    public interface IPagamentoRepository
    {
        Task<Pagamento> Cadastrar(Pagamento pagamento); 
        Task<Pagamento> ConsultarPagamentoPorId(int id);
    }
}
