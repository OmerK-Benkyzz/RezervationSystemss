using RezervationSystem.DataAccess.Postgre;
using RezervationSystem.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace RezervationSystem.DataAccess.Abstract
{
    interface ICustomerDAL : IEntityPostgreRepository<Customers>
    {
    }
}
