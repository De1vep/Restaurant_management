using System;
using System.Collections.Generic;

namespace PR.Models
{
    public partial class Order
    {
        public Order()
        {
            OrderItems = new HashSet<OrderItem>();
        }

        public int Id { get; set; }
        public decimal? TotalPrice { get; set; }
        public string? Status { get; set; }
        public DateTime? OrderTime { get; set; }
        public int? UsersId { get; set; }
        public int? TableId { get; set; }

        public virtual Table? Table { get; set; }
        public virtual User? Users { get; set; }
        public virtual ICollection<OrderItem> OrderItems { get; set; }
    }
}
