using PlantHere.Application.CQRS.Base;

namespace PlantHere.Application.CQRS.Product.Commands.CreateProduct
{
    public class CreateProductCommand : CommandBase<CreateProductCommandResult>
    {
        public string? Name { get; set; }

        public string? Description { get; set; }

        public int Stock { get; set; }

        public int Price { get; set; }

        public int Discount { get; set; }

        public int CategoryId { get; set; }

        public string SellerId { get; set; }
    }
}
