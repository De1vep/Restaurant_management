using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using PR.Models;

namespace PR.Pages.Carts
{
    public class IndexModel : PageModel
    {
        private readonly PR.Models.FoodContext _context;

        public IndexModel(PR.Models.FoodContext context)
        {
            _context = context;
        }
        public List<CartItem> CartItems { get; set; } = new List<CartItem>();
        public void OnGet()
        {

            CartItems = _context.OrderItems
    .Include(oi => oi.MenuItem)
    .Select(oi => new CartItem
    {
        Name = oi.MenuItem.Name,
        Img = oi.MenuItem.Img,
        Price = oi.MenuItem.Price ?? 0,
        Quantity = oi.Quantity ?? 0
    })
    .ToList();
        }
    }
}
