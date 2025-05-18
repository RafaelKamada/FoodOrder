using FluentAssertions;
using FoodOrder.Application.Features;
using FoodOrder.Application.UseCases;
using FoodOrder.Domain.Entities;
using Moq;
using TechTalk.SpecFlow;

namespace FoodOrder.Tests.Steps
{
    [Binding]
    public class AddClienteSteps
    {
        private AddClienteCommand _command;
        private Cliente _clienteCadastrado;
        private Mock<IClienteUseCase> _mockUseCase;
        private AddClienteCommandHandler _handler;

        [Given(@"que tenho um cliente com CPF ""(.*)"", nome ""(.*)"" e email ""(.*)""")]
        public void GivenTenhoUmCliente(string cpf, string nome, string email)
        {
            _command = new AddClienteCommand
            {
                Cpf = cpf,
                Nome = nome,
                Email = email
            };

            _mockUseCase = new Mock<IClienteUseCase>();
            _mockUseCase.Setup(x => x.Cadastrar(It.IsAny<Cliente>()))
                        .ReturnsAsync((Cliente c) => c);

            _handler = new AddClienteCommandHandler(_mockUseCase.Object);
        }

        [When(@"eu tento cadastrar o cliente")]
        public async Task WhenEuTentoCadastrarOCliente()
        {
            _clienteCadastrado = await _handler.Handle(_command, CancellationToken.None);
        }

        [Then(@"o cliente deve ser cadastrado com sucesso")]
        public void ThenClienteDeveSerCadastradoComSucesso()
        {
            _clienteCadastrado.Should().NotBeNull();
        }

        [Then(@"o cliente cadastrado deve conter o CPF ""(.*)""")]
        public void ThenClienteCadastradoDeveConterOCpf(string cpf)
        {
            _clienteCadastrado.Cpf.Should().Be(cpf);
        }

        [Then(@"o cliente cadastrado deve conter o nome ""(.*)""")]
        public void ThenClienteCadastradoDeveConterONome(string nome)
        {
            _clienteCadastrado.Nome.Should().Be(nome);
        }

        [Then(@"o cliente cadastrado deve conter o email ""(.*)""")]
        public void ThenClienteCadastradoDeveConterOEmail(string email)
        {
            _clienteCadastrado.Email.Should().Be(email);
        }
    }
}
