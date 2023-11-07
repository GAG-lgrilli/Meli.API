using Microsoft.EntityFrameworkCore;
using MinimalApiMeli.Entities;

namespace MinimalApiMeli.Infrastructure;

public class TablesDB : DbContext
{
    public TablesDB(DbContextOptions<TablesDB> options)
   : base(options) { }


    public DbSet<Provider> providers => base.Set<Provider>();
    public DbSet<Category> categories => base.Set<Category>();
}
