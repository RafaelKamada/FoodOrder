using Domain.Entities;
using Domain.Ports;
using Infra.Data.Context;
using Microsoft.EntityFrameworkCore;

namespace Infra.Data.Repository
{
    public class PedidoStatusRepository : IPedidoStatusRepository
    {
        private readonly NpgsqlContext _context;

        public PedidoStatusRepository(NpgsqlContext context)
        {
            _context = context;
        }

        public async Task<PedidoStatus> Cadastrar(PedidoStatus pedidoStatus)
        {
            if (pedidoStatus == null) throw new ArgumentNullException(nameof(pedidoStatus));

            var pedidoStatusBase = await ConsultarPorStatus(pedidoStatus.Descricao);

            if (pedidoStatusBase == null)
            {
                await _context.PedidoStatus.AddAsync(pedidoStatus);
                await _context.SaveChangesAsync();
                return pedidoStatus;
            }
            else
            {
                return pedidoStatusBase;
            }
        }

        public async Task<PedidoStatus> ConsultarPorStatus(String status)
        {
            var pedidoStatus = await _context.PedidoStatus.Where(x => x.Descricao == status).ToListAsync();
            return pedidoStatus.FirstOrDefault();
        }
    }
}
