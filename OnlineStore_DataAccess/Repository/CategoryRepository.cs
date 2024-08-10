using OnlineStore_DataAccess.Repository.IRepository;
using OnlineStoreWebApp.DataAccess.Data;
using OnlineStoreWebApp.Models.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace OnlineStore_DataAccess.Repository
{
    public class CategoryRepository : Repository<Category>, ICategoryRepository
    {
        private readonly ApplicationDBContext _dbContext;

        public CategoryRepository(ApplicationDBContext db) : base(db) 
        {
            _dbContext = db;
        }

        public void Update(Category category)
        {
            _dbContext.Categories.Update(category);
        }
    }
}
