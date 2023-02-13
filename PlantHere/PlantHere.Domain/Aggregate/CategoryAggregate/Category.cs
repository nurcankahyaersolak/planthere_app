using PlantHere.Domain.Common.Class;

namespace PlantHere.Domain.Aggregate.CategoryAggregate
{
    public class Category : BaseEntity
    {
        public string? NameTr { get; set; }

        public string? NameEn { get; set; }

    }
}
