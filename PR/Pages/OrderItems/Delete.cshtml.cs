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
    public class DeleteModel : PageModel
    {
        private readonly PR.Models.FoodContext _context;

        public DeleteModel(PR.Models.FoodContext context)
        {
            _context = context;
        }

        [BindProperty]
      public OrderItem OrderItem { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.OrderItems == null)
            {
                return NotFound();
            }

            var orderitem = await _context.OrderItems.FirstOrDefaultAsync(m => m.Id == id);

            if (orderitem == null)
            {
                return NotFound();
            }
            else 
            {
                OrderItem = orderitem;
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null || _context.OrderItems == null)
            {
                return NotFound();
            }
            var orderitem = await _context.OrderItems.FindAsync(id);

            if (orderitem != null)
            {
                OrderItem = orderitem;
                _context.OrderItems.Remove(OrderItem);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
