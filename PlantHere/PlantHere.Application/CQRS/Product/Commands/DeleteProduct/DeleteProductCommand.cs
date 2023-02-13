using MediatR;
using PlantHere.Application.CQRS.Base;

namespace PlantHere.Application.CQRS.Product.Commands.DeleteProduct
{
    public class DeleteProductCommand : CommandBase<Unit>
    {
        public DeleteProductCommand(int id)
        {
            Id = id;
        }

        public int Id { get; set; }
    }
}
