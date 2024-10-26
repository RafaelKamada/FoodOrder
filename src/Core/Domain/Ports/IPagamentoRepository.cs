using Domain.Entities;

namespace Domain.Ports
{
    public interface IPagamentoRepository
    {
        Task<Pagamento> Cadastrar(Pagamento pagamento);
    }
}
