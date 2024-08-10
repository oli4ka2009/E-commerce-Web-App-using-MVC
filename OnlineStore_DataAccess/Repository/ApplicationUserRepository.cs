﻿using OnlineStore_DataAccess.Repository.IRepository;
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
    public class ApplicationUserRepository : Repository<ApplicationUser>, IApplicationUserRepository
    {
        private readonly ApplicationDBContext _dbContext;

        public ApplicationUserRepository(ApplicationDBContext db) : base(db) 
        {
            _dbContext = db;
        }

        public void Update(ApplicationUser applicationUser)
        {
            _dbContext.ApplicationUsers.Update(applicationUser);
        }
    }
}
