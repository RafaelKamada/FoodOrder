using Application.Queries;
using Domain.Entities;
using Domain.Ports;
using MediatR;

namespace Application.Handlers
{
    public class GetClienteByCpfQueryHandler : IRequestHandler<GetClienteByCpfQuery, Cliente>
    {
        private readonly IClienteRepository _clienteRepository;

        public GetClienteByCpfQueryHandler(IClienteRepository clienteRepository)
        {
            _clienteRepository = clienteRepository;
        }

        public async Task<Cliente> Handle(GetClienteByCpfQuery request, CancellationToken cancellationToken)
        {
            var cliente = await _clienteRepository.ConsultarPorCpf(request.Cpf);
            return cliente;
        }
    }
}
