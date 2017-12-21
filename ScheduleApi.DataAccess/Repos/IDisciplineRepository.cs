using System;
using System.Collections.Generic;
using System.Text;
using ScheduleApi.Domain.Entities;

namespace ScheduleApi.DataAccess
{
    public interface IDisciplineRepository : IRepository<Discipline>
    {
        IEnumerable<Discipline> GetByCourse(int courseNum);

    }
}
