using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace ScheduleApi.Domain.Entities
{
    public class Room
    {
        [Required]
        public string Name { get; private set; }

        [Key]
        public int Id { get; private set; }

        public virtual ICollection<ScheduleEntry> Entries { get; private set; }
    }
}
