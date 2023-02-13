using PlantHere.Application.CQRS.Base;

namespace PlantHere.Application.CQRS.Order.Quries.GetOrderById
{
    public class GetOrderByIdQuery : QueryBase<GetOrderByIdQueryResult>
    {
        public int Id { get; set; }

        public GetOrderByIdQuery(int id)
        {
            Id = id;
        }
    }
}
