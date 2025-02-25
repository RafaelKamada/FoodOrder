using Microsoft.EntityFrameworkCore;
using FoodOrder.Domain.Entities;
using FoodOrder.Infra.Data.Configurations;

namespace FoodOrder.Infra.Data.Context
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
            modelBuilder.Entity<Cliente>().HasIndex(c => c.Cpf).IsUnique().HasDatabaseName("UN_Cliente_Cpf");

            modelBuilder.HasSequence<int>("numero_pedido_seq", schema: "public")
            .StartsAt(1)
            .IncrementsBy(1);

            modelBuilder.Entity<Pedido>()
                .Property(p => p.NumeroPedido)
                .HasDefaultValueSql("nextval('public.numero_pedido_seq')");
            base.OnModelCreating(modelBuilder);
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
