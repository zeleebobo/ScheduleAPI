using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ScheduleApi.Domain
{
    interface IRepository<TEntity> : IDisposable
    {
        void Create(TEntity entity);
        void Update(TEntity entity);
        TEntity Get(int id);

        void Delete(TEntity entity);

        ICollection<TEntity> GetAll();
    }
}
