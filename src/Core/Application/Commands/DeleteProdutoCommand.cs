using MediatR;

namespace Application.Commands
{
    public class DeleteProdutoCommand : IRequest<Unit>
    {
        public int Id { get; set; }
        public bool ValidateId() => Id != 0; 
    }
}
