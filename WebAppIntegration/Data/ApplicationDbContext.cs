
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using WebAppIntegration.Model;

namespace WebAppIntegration.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<IntegrationSource> IntegrationSource { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Configure relationships, indexes, etc.
            modelBuilder.Entity<IntegrationSource>()
                .HasKey(e => e.Id); // Specify Id as the primary key
                //.HasOne<ApplicationUser>() // Assuming ApplicationUser is the user entity
                //.WithMany() // Assuming there is no navigation property on the user entity pointing back to IntegrationSource
                //.HasForeignKey(e => e.UserId)
                //.IsRequired();
        }

    }
}
