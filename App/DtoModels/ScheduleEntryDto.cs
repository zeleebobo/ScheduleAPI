using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using ScheduleApi.Domain.Entities;

namespace App.DtoModels
{
    public class ScheduleEntryDto
    {
        [JsonProperty("dayOfWeek")]
        [JsonConverter(typeof(StringEnumConverter))]
        [JsonRequired]
        public ScheduleEntry.DaysEnum DayOfWeek { get; set; }

        [JsonProperty("weekNumber")]
        [JsonRequired]
        public int WeekNumber { get; set; }

        [JsonProperty("teacherId")]
        [JsonRequired]
        public int TeacherId { get; set; }

        [JsonProperty("disciplineId")]
        [JsonRequired]
        public int DisciplineId { get; set; }

        [JsonProperty("roomId")]
        [JsonRequired]
        public int RoomId { get; set; }

        [JsonProperty("groupId")]
        [JsonRequired]
        public int GroupId { get; set; }

        [JsonProperty("subGroupNum")]
        [JsonRequired]
        public int SubGroupNum { get; set; }

        [JsonProperty("position")]
        [JsonRequired]
        public int Position { get; set; }
    }
}
