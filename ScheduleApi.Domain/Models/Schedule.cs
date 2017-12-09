using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ScheduleApi.Domain.Models
{
    public class Schedule
    {
        public string Name { get; set; }

        private ICollection<ScheduleEntry> entries;

        public Schedule(ICollection<ScheduleEntry> entries)
        {
            Name = "Schedule";
            this.entries = entries;
        }

        public ICollection<ScheduleEntry> Entries => entries.ToList();

        public bool IsCorrect
        {
            get { return true; } // TODO: Checking for correctness 
        }
        
    }
}
