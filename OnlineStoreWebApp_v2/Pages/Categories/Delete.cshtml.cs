using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using OnlineStoreWebApp_v2.Data;
using OnlineStoreWebApp_v2.Models;

namespace OnlineStoreWebApp_v2.Pages.Categories
{
    public class DeleteModel : PageModel
    {
        private readonly ApplicationDBContext _dbContext;

        [BindProperty]
        public Category Category { get; set; }

        public DeleteModel(ApplicationDBContext db)
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
            Category? obj = _dbContext.Categories.Find(Category.Id);

            if (obj == null)
            {
                return NotFound();
            }

            _dbContext.Categories.Remove(obj);
            _dbContext.SaveChanges();

            TempData["success"] = "Category was deleted successfully";

            return RedirectToPage("Index");
        }
    }
}
