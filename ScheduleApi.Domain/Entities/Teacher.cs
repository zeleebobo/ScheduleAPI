using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace ScheduleApi.Domain.Entities
{
    public class Teacher
    {
        public Teacher()
        {
            TeacherDisciplines = new List<TeacherDiscipline>();
        }

        [Key]
        public int Id { get; private set; }

        [Required]
        public string Name { get; private set; }

        [Required]
        [RegularExpression("\\w+@\\w+[.]\\w{2,4}")] // email expression
        public string Email { get; private set; }

        public virtual ICollection<TeacherDiscipline> TeacherDisciplines { get; private set; }

        public virtual ICollection<ScheduleEntry> Entries { get; private set; }
    }
}
