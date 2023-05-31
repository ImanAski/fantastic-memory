using Microsoft.EntityFrameworkCore;
using Miro.Models;

public class MiroDbContext : DbContext
{
    public DbSet<Post> Post { get; set; }
    public DbSet<User> User { get; set; }
    public DbSet<Product> Product { get; set; }
    
    public DbSet<Order> Order { get; set; }
    public MiroDbContext(DbContextOptions<MiroDbContext> options) : base(options){}

    protected override void OnModelCreating(ModelBuilder modelBuilder) 
    {
        modelBuilder.UseSerialColumns();
    }

}