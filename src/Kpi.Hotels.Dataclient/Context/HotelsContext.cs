using Kpi.Hotels.Dataclient.Context.Models;
using Microsoft.EntityFrameworkCore;

namespace Kpi.Hotels.Dataclient.Context
{
    public class HotelsContext:DbContext
    {
        public HotelsContext(DbContextOptions options) : base(options)
        {
        }

        DbSet<Client> Clients { get; set; }
        DbSet<Order> Orders { get; set; }
        DbSet<Room> Rooms { get; set; }
        DbSet<ServiceClass> ServiceClasses { get; set; }
    }
}
