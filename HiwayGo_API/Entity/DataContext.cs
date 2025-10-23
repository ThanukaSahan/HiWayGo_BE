using Microsoft.EntityFrameworkCore;

namespace HiwayGo_API.Entity
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options) { }

        public DbSet<UserRole> userRoles { get; set; }
        public DbSet<User> Users { get; set; } 
    }
}
