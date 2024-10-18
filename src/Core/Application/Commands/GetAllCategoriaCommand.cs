using Domain.Entities;
using MediatR;

namespace Application.Commands
{
    public class GetAllCategoriaCommand : IRequest<List<Categoria>>
    {
        
    }
}
