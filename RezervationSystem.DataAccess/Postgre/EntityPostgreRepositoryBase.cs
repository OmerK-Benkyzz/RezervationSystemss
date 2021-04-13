using Microsoft.EntityFrameworkCore;
using RezervationSystem.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace RezervationSystem.DataAccess.Postgre
{
    public class EntityPostgreRepositoryBase<T> : IEntityPostgreRepository<T> where T : class, IEntity
    {

        protected readonly DbContext dbContext;
        public T entity;
        public EntityPostgreRepositoryBase(DbContext _dbContext,T _entity)
        {

            entity = _entity;
            dbContext = _dbContext;

        }
        public void Add(T entitiy)
        {
            var addedEntity = dbContext.Entry(entity);
            addedEntity.State = EntityState.Added;
            dbContext.SaveChanges();

        }

        public void Delete(T entity)
        {
            var deletedEntity = dbContext.Entry(entity);
            deletedEntity.State = EntityState.Deleted;
            dbContext.SaveChanges();
        }

        public T Get(Expression<Func<T, bool>> where, Expression<Func<T, T>> select)
        {
            if (select == null && where == null)
            {
                var result = dbContext.Set<T>().Where(x => true).Select(x => x);
                return result.FirstOrDefault();

            }
            else if (select == null)
            {

                var result = dbContext.Set<T>().Where(where).Select(x => x);
                return result.FirstOrDefault();
            }
            else if (where == null)
            {
                var result = dbContext.Set<T>().Where(x => true).Select(select);
                return result.FirstOrDefault();

            }
            else
            {
                var result = dbContext.Set<T>().Where(where).Select(select);
                return result.FirstOrDefault();

            }
        }

        public List<T> GetList(Expression<Func<T, bool>> where, Expression<Func<T, T>> select)
        {
            if(select == null && where == null)
            {
                var result = dbContext.Set<T>().Where(x => true).Select(x => x).ToList();
                return result;
                
            }
            else if (select == null)
            {

                var result = dbContext.Set<T>().Where(where).Select(x => x).ToList();
                return result;
            }
            else if(where == null)
            {
                var result = dbContext.Set<T>().Where(x=>true).Select(select).ToList();
                return result;

            }
            else
            {
                var result = dbContext.Set<T>().Where(where).Select(select).ToList();
                return result;

            }

        }

        public void Update(T entity)
        {
            var updatedEntity = dbContext.Entry(entity);
            updatedEntity.State = EntityState.Modified;
            dbContext.SaveChanges();
        }
    }
}
