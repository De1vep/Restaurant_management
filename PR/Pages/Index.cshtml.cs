﻿using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using PR.Constants;
using PR.Models;
using PR.Requests;

namespace PR.Pages
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

        public IList<MenuItem> MenuItem { get; set; } = default!;
        public IList<Category> Category { get; set; } = default!;
        public IList<Table> Tables { get; set; } = default!;

        [BindProperty]
        public BookTableRequest? BookTableRequest { get; set; }

        public async Task OnGetAsync()
        {
            if (_context.MenuItems != null)
            {
                MenuItem = await _context.MenuItems
                    .Include(p => p.Category)
                    .ToListAsync();
            }

            if (_context.Categories != null)
            {
                Category = await _context.Categories.ToListAsync();
            }


            if (_context.Tables != null)
            {
                Tables = await _context.Tables
                    .Where(x => x.Status!.Trim().ToLower() == TableStatus.AVAILABLE)
                    .ToListAsync();
            }

        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid) return RedirectToPage("/Index");

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

            var existTable = await _context.Tables.FirstOrDefaultAsync(x => x.Id == BookTableRequest!.TableId);
            if (existTable is not null)
            {
                existTable.Status = TableStatus.RESERVED;
            } else
            {
                return Page();
            }

            _context.Reservations.Add(reservation);
            await _context.SaveChangesAsync();

            return RedirectToPage("/Reservations/Successfully");

        }

        public async Task<JsonResult> OnGetMenuItemsAsync(string? categoryName)
        {
            var menuItems = string.IsNullOrEmpty(categoryName)
                ? await _context.MenuItems.Include(m => m.Category).ToListAsync()
                : await _context.MenuItems
                    .Include(m => m.Category)
                    .Where(m => m.Category.Name.ToLower() == categoryName.ToLower())
                    .ToListAsync();

            return new JsonResult(menuItems.Select(m => new
            {
                m.Id,
                m.Name,
                Img = Url.Content($"~/img/MenuItem/{m.Img}"),
                m.Description,
                m.Price,
                CategoryName = m.Category.Name
            }));
        }

    }
}

