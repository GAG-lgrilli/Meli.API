using Microsoft.EntityFrameworkCore;
using MinimalApiMeli.Entities;

namespace MELI_API.Interfaces
{
    public interface IAppDbContext
    {
        DbSet<Carts> Carts { get; set; }

        public int SaveChanges();

        public Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
    }
}
