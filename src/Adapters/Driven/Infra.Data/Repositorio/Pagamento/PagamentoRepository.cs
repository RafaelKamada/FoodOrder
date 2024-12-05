using FoodOrder.Domain.Entities;
using FoodOrder.Domain.Ports;
using FoodOrder.Infra.Data.Context;

namespace FoodOrder.Data.Repositorio.Pagamento
{
    public class PagamentoRepository : IPagamentoRepository
    {
        private readonly NpgsqlContext _context;

        public PagamentoRepository(NpgsqlContext context)
        {
            _context = context;
        }

        public async Task<Domain.Entities.Pagamento> Cadastrar(Domain.Entities.Pagamento pagamento)
        {
            if (pagamento == null) throw new ArgumentNullException(nameof(pagamento));

            _context.Pagamento.Add(pagamento);
            await _context.SaveChangesAsync();
            return pagamento;
        }
    }
}
