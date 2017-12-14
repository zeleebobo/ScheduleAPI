using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using ScheduleApi.DtoModels;

namespace App.DtoModels
{
    public class ScheduleGroupDto
    {
        [JsonProperty("group")]
        public GroupDto Group { get; set; }

        [JsonProperty("monday")]
        public IEnumerable<ScheduleGroupEntryDto> Monday { get; set; }

        [JsonProperty("tuesday")]
        public IEnumerable<ScheduleGroupEntryDto> Tuesday { get; set; }

        [JsonProperty("wednesday")]
        public IEnumerable<ScheduleGroupEntryDto> Wednesday { get; set; }

        [JsonProperty("thursday")]
        public IEnumerable<ScheduleGroupEntryDto> Thursday { get; set; }

        [JsonProperty("friday")]
        public IEnumerable<ScheduleGroupEntryDto> Friday { get; set; }

        [JsonProperty("saturday")]
        public IEnumerable<ScheduleGroupEntryDto> Saturday { get; set; }
    }
}
