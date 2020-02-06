using System;

namespace Kpi.Hotels.Dataclient.Context.Models
{
    public class ServiceClass
    {
        public Guid Id { get; set; }
        public RoomKind RoomKind { get; set; }
        public double RoomPrice { get; set; }
    }
}
