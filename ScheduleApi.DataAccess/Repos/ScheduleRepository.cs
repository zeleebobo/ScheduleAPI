using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;
using ScheduleApi.Domain.Entities;

namespace ScheduleApi.DataAccess.Repos
{
    class ScheduleRepository : Repository<Schedule>
    {
        public ScheduleRepository(DbContext context) : base(context)
        {
            
        }

        

        public override IEnumerable<Schedule> GetAll()
        {
            return context.Set<Schedule>()
                .Include(x => x.Entries)
                .ThenInclude(x => x.Teacher)
                .Include(x => x.Entries)
                .ThenInclude(x => x.Discipline)
                .ThenInclude(x => x.TeacherDisciplines)
                .Include(x => x.Entries)
                .ThenInclude(x => x.Group)
                .Include(x => x.Entries)
                .ThenInclude(x => x.Room);
        }

        public override Schedule GetById(int id)
        {
            return context.Set<Schedule>()
                .Include(x => x.Entries)
                .ThenInclude(x => x.Teacher)
                .Include(x => x.Entries)
                .ThenInclude(x => x.Discipline)
                .ThenInclude(x => x.TeacherDisciplines)
                .Include(x => x.Entries)
                .ThenInclude(x => x.Group)
                .Include(x => x.Entries)
                .ThenInclude(x => x.Room)
                .FirstOrDefault(x => x.Id == id);
        }
    }
}
