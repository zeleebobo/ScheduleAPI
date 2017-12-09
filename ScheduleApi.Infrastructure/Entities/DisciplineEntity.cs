using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ScheduleApi.Infrastructure.Entities
{
    public class DisciplineEntity : Entity
    {
        public DisciplineEntity()
        {
            Teachers = new List<TeacherEntity>();
        }
        
        [Required]
        public string Name { get; set; }
        
        public ICollection<TeacherEntity> Teachers { get; set; }
    }
}
