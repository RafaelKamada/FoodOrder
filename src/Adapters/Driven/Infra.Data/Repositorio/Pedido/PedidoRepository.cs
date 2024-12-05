using FoodOrder.Domain.Ports;
using FoodOrder.Infra.Data.Context;
using Microsoft.EntityFrameworkCore;

namespace FoodOrder.Data.Repositorio.Pedido
{
    public class PedidoRepository : IPedidoRepository
    {
        private readonly NpgsqlContext _context;

        public PedidoRepository(NpgsqlContext context)
        {
            _context = context;
        }

        public async Task<Domain.Entities.Pedido> Cadastrar(Domain.Entities.Pedido pedido)
        {
            if (pedido == null) throw new ArgumentNullException(nameof(pedido));

            _context.Pedidos.Add(pedido);
            await _context.SaveChangesAsync();
            return pedido;
        }

        public async Task<List<Domain.Entities.Pedido>> ListarPedidos()
        {
            return await _context.Pedidos.ToListAsync();
        }
    }
}
