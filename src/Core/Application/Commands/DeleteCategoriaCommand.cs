using MediatR;

namespace Application.Commands
{
    public class DeleteCategoriaCommand : IRequest<Unit>
    {
        public int Id { get; set; }
        public bool ValidateId() => Id != 0; 
    }
}
