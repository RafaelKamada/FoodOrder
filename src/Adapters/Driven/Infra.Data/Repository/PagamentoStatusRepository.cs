using Domain.Entities;
using Domain.Ports;
using Infra.Data.Context;
using Microsoft.EntityFrameworkCore;

namespace Infra.Data.Repository
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

            return pagamentoStatus;
        }

        public async Task<PagamentoStatus> ConsultarPorStatus(String status)
        {
            var pagamentoStatus = await _context.PagamentoStatus.Where(x => x.Descricao == status).ToListAsync();
            return pagamentoStatus.FirstOrDefault();
        }
    }
}
