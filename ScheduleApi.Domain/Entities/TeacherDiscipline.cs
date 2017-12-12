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

        public int TeacherId { get; private set; }
        public virtual Teacher Teacher { get; private set; }

        public int DisciplineId { get; private set; }
        public virtual Discipline Discipline { get; private set; }
    }
}
