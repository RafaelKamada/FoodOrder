using FoodOrder.Domain.Entities;

namespace FoodOrder.Domain.Ports
{
    public interface IPagamentoStatusRepository
    {
        Task<PagamentoStatus> Cadastrar(PagamentoStatus pagamentoStatus); 
        Task<PagamentoStatus> ConsultarPorId(int id);
        Task<PagamentoStatus> ConsultarPorStatus(string status);
    }
}
