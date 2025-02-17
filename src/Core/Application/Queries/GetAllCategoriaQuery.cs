using FoodOrder.Application.DTOs;
using MediatR;

namespace FoodOrder.Application.Commands
{
    public class GetAllCategoriaQuery : IRequest<List<CategoriaResponse>>
    {
        
    }
}
