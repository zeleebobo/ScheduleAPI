using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace ScheduleApi.DataAccess
{
    public interface IRepository<TEntity> : IDisposable where TEntity: class 
    {
        TEntity Add(TEntity entity); 

        TEntity GetById(int id);

        TEntity SingleOrDefault(Expression<Func<TEntity, bool>> predicate);

        void Delete(TEntity entity);

        IEnumerable<TEntity> GetAll();
    }
}
