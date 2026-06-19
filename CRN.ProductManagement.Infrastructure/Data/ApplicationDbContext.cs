using Microsoft.EntityFrameworkCore;
using CRN.ProductManagement.Domain.Entities;

namespace CRN.ProductManagement.Infrastructure.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(
        DbContextOptions<ApplicationDbContext> options)
        : base(options)
        {
        }

    public DbSet<Product> Products { get; set; }

        public DbSet<Item> Items { get; set; }

        public DbSet<RefreshToken> RefreshTokens { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Product>()
                .HasMany(p => p.Items)
                .WithOne(i => i.Product)
                .HasForeignKey(i => i.ProductId);

            modelBuilder.Entity<RefreshToken>()
                .HasKey(x => x.Id);

            modelBuilder.Entity<RefreshToken>()
                .Property(x => x.Token)
                .IsRequired();

            modelBuilder.Entity<RefreshToken>()
                .Property(x => x.UserName)
                .IsRequired();
        }
    }

}
