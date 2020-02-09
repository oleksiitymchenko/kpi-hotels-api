using System;

namespace Kpi.Hotels.Dataclient.Context.Models
{
    public class Room
    {
        public Guid Id { get; set; }
        public Guid ServiceClassId { get; set; }
        public ServiceClass ServiceClass { get; set; }
        public int Floor { get; set; }
        public int RoomNumber { get; set; }
        public bool FridgeIncluded { get; set; }
    }
}
