using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace WebAppRentAcar.Common
{
    public class RoleTypeConfiguration : IEntityTypeConfiguration<IdentityRole>
    {
        private readonly ICollection<IdentityRole> roles= new List<IdentityRole>()
        {
            new IdentityRole(){Id="c3c0e566-7368-4cad-b44e-b2204ec50164",Name="Admin",NormalizedName="ADMIN",ConcurrencyStamp= "c3c0e566-7368-4cad-b44e-b2204ec50164"},
            new IdentityRole(){Id="4e0462e4-6314-4f40-a4e4-6c3b05e4d915",Name="User",NormalizedName="USER",  ConcurrencyStamp = "4e0462e4-6314-4f40-a4e4-6c3b05e4d915"},
        };
        public void Configure(EntityTypeBuilder<IdentityRole> builder)
        {
           builder.HasData(roles);
        }
    }
}
