using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PlantHere.Domain.Aggregate.CategoryAggregate;


namespace PlantHere.Persistence.Configurations
{
    internal class CategoryConfiguration : IEntityTypeConfiguration<Category>
    {
        public void Configure(EntityTypeBuilder<Category> builder)
        {
            builder.Property(x => x.Id).UseIdentityColumn();//ID Identity olarak ayarlandı

            builder.Property(x => x.NameTr).IsRequired().HasMaxLength(50);

            builder.Property(x => x.NameEn).IsRequired().HasMaxLength(50);
        }
    }
}
