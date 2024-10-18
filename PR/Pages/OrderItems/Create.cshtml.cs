using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using PR.Models;

namespace PR.Pages.OrderItems
{
    public class CreateModel : PageModel
    {
        private readonly PR.Models.FoodContext _context;

        public CreateModel(PR.Models.FoodContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
        ViewData["MenuItemId"] = new SelectList(_context.MenuItems, "Id", "Id");
        ViewData["OrderId"] = new SelectList(_context.Orders, "Id", "Id");
            return Page();
        }

        [BindProperty]
        public OrderItem OrderItem { get; set; } = default!;
        

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
          if (!ModelState.IsValid || _context.OrderItems == null || OrderItem == null)
            {
                return Page();
            }

            _context.OrderItems.Add(OrderItem);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
