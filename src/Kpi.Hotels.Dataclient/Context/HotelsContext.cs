using Kpi.Hotels.Dataclient.Context.Models;
using Microsoft.EntityFrameworkCore;

namespace Kpi.Hotels.Dataclient.Context
{
    public class HotelsContext:DbContext
    {
        public HotelsContext(DbContextOptions options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }

        public DbSet<Client> Clients { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<Room> Rooms { get; set; }
        public DbSet<ServiceClass> ServiceClasses { get; set; }
    }
}
