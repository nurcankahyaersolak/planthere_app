using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PlantHere.Domain.Aggregate.CategoryAggregate;

namespace PlantHere.Persistence.Configurations
{
    internal class ProductConfiguration : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.Property(x => x.Price).IsRequired().HasColumnType("decimal(18,2)");

            builder.HasMany(x => x.Images).WithOne(x => x.Product);
        }
    }
}
