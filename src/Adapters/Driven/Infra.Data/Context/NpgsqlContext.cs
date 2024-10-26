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

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //base.OnModelCreating(modelBuilder);
            //modelBuilder.HasSequence<int>("PedidoSequencia", schema: "public").StartsAt(1).IncrementsBy(1).HasMin(1);
            //modelBuilder.Entity<Pedido>().Property(p => p.NumeroPedido).HasDefaultValueSql("nextval('public.PedidoSequencia')");
            modelBuilder.Entity<Cliente>().HasIndex(c => c.Cpf).IsUnique().HasDatabaseName("UN_Cliente_Cpf");
        }

        public DbSet<Cliente> Clientes { get; set; }
        public DbSet<Produto> Produtos { get; set; }
        public DbSet<Categoria> Categoria { get; set; }
        public DbSet<Pedido> Pedidos { get; set; }
        public DbSet<Sacola> Sacola { get; set; }
        public DbSet<SacolaProduto> SacolasProdutos { get; set; }
        public DbSet<Pagamento> Pagamento { get; set; }
        public DbSet<PagamentoStatus> PagamentoStatus { get; set; }
        public DbSet<PedidoStatus> PedidoStatus { get; set; }
    }
}
