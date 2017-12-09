using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ScheduleApi.Infrastructure.Entities
{
    public class RoomEntity : Entity
    {
        [Required]
        public string Name { get; set; }
    }
}
