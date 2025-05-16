using FluentAssertions;
using FoodOrder.Application.UseCases;
using FoodOrder.Domain.Entities;
using FoodOrder.Domain.Interface;
using Moq;

namespace FoodOrder.Tests.Application.UseCases;

public class ClienteUseCaseTests
{
    [Fact]
    public async Task Cadastrar_DeveRetornarClienteCadastrado()
    {
        // Arrange
        var mockRepo = new Mock<IClienteRepository>();
        var cliente = new Cliente("12345678900", "Ana", "ana@email.com");

        mockRepo.Setup(x => x.Cadastrar(cliente)).ReturnsAsync(cliente);

        var useCase = new ClienteUseCase(mockRepo.Object);

        // Act
        var resultado = await useCase.Cadastrar(cliente);

        // Assert
        resultado.Should().NotBeNull();
        resultado.Cpf.Should().Be(cliente.Cpf);
        resultado.Nome.Should().Be(cliente.Nome);
        resultado.Email.Should().Be(cliente.Email);

        mockRepo.Verify(x => x.Cadastrar(cliente), Times.Once);
    }

    [Fact]
    public async Task ConsultarPorCpf_DeveRetornarCliente_QuandoCpfExistir()
    {
        // Arrange
        var cpf = "98765432100";
        var cliente = new Cliente(cpf, "Carlos", "carlos@email.com");

        var mockRepo = new Mock<IClienteRepository>();
        mockRepo.Setup(x => x.ConsultarPorCpf(cpf)).ReturnsAsync(cliente);

        var useCase = new ClienteUseCase(mockRepo.Object);

        // Act
        var resultado = await useCase.ConsultarPorCpf(cpf);

        // Assert
        resultado.Should().NotBeNull();
        resultado.Cpf.Should().Be(cpf);
        mockRepo.Verify(x => x.ConsultarPorCpf(cpf), Times.Once);
    }

    [Fact]
    public async Task ConsultarPorCpf_DeveLancarExcecao_QuandoClienteNaoExistir()
    {
        // Arrange
        var cpfInexistente = "00000000000";
        var mockRepo = new Mock<IClienteRepository>();

        mockRepo.Setup(x => x.ConsultarPorCpf(cpfInexistente)).ReturnsAsync((Cliente?)null);

        var useCase = new ClienteUseCase(mockRepo.Object);

        // Act
        Func<Task> act = async () => await useCase.ConsultarPorCpf(cpfInexistente);

        // Assert
        await act.Should().ThrowAsync<ArgumentException>()
            .WithMessage($"CPF {cpfInexistente} não localizado no banco de dados!");

        mockRepo.Verify(x => x.ConsultarPorCpf(cpfInexistente), Times.Once);
    }
}
