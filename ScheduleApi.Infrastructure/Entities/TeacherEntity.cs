using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;


namespace ScheduleApi.Infrastructure.Entities
{
    public class TeacherEntity : Entity
    {
        public TeacherEntity()
        {
            Disciplines = new List<DisciplineEntity>();
        }

        [Required]
        public string Name { get; set; }
    
        public string Email { get; set; }

        public ICollection<DisciplineEntity> Disciplines { get; set; }
    }
}
