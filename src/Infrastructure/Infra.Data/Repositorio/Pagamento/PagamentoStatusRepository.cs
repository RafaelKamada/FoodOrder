using FoodOrder.Domain.Entities;
using FoodOrder.Domain.Ports;
using FoodOrder.Infra.Data.Context;
using Microsoft.EntityFrameworkCore;

namespace FoodOrder.Data.Repositorio.Pagamento
{
    public class PagamentoStatusRepository : IPagamentoStatusRepository
    {
        private readonly NpgsqlContext _context;

        public PagamentoStatusRepository(NpgsqlContext context)
        {
            _context = context;
        }

        public async Task<PagamentoStatus> Cadastrar(PagamentoStatus pagamentoStatus)
        {
            if (pagamentoStatus == null) throw new ArgumentNullException(nameof(pagamentoStatus));

            var pagamentoStatusBase = await ConsultarPorStatus(pagamentoStatus.Descricao);

            if (pagamentoStatusBase == null)
            {
                _context.PagamentoStatus.Add(pagamentoStatus);
                await _context.SaveChangesAsync();
            }
            else
            {
                return pagamentoStatusBase;
            }

            return pagamentoStatus;
        }

        public async Task<PagamentoStatus> ConsultarPorStatus(string status)
        {
            var pagamentoStatus = await _context.PagamentoStatus.Where(x => x.Descricao == status).ToListAsync();
            return pagamentoStatus.FirstOrDefault();
        }

        public async Task<PagamentoStatus> ConsultarPorId(int id)
        {
            var pagamentoStatus = await _context.PagamentoStatus.Where(x => x.Id == id).ToListAsync();
            return pagamentoStatus.FirstOrDefault();
        }
    }
}
