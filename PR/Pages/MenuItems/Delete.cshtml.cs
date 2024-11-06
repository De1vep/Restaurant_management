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
    public class DeleteModel : PageModel
    {
        private readonly PR.Models.FoodContext _context;

        public DeleteModel(PR.Models.FoodContext context)
        {
            _context = context;
        }

        [BindProperty]
      public MenuItem MenuItem { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.MenuItems == null)
            {
                return NotFound();
            }

            var menuitem = await _context.MenuItems
                .Include(p => p.Category)
                .Include(p => p.Users)
                .FirstOrDefaultAsync(m => m.Id == id);

            if (menuitem == null)
            {
                return NotFound();
            }
            else 
            {
                MenuItem = menuitem;
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null || _context.MenuItems == null)
            {
                return NotFound();
            }
            var menuitem = await _context.MenuItems.FindAsync(id);

            if (menuitem != null)
            {
                MenuItem = menuitem;
                _context.MenuItems.Remove(MenuItem);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
