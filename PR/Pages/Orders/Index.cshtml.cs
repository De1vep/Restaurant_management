using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using PR.Models;

namespace PR.Pages.Orders
{
    public class IndexModel : PageModel
    {
        private readonly PR.Models.FoodContext _context;

        public IndexModel(PR.Models.FoodContext context)
        {
            _context = context;
        }

        public IList<Order> Order { get;set; } = default!;

        public async Task OnGetAsync()
        {
            if (_context.Orders != null)
            {
                Order = await _context.Orders
                .Include(o => o.Table)
                .Include(o => o.Users).ToListAsync();
            }
        }
    }
}
