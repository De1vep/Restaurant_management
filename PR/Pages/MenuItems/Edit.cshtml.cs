using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using PR.Models;

namespace PR.Pages.MenuItems
{
    public class EditModel : PageModel
    {
        private readonly PR.Models.FoodContext _context;

        public EditModel(PR.Models.FoodContext context)
        {
            _context = context;
        }

        [BindProperty]
        public MenuItem MenuItem { get; set; } = default!;
        [BindProperty]
        public IFormFile? NewImage { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.MenuItems == null)
            {
                return NotFound();
            }

            var menuitem =  await _context.MenuItems.Include(p => p.Category).Include(p => p.Users).FirstOrDefaultAsync(m => m.Id == id);
            if (menuitem == null)
            {
                return NotFound();
            }
            MenuItem = menuitem;


            var categoryNames = await _context.Categories
                            .Select(c => c.Name)
                            .Distinct()
                            .ToListAsync();
            ViewData["CategoryName"] = new SelectList(categoryNames);



            var userNames = await _context.Users
                .Select(c => c.Name)
                .Distinct()
                .ToListAsync();
            ViewData["UserName"] = new SelectList(userNames);


            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }


            var itemToUpdate = await _context.MenuItems
                                    .Include(p => p.Category)
                                    .Include (p => p.Users)
                                    .FirstOrDefaultAsync(p => p.Id == MenuItem.Id);

            if (itemToUpdate == null)
            {
                return NotFound();
            }

            if (NewImage != null && NewImage.Length > 0)
            {
                var filePath = Path.Combine("wwwroot/img/MenuItem", Path.GetFileName(NewImage.FileName));

                using (var stream = new FileStream(filePath, FileMode.Create))
                {
                    await NewImage.CopyToAsync(stream);
                }

                itemToUpdate.Img = Path.GetFileName(NewImage.FileName);
            }

            itemToUpdate.Name = MenuItem.Name;
            itemToUpdate.Description = MenuItem.Description;
            itemToUpdate.Price = MenuItem.Price;
            itemToUpdate.Users.Name = MenuItem.Users.Name;
            itemToUpdate.Category.Name = MenuItem.Category.Name;

            _context.Attach(itemToUpdate).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MenuItemExists(MenuItem.Id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }

        private bool MenuItemExists(int id)
        {
          return (_context.MenuItems?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
