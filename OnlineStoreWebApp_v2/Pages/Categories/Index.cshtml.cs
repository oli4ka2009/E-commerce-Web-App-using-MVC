using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using OnlineStoreWebApp_v2.Data;
using OnlineStoreWebApp_v2.Models;

namespace OnlineStoreWebApp_v2.Pages.Categories
{
    public class IndexModel : PageModel
    {
        private readonly ApplicationDBContext _dbContext;
        public List<Category> CategoryList { get; set; }

        public IndexModel(ApplicationDBContext db)
        {
            _dbContext = db;
        }

        public void OnGet()
        {
            CategoryList = _dbContext.Categories.ToList();
        }
    }
}
