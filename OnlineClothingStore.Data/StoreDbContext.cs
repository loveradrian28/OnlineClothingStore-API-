using Microsoft.EntityFrameworkCore;
using OnlineClothingStore.Core;

namespace OnlineClothingStore.Data;
public class StoreDbContext : DbContext
{
    public StoreDbContext(DbContextOptions<StoreDbContext> options)
        : base(options)
    {
    }

    public DbSet<Product> Products { get; set; }
}