using Domain.Entities;
using MediatR;

namespace Application.Queries
{
    public class GetClienteByCpfQuery : IRequest<Cliente>
    {
        public string Cpf { get; }

        public GetClienteByCpfQuery(string cpf)
        {
            Cpf = cpf;
        }

    }
}
