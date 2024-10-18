using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using PR.Models;

namespace PR.Pages.Reservations
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
        ViewData["TableId"] = new SelectList(_context.Tables, "Id", "Id");
        ViewData["UsersId"] = new SelectList(_context.Users, "Id", "Id");
            return Page();
        }

        [BindProperty]
        public Reservation Reservation { get; set; } = default!;
        

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
          if (!ModelState.IsValid || _context.Reservations == null || Reservation == null)
            {
                return Page();
            }

            _context.Reservations.Add(Reservation);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
