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
    public class OrderDetailRepository : Repository<OrderDetail>, IOrderDetailRepository
    {
        private readonly ApplicationDBContext _dbContext;

        public OrderDetailRepository(ApplicationDBContext db) : base(db) 
        {
            _dbContext = db;
        }

        public void Update(OrderDetail orderDetail)
        {
            _dbContext.OrderDetails.Update(orderDetail);
        }
    }
}
