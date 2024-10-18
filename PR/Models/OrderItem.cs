using System;
using System.Collections.Generic;

namespace PR.Models
{
    public partial class OrderItem
    {
        public int Id { get; set; }
        public int? Quantity { get; set; }
        public decimal? Price { get; set; }
        public int? OrderId { get; set; }
        public int? MenuItemId { get; set; }

        public virtual MenuItem? MenuItem { get; set; }
        public virtual Order? Order { get; set; }
    }
}
