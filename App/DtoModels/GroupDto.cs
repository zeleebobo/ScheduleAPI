using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using App.DtoModels;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace ScheduleApi.DtoModels
{
    public class GroupDto : Model
    {
        [JsonProperty("name")]
        [JsonRequired]
        [Required]
        public string Name { get; set; }

        public int CourseNum { get; set; }
    }
}
