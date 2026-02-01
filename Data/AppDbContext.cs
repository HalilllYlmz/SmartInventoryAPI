using Microsoft.EntityFrameworkCore;
using SmartInventoryAPI.Models;

namespace SmartInventoryAPI.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<Device> Devices { get; set; }
        public DbSet<AlarmLog> AlarmLogs { get; set; }
    }
}