using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using PR.Models;

namespace PR.Pages.MenuItems
{
    public class IndexModel : PageModel
    {
        private readonly PR.Models.FoodContext _context;

        public IndexModel(PR.Models.FoodContext context)
        {
            _context = context;
        }
        [BindProperty(SupportsGet = true)]
        public string? ItemName { get; set; }


        [BindProperty(SupportsGet = true)]
        public int? MinUnitPrice { get; set; }

        [BindProperty(SupportsGet = true)]
        public int? MaxUnitPrice { get; set; }

        public IList<MenuItem> MenuItem { get;set; } = default!;

        public async Task OnGetAsync()
        {
            if (_context.MenuItems != null)
            {
                MenuItem = await _context.MenuItems
                .Include(m => m.Category)
                .Include(m => m.Users)
                .OrderByDescending(m => m.Id)
                .ToListAsync();
            }
            var productsQuery = _context.MenuItems
                .Include(m => m.Category)
                .Include(m => m.Users)
                .OrderByDescending(m => m.Id)
                .AsQueryable();
            if (!string.IsNullOrEmpty(ItemName))
            {
                productsQuery = productsQuery.Where(p => p.Name.Contains(ItemName));
            }

            if (MinUnitPrice.HasValue)
            {
                productsQuery = productsQuery.Where(p => p.Price >= MinUnitPrice.Value);
            }

            if (MaxUnitPrice.HasValue)
            {
                productsQuery = productsQuery.Where(p => p.Price <= MaxUnitPrice.Value);
            }

            MenuItem = await productsQuery.ToListAsync();
        }
    }
}
