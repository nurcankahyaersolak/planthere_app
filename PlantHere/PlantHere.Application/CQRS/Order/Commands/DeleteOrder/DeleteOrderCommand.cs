using MediatR;
using PlantHere.Application.CQRS.Base;

namespace PlantHere.Application.CQRS.Order.Commands.DeleteOrder
{
    public class DeleteOrderCommand : CommandBase<Unit>
    {
        public int Id { get; set; }

        public DeleteOrderCommand(int id)
        {
            Id = id;
        }

    }
}
