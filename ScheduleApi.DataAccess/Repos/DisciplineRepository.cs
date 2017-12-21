using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.EntityFrameworkCore;
using ScheduleApi.Domain.Entities;

namespace ScheduleApi.DataAccess.Repos
{
    class DisciplineRepository : Repository<Discipline>, IDisciplineRepository
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

        public IEnumerable<Discipline> GetByCourse(int courseNum)
        {
            return context.Set<ScheduleEntry>()
                .Include(x => x.Discipline)
                .ThenInclude(x => x.Teachers)
                .Include(x => x.Group)
                .Where(x => x.Group.CourseNum == courseNum)
                .Select(x => x.Discipline);
        }
    }
}
