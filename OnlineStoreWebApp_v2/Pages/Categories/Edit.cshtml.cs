using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using OnlineStoreWebApp_v2.Data;
using OnlineStoreWebApp_v2.Models;

namespace OnlineStoreWebApp_v2.Pages.Categories
{
    public class EditModel : PageModel
    {
        private readonly ApplicationDBContext _dbContext;

        [BindProperty]
        public Category Category { get; set; }

        public EditModel(ApplicationDBContext db)
        {
            _dbContext = db;
        }

        public void OnGet(int? id)
        {
            if (id != 0)
            {
                Category = _dbContext.Categories.Find(id);
            }
        }

        public IActionResult OnPost()
        {
            if (ModelState.IsValid)
            {
                _dbContext.Categories.Update(Category);
                _dbContext.SaveChanges();

                TempData["success"] = "Category was updated successfully";

                return RedirectToPage("Index");
            }

            return Page();
        }
    }
}