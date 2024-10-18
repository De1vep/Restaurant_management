using System;
using System.Collections.Generic;

namespace PR.Models
{
    public partial class Reservation
    {
        public int Id { get; set; }
        public DateTime? ReservationTime { get; set; }
        public string? Status { get; set; }
        public int? UsersId { get; set; }
        public int? TableId { get; set; }

        public virtual Table? Table { get; set; }
        public virtual User? Users { get; set; }
    }
}
