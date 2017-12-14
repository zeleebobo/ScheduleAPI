using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.EntityFrameworkCore;
using ScheduleApi.Domain.Entities;

namespace ScheduleApi.DataAccess.Repos
{
    class DisciplineRepository : Repository<Discipline>
    {
        public DisciplineRepository(ScheduleContext context) : base(context)
        {
        }

        public override IEnumerable<Discipline> GetAll()
        {
            return context.Set<Discipline>().Include(x => x.Teachers);
        }

        public override Discipline GetById(int id)
        {
            return context.Set<Discipline>().Include(x => x.Teachers).SingleOrDefault(x => x.Id == id);
        }
    }
}
