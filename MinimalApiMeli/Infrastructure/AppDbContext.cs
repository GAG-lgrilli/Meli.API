using MELI_API.Interfaces;
using Microsoft.EntityFrameworkCore;
using MinimalApiMeli.Entities;

namespace MELI_API.Infraestructura;

public class AppDbContext : DbContext, IAppDbContext
{
    public AppDbContext()
    {
    }

    public AppDbContext(DbContextOptions<AppDbContext> options)
        : base(options)
    {
    }

    public DbSet<Carts> Carts { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
       => optionsBuilder.UseSqlServer(" Server=172.0.0.14;Database=SEIB;user=TestUser;Password=Test2023!;Encrypt=true;TrustServerCertificate=True");

    public virtual int SaveChanges()
    {
        return base.SaveChanges();
    }

    public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
    {
        return base.SaveChangesAsync(cancellationToken);
    }
}