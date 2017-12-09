using System;
using System.Collections.Generic;
using System.Text;
using Remotion.Linq.Clauses.ResultOperators;

namespace ScheduleApi.Domain.Models
{
    public class ScheduleEntry
    {
        public enum Days
        {
            Monday,
            Tuesday,
            Wednesday,
            Thursday,
            Friday,
            Saturday
        }

        public Days DayOfWeek { get; set; }

        public int WeekNumber { get; set; }

        public Teacher Teacher { get; set; }

        public Discipline Discipline { get; set; }

        public Room Room { get; set; }

        public Group Group { get; set; }

        public int SubGroupNum { get; set; }
    }
}
