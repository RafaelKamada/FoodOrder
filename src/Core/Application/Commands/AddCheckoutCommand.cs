using MediatR;

namespace Application.Commands
{
    public class AddCheckoutCommand : IRequest<Unit>
    {
        public required string Cpf { get; set; }

        /// <summary>
        /// Ids dos produtos
        /// </summary>
        public required List<int> Produtos { get; set; }
    }
}
