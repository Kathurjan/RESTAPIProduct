using Entities;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure;

public class ProductDbContext : DbContext
{

    public ProductDbContext(DbContextOptions<ProductDbContext> options) : base(options)
    {
        
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Product>()
            .Property(p => p.Id)
            .ValueGeneratedOnAdd();
    }  
    
    public DbSet<Product> ProductTable { get; set; }


}