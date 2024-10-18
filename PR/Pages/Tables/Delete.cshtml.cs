using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using PR.Models;

namespace PR.Pages.Tables
{
    public class DeleteModel : PageModel
    {
        private readonly PR.Models.FoodContext _context;

        public DeleteModel(PR.Models.FoodContext context)
        {
            _context = context;
        }

        [BindProperty]
      public Table Table { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Tables == null)
            {
                return NotFound();
            }

            var table = await _context.Tables.FirstOrDefaultAsync(m => m.Id == id);

            if (table == null)
            {
                return NotFound();
            }
            else 
            {
                Table = table;
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null || _context.Tables == null)
            {
                return NotFound();
            }
            var table = await _context.Tables.FindAsync(id);

            if (table != null)
            {
                Table = table;
                _context.Tables.Remove(Table);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
