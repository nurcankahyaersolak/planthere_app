namespace PlantHere.Application.Requests.Products
{
    public class UpdateProductRequest
    {
        public int Id { get; set; }

        public string? Name { get; set; }

        public string? Description { get; set; }

        public int Stock { get; set; }

        public int Price { get; set; }

        public int Discount { get; set; }

        public int CategoryId { get; set; }
    }
}
