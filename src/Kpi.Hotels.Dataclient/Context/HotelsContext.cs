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

        public DbSet<Kpi.Hotels.Dataclient.Context.Models.Client> Clients { get; set; }
        public DbSet<Kpi.Hotels.Dataclient.Context.Models.Order> Orders { get; set; }
        public DbSet<Kpi.Hotels.Dataclient.Context.Models.Room> Rooms { get; set; }
        public DbSet<Kpi.Hotels.Dataclient.Context.Models.ServiceClass> ServiceClasses { get; set; }
    }
}
