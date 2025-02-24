using MediatR;

namespace FoodOrder.Application.Commands
{
    public class GetAllCategoriaQuery : IRequest<List<FoodOrder.Domain.Entities.Categoria>>
    {
        
    }
}
