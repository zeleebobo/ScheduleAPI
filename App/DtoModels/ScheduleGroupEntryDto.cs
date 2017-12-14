using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using ScheduleApi.DtoModels;

namespace App.DtoModels
{
    public class ScheduleGroupEntryDto
    {
        [JsonProperty("position")]
        public int Position { get; set; }

        [JsonProperty("subject")]
        public DisciplineDto Discipline { get; set; }

        [JsonProperty("room")]
        public RoomDto Room { get; set; }

        [JsonProperty("subgroup")]
        public int SubGroupNum { get; set; }

        [JsonProperty("week")]
        public int Week { get; set; }


    }
}
