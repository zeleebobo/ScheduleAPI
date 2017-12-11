using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace ScheduleApi.Domain.Entities
{
    public class ScheduleEntry
    {
        public enum DaysEnum
        {
            Monday,
            Tuesday,
            Wednesday,
            Thursday,
            Friday,
            Saturday
        }

        [Key]
        public int Id { get; private set; }

        [Required]
        public DaysEnum DayOfWeek { get; set; }

        [Required]
        public int WeekNumber { get; set; }

        [Required]
        public Teacher Teacher { get; set; }

        [Required]
        public Discipline Discipline { get; set; }

        [Required]
        public Room Room { get; set; }

        [Required]
        public Group Group { get; set; }

        public int SubGroupNum { get; set; }


        public virtual Schedule Schedule { get; set; }
    }
}
