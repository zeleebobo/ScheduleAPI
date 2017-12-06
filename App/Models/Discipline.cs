using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace ScheduleApi.Models
{
    public class Discipline
    {
        [JsonProperty("id")]
        public int Id { get; set; }

        [JsonProperty("name")]
        public int Name { get; set; }

        [JsonProperty("teacherIds")]
        public int[] TeacherIds { get; set; }
    }
}
