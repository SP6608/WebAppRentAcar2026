using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace WebAppRentAcar.Data
{
    public class ApplicationDbContext: IdentityDbContext<AppUser,IdentityRole,string>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext>options)
        :base(options) { }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.Entity<AppUser>()
                .HasKey(x => x.Id);

            builder.Entity<AppUser>()
                .HasIndex(i => i.EGN)
                .IsUnique();
        }
    }

}
