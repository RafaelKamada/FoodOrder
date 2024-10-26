using Domain.Entities;
using Domain.Ports;
using Infra.Data.Context;

namespace Infra.Data.Repository
{
    public class PagamentoRepository : IPagamentoRepository
    {
        private readonly NpgsqlContext _context;

        public PagamentoRepository(NpgsqlContext context)
        {
            _context = context;
        }

        public async Task<Pagamento> Cadastrar(Pagamento pagamento)
        {
            if (pagamento == null) throw new ArgumentNullException(nameof(pagamento));

            _context.Pagamento.Add(pagamento);
            await _context.SaveChangesAsync();
            return pagamento;
        }
    }
}
