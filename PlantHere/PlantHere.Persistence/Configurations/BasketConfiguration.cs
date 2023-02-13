using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PlantHere.Domain.Aggregate.BasketAggregate.Entities;

namespace PlantHere.Persistence.Configuration
{
    public class BasketConfiguration : IEntityTypeConfiguration<Basket>
    {
        public void Configure(EntityTypeBuilder<Basket> builder)
        {
            builder.ToTable("Baskets", "basketing");
            builder.HasMany(x => x.BasketItems).WithOne();
        }
    }
}
