using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using Microsoft.EntityFrameworkCore;

namespace ScheduleApi.DataAccess.Repos
{
    public class Repository<TEntity> : IRepository<TEntity> where TEntity: class
    {
        protected DbContext context;
        protected DbSet<TEntity> entities;
        public Repository(DbContext context)
        {
            this.context = context;
            entities = context.Set<TEntity>();
        }

        public void Dispose()
        {
            context.Dispose();
        }

        public TEntity Add(TEntity entity)
        {
            return entities.Add(entity).Entity;
        }

        public virtual TEntity GetById(int id)
        {
            return entities.Find(id);
        }

        public TEntity SingleOrDefault(Expression<Func<TEntity, bool>> predicate)
        {
            return entities.SingleOrDefault(predicate);
        }

        public void Delete(TEntity entity)
        {
            entities.Remove(entity);
        }

        public virtual IEnumerable<TEntity> GetAll()
        {
            return entities.ToList();
        }
    }
}
