using FluentAssertions;
using FoodOrder.Data.Configurations;
using FoodOrder.Data.Context;
using FoodOrder.Data.Repositorio;
using FoodOrder.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Moq;

namespace FoodOrder.Tests.Infrastructure.Repositorio;

public class ClienteRepositoryTests
{
    private readonly Mock<IConnectionStringProvider> _connectionStringProviderMock;
    private readonly DbContextOptions<NpgsqlContext> _options;

    public ClienteRepositoryTests()
    {
        _connectionStringProviderMock = new Mock<IConnectionStringProvider>();
        _connectionStringProviderMock.Setup(provider => provider.GetConnectionString("DefaultConnection"))
            .Returns("Host=localhost;Port=5432;Username=test;Password=test;Database=testdb");

        _options = new DbContextOptionsBuilder<NpgsqlContext>()
               .UseInMemoryDatabase(databaseName: "ClienteDb")
               .Options;
    }

    [Fact]
    public async Task Cadastrar_DeveAdicionarCliente()
    {
        // Arrange
        using var context = new NpgsqlContext(_connectionStringProviderMock.Object, isTesting: true);
        var repo = new ClienteRepository(context);

        var cliente = new Cliente("11122233344", "Pedro", "pedro@email.com");

        // Act
        var resultado = await repo.Cadastrar(cliente);

        // Assert
        resultado.Should().NotBeNull();
        resultado.Cpf.Should().Be("11122233344");

        var clienteSalvo = await context.Clientes.FirstOrDefaultAsync(x => x.Cpf == "11122233344");
        clienteSalvo.Should().NotBeNull();
    }

    [Fact]
    public async Task ConsultarPorCpf_DeveRetornarClienteExistente()
    {
        // Arrange
        using var context = new NpgsqlContext(_connectionStringProviderMock.Object, isTesting: true);
        var cliente = new Cliente("55566677788", "Julia", "julia@email.com");
        context.Clientes.Add(cliente);
        await context.SaveChangesAsync();

        var repo = new ClienteRepository(context);

        // Act
        var resultado = await repo.ConsultarPorCpf("55566677788");

        // Assert
        resultado.Should().NotBeNull();
        resultado.Nome.Should().Be("Julia");
    }

    [Fact]
    public async Task ConsultarPorCpf_DeveRetornarClienteVazio_SeNaoEncontrar()
    {
        // Arrange
        using var context = new NpgsqlContext(_connectionStringProviderMock.Object, isTesting: true);
        var repo = new ClienteRepository(context);

        // Act
        var resultado = await repo.ConsultarPorCpf("00000000000");

        // Assert
        resultado.Should().NotBeNull();
        resultado.Nome.Should().BeNullOrEmpty();
    }
}
