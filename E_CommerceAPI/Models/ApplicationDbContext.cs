using Microsoft.Extensions.Hosting;
using Attribute = E_Commerce.Models.Attribute;

namespace E_Commerce_API.Models
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
             : base(options)
        {
        }
        DbSet<Attribute> attributes { get; set; }
        DbSet<Category> categories { get; set; }
        DbSet<Brand> brands { get; set; }
        DbSet<Coupon> coupons { get; set; }
        DbSet<Image> images { get; set; }
        DbSet<Product> products { get; set; }
        DbSet<ProductVariant> productsVariants { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Category>()
                .HasMany(e => e.Attributes)
                .WithMany(e => e.Categories)
                .UsingEntity<CategoryAttribute>();

            modelBuilder.Entity<ProductVariant>()
                .HasMany(pv => pv.Attributes)
                .WithMany(pv => pv.ProductVariants)
                .UsingEntity<ProductVariantAttribute>();

            modelBuilder.Entity<ProductVariantAttribute>()
                .HasKey(["ProductVariantId", "AttributeId"]);
            modelBuilder.Entity<CategoryAttribute>()
                .HasKey(["CategoryId", "AttributeId"]);
            base.OnModelCreating(modelBuilder);

        }


    }
}
