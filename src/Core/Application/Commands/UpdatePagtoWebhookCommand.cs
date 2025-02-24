using MediatR;

namespace FoodOrder.Application.Commands
{
    public class UpdatePagtoWebhookCommand : IRequest<Unit>
    {
        public string Action { get; set; }
        public string ApiVersion { get; set; }
        public PagtoData Data { get; set; }
        public DateTime DateCreated { get; set; }
        public bool LiveMode { get; set; }
        public string Type { get; set; }
        public string UserId { get; set; }

        public class PagtoData
        {
            public string Id { get; set; }
        }
    }
}
