using Microsoft.EntityFrameworkCore;
using Domain.Entities;
using Infra.Data.Configurations;

namespace Infra.Data.Context
{
    public class NpgsqlContext : DbContext
    {
        private readonly IConnectionStringProvider _connectionStringProvider;

        public NpgsqlContext(IConnectionStringProvider connectionStringProvider)
        {
            _connectionStringProvider = connectionStringProvider;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseNpgsql(_connectionStringProvider.GetConnectionString("DefaultConnection"));
        }

        public DbSet<Cliente> Clientes { get; set; }
        public DbSet<Produto> Produtos { get; set; }
        public DbSet<Categoria> Categoria { get; set; }
    }
}
