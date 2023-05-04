using Microsoft.EntityFrameworkCore;

public class MiroDbContext : DbContext
{
    public DbSet<User> User { get; set; }
    public DbSet<Product> Product { get; set; }
    public MiroDbContext(DbContextOptions<MiroDbContext> options) : base(options){}

    protected override void OnModelCreating(ModelBuilder modelBuilder) 
    {
        modelBuilder.UseSerialColumns();
    }

}