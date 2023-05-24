using Microsoft.EntityFrameworkCore;

namespace DemoBilling
{
    public class ProductPurchaseDbContext:DbContext
    {
        public ProductPurchaseDbContext()
        {
        }

        public ProductPurchaseDbContext(DbContextOptions<ProductPurchaseDbContext> options) : base(options)
        {

        }
        public DbSet<Product> Products { get; set; }
        public DbSet<Customer> customers { get; set; }
        public DbSet<Bill> bills { get; set; }
        public DbSet<PurchaseDetail> purchaseDetails { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Product>().HasData(
                new Product { Id = 1, Name = "Note Book", Price = 150 },
                 new Product { Id = 2, Name = "Iron Box", Price = 1500 },
                  new Product { Id = 3, Name = "BedSheet", Price = 1100 },
                   new Product { Id = 4, Name = "Pen", Price = 10 },
                    new Product { Id = 5, Name = "Rice", Price = 350 }
                );
            foreach(var foreignKey in modelBuilder.Model.GetEntityTypes()
                .SelectMany(e => e.GetForeignKeys()))
            {
                foreignKey.DeleteBehavior = DeleteBehavior.Restrict;
            }
        }

    }
} 
