using Microsoft.Extensions.Hosting;
using Attribute = E_Commerce.Domain.Entities.Attribute;

namespace E_Commerce_API.Models
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
             : base(options)
        {
        }
        DbSet<Attribute> Attributes { get; set; }
        DbSet<Category> Categories { get; set; }
        DbSet<Brand> Brands { get; set; }
        DbSet<Coupon> Coupons { get; set; }
        DbSet<Product> Products { get; set; }
        DbSet<ProductVariant> ProductsVariants { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Category>()
                .HasMany(e => e.Attributes)
                .WithMany(e => e.Categories)
                .UsingEntity<CategoryAttributes>();

            modelBuilder.Entity<ProductVariant>()
                .HasMany(pv => pv.Attributes)
                .WithMany(pv => pv.ProductVariants)
                .UsingEntity<ProductVariantAttributes>();

            modelBuilder.Entity<ProductVariantAttributes>()
                .HasKey(["ProductVariantId", "AttributeId"]);
            modelBuilder.Entity<CategoryAttributes>()
                .HasKey(["CategoryId", "AttributeId"]);
            base.OnModelCreating(modelBuilder);

        }


    }
}
