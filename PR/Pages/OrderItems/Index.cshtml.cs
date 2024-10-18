using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using PR.Models;

namespace PR.Pages.OrderItems
{
    public class IndexModel : PageModel
    {
        private readonly PR.Models.FoodContext _context;

        public IndexModel(PR.Models.FoodContext context)
        {
            _context = context;
        }

        public IList<OrderItem> OrderItem { get;set; } = default!;

        public async Task OnGetAsync()
        {
            if (_context.OrderItems != null)
            {
                OrderItem = await _context.OrderItems
                .Include(o => o.MenuItem)
                .Include(o => o.Order).ToListAsync();
            }
        }
    }
}
