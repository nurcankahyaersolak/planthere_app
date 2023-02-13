namespace PlantHere.Application.CQRS.OrderItem.Queries.GetOrderItems;

public class GetOrderItemsQueryResult
{
    public string ProductId { get; set; }
    public string ProductName { get; set; }
    public decimal Price { get; set; }
    public decimal DiscountedPrice { get; set; }
    public int Count { get; set; }
}
