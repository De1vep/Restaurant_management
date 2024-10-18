using System;
using System.Collections.Generic;

namespace PR.Models
{
    public partial class Table
    {
        public Table()
        {
            Orders = new HashSet<Order>();
            Reservations = new HashSet<Reservation>();
        }

        public int Id { get; set; }
        public int? TableNumber { get; set; }
        public int? Capacity { get; set; }
        public string? Status { get; set; }
        public int? UsersId { get; set; }

        public virtual User? Users { get; set; }
        public virtual ICollection<Order> Orders { get; set; }
        public virtual ICollection<Reservation> Reservations { get; set; }
    }
}
