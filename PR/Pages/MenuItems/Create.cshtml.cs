using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using PR.Models;

namespace PR.Pages.MenuItems
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
            ViewData["CategoryName"] = new SelectList(_context.Categories.Select(c => c.Name).Distinct().OrderBy(c => c).ToList());
            ViewData["UserName"] = new SelectList(_context.Users.Select(u => u.Name).Distinct().OrderBy(u => u).ToList());
            //ViewData["CategoryId"] = new SelectList(_context.Categories, "Id", "Id");
            //ViewData["UsersId"] = new SelectList(_context.Users, "Id", "Id");
            return Page();
        }

        [BindProperty]
        public MenuItem MenuItem { get; set; } = default!;
        [BindProperty]
        public string SelectedCategoryName { get; set; } = default!;
        [BindProperty]
        public string SelectedUserName { get; set; } = default!;


        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
            var selectedCategory = _context.Categories.FirstOrDefault(c => c.Name == SelectedCategoryName);

            if (selectedCategory != null)
            {
                MenuItem.CategoryId = selectedCategory.Id;
            }
            else
            {
                ModelState.AddModelError(string.Empty, "Invalid category selected.");
                ViewData["CategoryName"] = new SelectList(_context.Categories, "CategoryName", "CategoryName");
                return Page();
            }



            var SelectedUser = _context.Users.FirstOrDefault(u => u.Name == SelectedUserName);

            if (SelectedUser != null)
            {
                MenuItem.UsersId = SelectedUser.Id;
            }
            else
            {
                ModelState.AddModelError(string.Empty, "Invalid user selected.");
                ViewData["UserName"] = new SelectList(_context.Users, "UserName", "UserName");
                return Page();
            }


            var fileName = Path.GetFileName(MenuItem.ProductImageFile.FileName);
            var filePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/img/MenuItem", fileName);

            using (var fileStream = new FileStream(filePath, FileMode.Create))
            {
                await MenuItem.ProductImageFile.CopyToAsync(fileStream);
            }

            MenuItem.Img = fileName;



            //if (!ModelState.IsValid || _context.MenuItems == null || MenuItem == null)
            //{
            //    return Page();
            //}

            _context.MenuItems.Add(MenuItem);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
