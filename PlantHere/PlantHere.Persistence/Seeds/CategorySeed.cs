using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PlantHere.Domain.Aggregate.CategoryAggregate;


namespace PlantHere.Persistence.Seeds
{
    public class CategorySeed : IEntityTypeConfiguration<Category>
    {
        public void Configure(EntityTypeBuilder<Category> builder)
        {
            builder.HasData(new Category { Id = 1, NameTr = "Kaktus", NameEn = "Cactus", CreatedDate = DateTime.Now },
                            new Category { Id = 2, NameTr = "Sukulent", NameEn = "Succulent", CreatedDate = DateTime.Now },
                            new Category { Id = 3, NameTr = "Orkide", NameEn = "Orchid", CreatedDate = DateTime.Now });
        }
    }
}
