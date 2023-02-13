using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PlantHere.Domain.Aggregate.OrderAggregate.Entities;

namespace PlantHere.Persistence.Configurations
{
    public class OrderConfiguration : IEntityTypeConfiguration<Order>
    {
        public void Configure(EntityTypeBuilder<Order> builder)
        {
            builder.ToTable("Orders", "ordering");
            builder.Property(e => e.Id).UseIdentityColumn();
            builder.HasMany(e => e.OrderItems).WithOne();
            builder.OwnsOne(e => e.Address).WithOwner();
        }
    }
}
