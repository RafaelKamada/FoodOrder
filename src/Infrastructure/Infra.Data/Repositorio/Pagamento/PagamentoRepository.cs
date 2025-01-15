using FoodOrder.Domain.Ports;
using FoodOrder.Infra.Data.Context;
using Microsoft.EntityFrameworkCore;

namespace FoodOrder.Data.Repositorio.Pagamento
{
    public class PagamentoRepository : IPagamentoRepository
    {
        private readonly NpgsqlContext _context;

        public PagamentoRepository(NpgsqlContext context)
        {
            _context = context;
        }

        public async Task<Domain.Entities.Pagamento> AtualizarStatusPagamentoPorId(string idPagamentoMercadoPago, int pagamentoStatusId)
        {
            var pagamento = await _context.Pagamento.FirstOrDefaultAsync(x => x.MercadoPagoId == idPagamentoMercadoPago);
            
            if (pagamento == null) throw new ArgumentNullException(nameof(pagamento));

            pagamento.PagamentoStatusId = pagamentoStatusId;
            
            await _context.SaveChangesAsync();

            return pagamento;
        }

        public async Task<Domain.Entities.Pagamento> Cadastrar(Domain.Entities.Pagamento pagamento)
        {
            if (pagamento == null) throw new ArgumentNullException(nameof(pagamento));

            _context.Pagamento.Add(pagamento);
            await _context.SaveChangesAsync();
            return pagamento;
        }

        public async Task<Domain.Entities.Pagamento> ConsultarPagamentoPorId(int id)
        {
            var pagamento = await _context.Pagamento.FirstOrDefaultAsync(x => x.Id == id);
            return pagamento;
        }

        public async Task<Domain.Entities.Pagamento> VincularIdMercadoPago(string mercadoPagoId, int pagamentoId)
        {
            var pagamento = await _context.Pagamento.FirstOrDefaultAsync(x => x.Id == pagamentoId);

            if (pagamento == null) throw new ArgumentNullException(nameof(pagamento));

            pagamento.MercadoPagoId = mercadoPagoId;

            await _context.SaveChangesAsync();

            return pagamento;
        }
    }
}
