using System;

namespace Kpi.Hotels.Dataclient.Context.Models
{
    public class Client
    {
        public Guid Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string PhoneNumber { get; set; }
        public string Address { get; set; }
        public string Nationality { get; set; }
        public string Email { get; set; }
    }
}
