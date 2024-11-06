using System;
using System.Collections.Generic;

namespace PR.Models
{
    public partial class User
    {
        public User()
        {
            MenuItems = new HashSet<MenuItem>();
            Orders = new HashSet<Order>();
            Reservations = new HashSet<Reservation>();
            Tables = new HashSet<Table>();
        }

        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Email { get; set; }
        public string? Phone { get; set; }
        public string? Password { get; set; }
        public string? Img { get; set; }
        public int? RoleId { get; set; }
        public DateTime? CreatedAt { get; set; }

        public virtual Role? Role { get; set; }
        public virtual ICollection<MenuItem> MenuItems { get; set; }
        public virtual ICollection<Order> Orders { get; set; }
        public virtual ICollection<Reservation> Reservations { get; set; }
        public virtual ICollection<Table> Tables { get; set; }
    }
}
