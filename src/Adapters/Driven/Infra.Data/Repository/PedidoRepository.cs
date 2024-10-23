using Domain.Entities;
using Domain.Ports;
using Infra.Data.Context;
using Microsoft.EntityFrameworkCore;

namespace Infra.Data.Repository
{
    public class PedidoRepository : IPedidoRepository
    {
        private readonly NpgsqlContext _context;

        public PedidoRepository(NpgsqlContext context)
        {
            _context = context;
        }

        public async Task<Pedido> Cadastrar(Pedido pedido)
        {
            if (pedido == null) throw new ArgumentNullException(nameof(pedido));

            _context.Pedidos.Add(pedido);
            await _context.SaveChangesAsync();
            return pedido;
        }

        public async Task<List<Pedido>> ListarPedidos()
        {
            return await _context.Pedidos.ToListAsync();
        }
    }
}
