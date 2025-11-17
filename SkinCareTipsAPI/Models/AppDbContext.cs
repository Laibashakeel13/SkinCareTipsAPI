using Microsoft.EntityFrameworkCore;

namespace SkinCareTipsAPI.Models
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<Tip> Tips { get; set; }
    }
}
