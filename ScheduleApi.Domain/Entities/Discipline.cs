using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;

namespace ScheduleApi.Domain.Entities
{
    public class Discipline
    {
        public Discipline()
        {
            TeacherDisciplines = new List<TeacherDiscipline>();
        }

        [Key]
        public int Id { get; private set; }

        [Required]
        public string Name { get; private set; }

        public virtual ICollection<TeacherDiscipline> TeacherDisciplines { get; private set; }

        public virtual ICollection<ScheduleEntry> Entries { get; private set; }
    }
}
