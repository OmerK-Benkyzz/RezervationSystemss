using RezervationSystem.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace RezervationSystem.DataAccess.Postgre
{
   public interface IEntityPostgreRepository<T> where T:class ,IEntity
    {
        void Add(T entitiy);
        void Delete(T entity);
        void Update(T entity);
        T Get(Expression<Func<T, bool>> where, Expression<Func<T, T>> select);
        List<T> GetList(Expression<Func<T, bool>> where, Expression<Func<T, T>> select);
    }
}
