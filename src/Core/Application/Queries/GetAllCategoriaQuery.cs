using Domain.Entities;
using MediatR;

namespace Application.Commands
{
    public class GetAllCategoriaQuery : IRequest<List<Categoria>>
    {
        
    }
}
