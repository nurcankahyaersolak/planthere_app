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

        public CreateProductCommand(string? name, string? description, int stock, int price, int discount, int categoryId, string sellerId)
        {
            Name = name;
            Description = description;
            Stock = stock;
            Price = price;
            Discount = discount;
            CategoryId = categoryId;
            SellerId = sellerId;
        }
    }
}
