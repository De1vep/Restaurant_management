using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using PR.Constants;
using PR.Models;
using PR.Requests;

namespace PR.Pages.BookTable
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;
        private readonly PR.Models.FoodContext _context;

        public IndexModel(PR.Models.FoodContext context, ILogger<IndexModel> logger)
        {
            _context = context;
            _logger = logger;
        }


        public IList<Table> Tables { get; set; } = default!;

        [BindProperty]
        public BookTableRequest? BookTableRequest { get; set; }

        public async Task<IActionResult> OnGet()
        {
            if (_context.Tables != null)
            {
                Tables = await _context.Tables
                    .Where(x => x.Status!.Trim().ToLower() == TableStatus.AVAILABLE)
                    .ToListAsync();
            }

            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (_context.Tables != null)
            {
                Tables = await _context.Tables
                    .Where(x => x.Status!.Trim().ToLower() == TableStatus.AVAILABLE)
                    .ToListAsync();
            }

            if (!ModelState.IsValid)
            {
                return Page();
            }

            var existUser = await _context.Users
                    .Where(x => x.Email!.ToLower() == BookTableRequest!.Email.ToLower())
                    .FirstOrDefaultAsync();
            var userId = 0;

            if (existUser is not null)
            {
                userId = existUser.Id;
            }
            else
            {
                var user = new User()
                {
                    Name = BookTableRequest?.Name,
                    Email = BookTableRequest?.Email,
                    Phone = BookTableRequest?.Phone,
                    RoleId = (int)RoleEnum.Customer,
                    Password = "password123",
                    Img = "img3.jpg",
                    CreatedAt = DateTime.Now
                };

                _context.Users.Add(user);
                await _context.SaveChangesAsync();

                userId = user.Id;
            }

            var reservation = new Reservation()
            {
                ReservationTime = BookTableRequest?.BookDate,
                UsersId = userId,
                TableId = BookTableRequest?.TableId,
                Status = ReservationStatus.PENDING,
            };

            var existTable = await _context.Tables!.FirstOrDefaultAsync(x => x.Id == BookTableRequest!.TableId);
            if (existTable is not null)
            {
                existTable.Status = TableStatus.RESERVED;
            }
            else
            {
                return Page();
            }

            _context.Reservations.Add(reservation);
            await _context.SaveChangesAsync();

            return RedirectToPage("/Reservations/Successfully");

        }

    }
}
