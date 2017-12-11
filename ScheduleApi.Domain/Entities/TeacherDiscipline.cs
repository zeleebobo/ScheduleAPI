using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace ScheduleApi.Domain.Entities
{
    public class TeacherDiscipline
    {
        public TeacherDiscipline()
        {
            
        }

        public TeacherDiscipline(Discipline discipline, Teacher teacher)
        {
            Discipline = discipline;
            Teacher = teacher;
        }

        public int Id { get; private set; }
        public Teacher Teacher { get; private set; }
        public Discipline Discipline { get; private set; }
    }
}
