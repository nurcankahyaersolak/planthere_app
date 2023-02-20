using MediatR;
using PlantHere.Application.CQRS.Base;

namespace PlantHere.Application.CQRS.Product.Commands.UpdateProduct
{
    public class UpdateProductCommand : CommandBase<Unit>
    {
        public int Id { get; set; }

        public string? Name { get; set; }

        public string? Description { get; set; }

        public int Stock { get; set; }

        public int Price { get; set; }

        public int Discount { get; set; }

        public int CategoryId { get; set; }

        public UpdateProductCommand(int id, string? name, string? description, int stock, int price, int discount, int categoryId)
        {
            Id = id;
            Name = name;
            Description = description;
            Stock = stock;
            Price = price;
            Discount = discount;
            CategoryId = categoryId;
        }
    }
}
