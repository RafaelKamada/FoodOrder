using FluentAssertions;
using FoodOrder.Application.Features;
using FoodOrder.Application.UseCases;
using FoodOrder.Domain.Entities;
using Moq;

namespace FoodOrder.Tests.Application.Features;

public class AddClienteCommandHandlerTests
{
    [Fact]
    public async Task Handle_DeveCadastrarEDevolverCliente()
    {
        // Arrange
        var mockUseCase = new Mock<IClienteUseCase>();

        var clienteEsperado = new Cliente("12345678900", "João Silva", "joao@email.com");

        mockUseCase.Setup(x => x.Cadastrar(It.IsAny<Cliente>()))
                   .ReturnsAsync(clienteEsperado);

        var command = new AddClienteCommand
        {
            Cpf = "12345678900",
            Nome = "João Silva",
            Email = "joao@email.com"
        };

        var handler = new AddClienteCommandHandler(mockUseCase.Object);

        // Act
        var resultado = await handler.Handle(command, CancellationToken.None);

        // Assert
        resultado.Should().NotBeNull();
        resultado.Cpf.Should().Be(command.Cpf);
        resultado.Nome.Should().Be(command.Nome);
        resultado.Email.Should().Be(command.Email);

        mockUseCase.Verify(x => x.Cadastrar(It.Is<Cliente>(c =>
            c.Cpf == command.Cpf &&
            c.Nome == command.Nome &&
            c.Email == command.Email)), Times.Once);
    }
}
