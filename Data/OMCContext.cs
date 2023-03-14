using Microsoft.EntityFrameworkCore;
using OMC.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;


namespace OMC.Data
{
    public class OMCContext : IdentityDbContext<ApplicationUser>
    {

        public DbSet<Product> Product { get; set; }
        public DbSet<Order> Order { get; set; }
        public OMCContext(DbContextOptions<OMCContext> options)
            : base(options)
        {
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Product>().ToTable("Product");
            modelBuilder.Entity<Order>()
                .HasOne(o => o.Product)
                .WithMany()
               .HasForeignKey(o => o.ProductID);

        }
    }

    public class ApplicationUser : IdentityUser
    {
        public string? Name { get; set; }
    }
}
