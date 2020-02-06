using System;

namespace Kpi.Hotels.Dataclient.Context.Models
{
    public class Order
    {
        public Guid Id { get; set; }
        public DateTime ArrivalDate { get; set; }
        public DateTime DepartureDate { get; set; }
        public double Total { get; set; }
        public Guid RoomId { get; set; }
        public Room Room { get; set; }
        public Guid ClientId { get; set; }
        public Client Client { get; set; }
    }
}
