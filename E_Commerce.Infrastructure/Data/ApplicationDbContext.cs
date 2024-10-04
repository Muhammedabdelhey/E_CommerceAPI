namespace E_Commerce.Infrastructure.Data;

public class ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : DbContext(options)
{
    internal DbSet<Attribute> Attributes { get; set; }
    internal DbSet<Category> Categories { get; set; }
    internal DbSet<Brand> Brands { get; set; }
    internal DbSet<Coupon> Coupons { get; set; }
    //internal DbSet<CouponUsage> couponUsages { get; set; }
    internal DbSet<Product> Products { get; set; }
    internal DbSet<ProductVariant> ProductsVariants { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        base.OnModelCreating(modelBuilder);
    }
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        //optionsBuilder
        //    .UseLazyLoadingProxies();
        base.OnConfiguring(optionsBuilder);
    }

}
