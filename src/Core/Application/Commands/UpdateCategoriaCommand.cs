using MediatR;

namespace Application.Commands
{
    public class UpdateCategoriaCommand : IRequest<Unit>
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Tipo { get; set; }

        public bool ValidateId() => Id != 0; 
    }
}
