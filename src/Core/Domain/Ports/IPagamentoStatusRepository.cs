using Domain.Entities;

namespace Domain.Ports
{
    public interface IPagamentoStatusRepository
    {
        Task<PagamentoStatus> Cadastrar(PagamentoStatus pagamentoStatus);
    }
}
