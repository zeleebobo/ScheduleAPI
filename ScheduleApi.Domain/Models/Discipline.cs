using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ScheduleApi.Domain.Models
{
    public class Discipline
    {
        private ISet<Teacher> teachers;
        public Discipline(int id, string name)
        {
            Id = id;
            Name = name;
            teachers = new HashSet<Teacher>();
        }

        public int Id { get; }

        public string Name { get; }

        public ICollection<Teacher> Teachers => teachers.ToList();

        public void AddTeacher(Teacher teacher)
        {
            teachers.Add(teacher);
        }

        public void RemoveTeacher(Teacher teacher)
        {
            if (!teachers.Contains(teacher)) throw new ArgumentException();
            teachers.Remove(teacher);
        }
    }
}
