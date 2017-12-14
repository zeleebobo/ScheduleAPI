using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace App.DtoModels
{
    public class ScheduleDto : Model
    {
        [JsonProperty("name")]
        [JsonRequired]
        public string Name { get; set; }

        [JsonProperty("created")]
        public DateTime Created { get; set; }
    }
}
