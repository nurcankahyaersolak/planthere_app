using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AuthServer.Persistence.Seeds
{
    public class RoleSeed : IEntityTypeConfiguration<IdentityRole>
    {
        public void Configure(EntityTypeBuilder<IdentityRole> builder)
        {
            builder.HasData(new IdentityRole { Name = "seller", NormalizedName = "SELLER" });
            builder.HasData(new IdentityRole { Name = "superadmin", NormalizedName = "SUPERADMIN" });
            builder.HasData(new IdentityRole { Name = "customer", NormalizedName = "CUSTOMER" });
        }
    }
}
