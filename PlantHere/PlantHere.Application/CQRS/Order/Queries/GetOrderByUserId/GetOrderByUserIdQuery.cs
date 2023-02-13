using MediatR;

namespace PlantHere.Application.CQRS.Order.Quries.GetOrderByUserId
{
    public class GetOrderByUserIdQuery : IRequest<ICollection<GetOrderByUserIdQueryResult>>
    {
        public string userId { get; set; }

        public GetOrderByUserIdQuery(string userId)
        {
            this.userId = userId;
        }
    }
}
