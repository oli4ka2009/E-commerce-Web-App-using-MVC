using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using OnlineStoreWebApp_v2.Data;
using OnlineStoreWebApp_v2.Models;

namespace OnlineStoreWebApp_v2.Pages.Categories
{
    public class CreateModel : PageModel
    {
        private readonly ApplicationDBContext _dbContext;

        [BindProperty]
        public Category Category { get; set; }

        public CreateModel(ApplicationDBContext db)
        {
            _dbContext = db;
        }

        public void OnGet()
        {
        }

        public IActionResult OnPost() 
        {
            _dbContext.Categories.Add(Category);
            _dbContext.SaveChanges();

            TempData["success"] = "Category was created successfully";

            return RedirectToPage("Index");
        }
    }
}
