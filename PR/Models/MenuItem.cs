using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace PR.Models
{
    public partial class MenuItem
    {
        public MenuItem()
        {
            OrderItems = new HashSet<OrderItem>();
        }

        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Img { get; set; }
        public string? Description { get; set; }
        public decimal? Price { get; set; }
        public int? UsersId { get; set; }
        public int? CategoryId { get; set; }

        public virtual Category? Category { get; set; }
        public virtual User? Users { get; set; }
        [NotMapped]
        public IFormFile? ProductImageFile { get; set; }
        public virtual ICollection<OrderItem> OrderItems { get; set; }
    }
}
