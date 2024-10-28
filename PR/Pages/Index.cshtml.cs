using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using PR.Models;

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

