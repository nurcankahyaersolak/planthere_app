using System.Text.Json.Serialization;

namespace PlantHere.Domain.Aggregate.CategoryAggregate
{
    public class Image
    {
        public int Id { get; set; }

        public string Url { get; set; }

        [JsonIgnore]
        public Product Product { get; set; }

        public int ProductId { get; set; }
    }
}
