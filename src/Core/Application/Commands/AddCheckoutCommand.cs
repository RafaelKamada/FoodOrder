using FoodOrder.Application.Output;
using MediatR;

namespace FoodOrder.Application.Commands
{
    public class AddCheckoutCommand : IRequest<CheckoutOutput>
    {
        public required string Cpf { get; set; }

        /// <summary>
        /// Ids dos produtos
        /// </summary>
        public required List<int> Produtos { get; set; }
    }
}
