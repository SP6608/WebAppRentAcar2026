using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using WebAppRentAcar.Models;

namespace WebAppRentAcar.Data
{
    public class ApplicationDbContext: IdentityDbContext<AppUser,IdentityRole,string>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext>options)
        :base(options) { }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            // Configure Identity entities first
            base.OnModelCreating(builder);
            builder.Entity<AppUser>()
                .HasIndex(i => i.EGN)
                .IsUnique();
            builder.ApplyConfigurationsFromAssembly(typeof(ApplicationDbContext).Assembly);
        }
        public virtual DbSet<Car> Cars { get; set; } = null!;
        public virtual DbSet<Reservation> Reservations { get; set; } = null!;
    }

}
