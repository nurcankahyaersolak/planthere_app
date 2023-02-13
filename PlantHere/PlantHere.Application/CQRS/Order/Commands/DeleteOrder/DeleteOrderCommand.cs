using MediatR;
using PlantHere.Application.CQRS.Base;

namespace PlantHere.Application.CQRS.Order.Commands.DeleteOrder
{
    public class DeleteOrderCommand : CommandBase<Unit>
    {
        public DeleteOrderCommand(int id)
        {
            Id = id;
        }

        public int Id { get; set; }
    }
}
