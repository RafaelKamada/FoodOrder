using Microsoft.EntityFrameworkCore;
using Domain.Entities;

namespace Infra.Data.Context
{
    public class NpgsqlContext : DbContext
    {
        public NpgsqlContext(DbContextOptions<NpgsqlContext> options) : base(options)
        { }

        public virtual DbSet<Cliente> Clientes { get; set; }

    }
}
