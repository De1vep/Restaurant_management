using System;
using System.Collections.Generic;

namespace PR.Models
{
    public partial class Category
    {
        public Category()
        {
            MenuItems = new HashSet<MenuItem>();
        }

        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Description { get; set; }

        public virtual ICollection<MenuItem> MenuItems { get; set; }
    }
}
