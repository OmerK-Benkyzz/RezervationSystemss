using Microsoft.EntityFrameworkCore;
using RezervationSystem.DataAccess.Abstract;
using RezervationSystem.DataAccess.Postgre;
using RezervationSystem.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace RezervationSystem.DataAccess.Concrete
{
    public class RoomDAL : EntityPostgreRepositoryBase<Rooms>, IRoomDAL
    {
        public RoomDAL(DbContext _dbContext, Rooms _entity) : base(_dbContext, _entity)
        {
        }
    }
}
