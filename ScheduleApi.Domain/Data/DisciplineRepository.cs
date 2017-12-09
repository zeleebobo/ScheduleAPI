using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ScheduleApi.Domain.Models;
using ScheduleApi.Infrastructure.Db;
using ScheduleApi.Infrastructure.Entities;

namespace ScheduleApi.Domain
{
    public class DisciplineRepository : IRepository<Discipline>
    {
        private ScheduleContext context;
        public DisciplineRepository()
        {
            context = new ScheduleContext();
        }

        public void Create(Discipline entity)
        {
            
        }

        public void Update(Discipline entity)
        {
            throw new NotImplementedException();
        }

        public Discipline Get(int id)
        {
            throw new NotImplementedException();
        }

        public void Delete(Discipline entity)
        {
            throw new NotImplementedException();
        }

        public ICollection<Discipline> GetAll()
        {
            throw new NotImplementedException();
        }

        private bool disposed = false;

        public virtual void Dispose(bool disposing)
        {
            if (!disposed)
            {
                if (disposing)
                {
                    context.Dispose();
                }
            }
            disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
        }
    }
}
