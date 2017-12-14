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

        public  ICollection<TeacherDiscipline> TeacherDisciplines { get; private set; }

        public IEnumerable<Teacher> Teachers => TeacherDisciplines.Select(x => x.Teacher);

        public ICollection<ScheduleEntry> Entries { get; private set; }

        public void AddTeacher(Teacher teacher)
        {
            TeacherDisciplines.Add(new TeacherDiscipline(this, teacher));
        }

        public void RemoveTeacher(Teacher teacher)
        {
            var teacherDiscipline = TeacherDisciplines.FirstOrDefault(x => x.Teacher.Id == teacher.Id);
            if (teacherDiscipline == null) throw new ArgumentException("Teacher must be into discipline list.");
            TeacherDisciplines.Remove(teacherDiscipline);
        }
    }
}
