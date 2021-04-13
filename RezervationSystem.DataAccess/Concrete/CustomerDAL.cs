using Microsoft.EntityFrameworkCore;
using RezervationSystem.DataAccess.Abstract;
using RezervationSystem.DataAccess.Postgre;
using RezervationSystem.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace RezervationSystem.DataAccess.Concrete
{
    public class CustomerDAL : EntityPostgreRepositoryBase<Customers>, ICustomerDAL
    {
        public CustomerDAL(DbContext _dbContext, Customers _entity) : base(_dbContext, _entity)
        {
        }
    }
}
