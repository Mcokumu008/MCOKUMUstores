using MCOKUMUStores.Models;
using Microsoft.EntityFrameworkCore;
namespace MCOKUMUStores.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<ContactMessage> ContactMessages { get; set; }
        public DbSet<Subscription> Subscriptions { get; set; }
    }
}
