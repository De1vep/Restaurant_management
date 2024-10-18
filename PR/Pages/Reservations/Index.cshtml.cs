using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using PR.Models;

namespace PR.Pages.Reservations
{
    public class IndexModel : PageModel
    {
        private readonly PR.Models.FoodContext _context;

        public IndexModel(PR.Models.FoodContext context)
        {
            _context = context;
        }

        public IList<Reservation> Reservation { get;set; } = default!;

        public async Task OnGetAsync()
        {
            if (_context.Reservations != null)
            {
                Reservation = await _context.Reservations
                .Include(r => r.Table)
                .Include(r => r.Users).ToListAsync();
            }
        }
    }
}
