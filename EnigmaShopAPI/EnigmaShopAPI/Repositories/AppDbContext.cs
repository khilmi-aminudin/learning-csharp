using EnigmaShopAPI.Entities;
using Microsoft.EntityFrameworkCore;

namespace EnigmaShopAPI.Repositories;

public class AppDbContext : DbContext
{
    public DbSet<Customer> Customers { get; set; }
    public DbSet<Product> Products { get; set; }
    public DbSet<Purchase> Purchases { get; set; }
    public DbSet<PurchaseDetail> PurchaseDetails { get; set; }
    
    protected AppDbContext()
    {
        
    }


    public AppDbContext(DbContextOptions options) : base(options)
    {
        
    }

    // protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    // {
    //     optionsBuilder.UseNpgsql(Config.DbConnectionString());
    // }
}