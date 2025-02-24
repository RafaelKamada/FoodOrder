using FoodOrder.Domain.Entities;
using MediatR;

namespace FoodOrder.Application.Queries
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
