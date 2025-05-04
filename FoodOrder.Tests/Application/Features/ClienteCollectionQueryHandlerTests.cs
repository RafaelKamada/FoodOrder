using FluentAssertions;
using FoodOrder.Application.Features;
using FoodOrder.Application.UseCases;
using FoodOrder.Domain.Entities;
using Moq;

namespace FoodOrder.Tests.Application.Features;

public class ClienteCollectionQueryHandlerTests
{
    [Fact]
    public async Task Handle_DeveRetornarCliente_QuandoCpfExistir()
    {
        // Arrange
        var mockUseCase = new Mock<IClienteUseCase>();

        var clienteEsperado = new Cliente("12345678900", "Maria", "maria@email.com");

        mockUseCase.Setup(x => x.ConsultarPorCpf("12345678900"))
                   .ReturnsAsync(clienteEsperado);

        var query = new ClienteCollectionQuery("12345678900");

        var handler = new ClienteCollectionQueryHandler(mockUseCase.Object);

        // Act
        var resultado = await handler.Handle(query, CancellationToken.None);

        // Assert
        resultado.Should().NotBeNull();
        resultado.Cpf.Should().Be("12345678900");
        resultado.Nome.Should().Be("Maria");
        resultado.Email.Should().Be("maria@email.com");

        mockUseCase.Verify(x => x.ConsultarPorCpf("12345678900"), Times.Once);
    }
}
