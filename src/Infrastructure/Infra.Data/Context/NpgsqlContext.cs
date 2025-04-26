using Microsoft.EntityFrameworkCore;
using FoodOrder.Domain.Entities;
using FoodOrder.Data.Configurations;

namespace FoodOrder.Data.Context;

public class NpgsqlContext(IConnectionStringProvider connectionStringProvider) : DbContext
{
    private readonly IConnectionStringProvider _connectionStringProvider = connectionStringProvider;

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseNpgsql(_connectionStringProvider.GetConnectionString("DefaultConnection"));
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Cliente>().HasIndex(c => c.Cpf).IsUnique().HasDatabaseName("UN_Cliente_Cpf");
    }

    public DbSet<Cliente> Clientes { get; set; }
}
