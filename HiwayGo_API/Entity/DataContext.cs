using Microsoft.EntityFrameworkCore;

namespace HiwayGo_API.Entity
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options) { }

        public DbSet<UserRole> userRoles { get; set; }
        public DbSet<User> Users { get; set; } 
        
        public DbSet<BusModel> BusModel { get; set; }
        public DbSet<BusRoute> BusRoutes { get; set; }
        public DbSet<BusRouteFare> BusRouteFares { get; set; }
        public DbSet<BusDetail> BusDetails { get; set; }
        public DbSet<BusBooking> BusBookings { get; set; }
        public DbSet<BusShedule> BusShedules { get; set; }
       
    }
}
