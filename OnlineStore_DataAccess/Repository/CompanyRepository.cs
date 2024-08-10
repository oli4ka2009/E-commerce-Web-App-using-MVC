using OnlineStore_DataAccess.Repository.IRepository;
using OnlineStore_Models.Models;
using OnlineStoreWebApp.DataAccess.Data;
using OnlineStoreWebApp.Models.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineStore_DataAccess.Repository
{
    public class CompanyRepository : Repository<Company>, ICompanyRepository
    {
        private readonly ApplicationDBContext _dbContext;

        public CompanyRepository(ApplicationDBContext db) : base(db)
        {
            _dbContext = db;
        }

        public void Update(Company company)
        {
            _dbContext.Companies.Update(company);
        }
    }
}
