using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;

namespace ScheduleApi.Domain.Entities
{
    public class Schedule
    {
        [Key]
        public int Id { get; private set; }

        public string Name { get; set; }

        private ICollection<ScheduleEntry> entries;

        public Schedule()
        {
            Name = "Schedule";
        }

        public ICollection<ScheduleEntry> Entries { get; }

        public bool IsCorrect
        {
            get { return true; } // TODO: Checking for correctness 
        }
        
    }
}
