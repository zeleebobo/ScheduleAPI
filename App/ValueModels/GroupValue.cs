using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using App.Models;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace ScheduleApi.Models
{
    public class GroupValue : TEntity
    {
        [JsonProperty("name")]
        [JsonRequired]
        [Required]
        public string Name { get; set; }
    }
}
