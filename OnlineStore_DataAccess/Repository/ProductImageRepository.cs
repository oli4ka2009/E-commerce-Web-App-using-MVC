using OnlineStore_DataAccess.Repository.IRepository;
using OnlineStore_Models.Models;
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
    public class ProductImageRepository : Repository<ProductImage>, IProductImageRepository
    {
        private readonly ApplicationDBContext _dbContext;

        public ProductImageRepository(ApplicationDBContext db) : base(db) 
        {
            _dbContext = db;
        }

        public void Update(ProductImage ProductImage)
        {
            _dbContext.ProductImages.Update(ProductImage);
        }
    }
}
