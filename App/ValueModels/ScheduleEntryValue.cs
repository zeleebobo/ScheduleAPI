using Newtonsoft.Json;

namespace ScheduleApi.Models
{
    public class Schedule
    {
        [JsonProperty("dayId")]
        public int DayId { get; set; }

        [JsonProperty("weekNumber")]
        public int WeekNumber { get; set; }

        [JsonProperty("number")]
        public int Number { get; set; }

        [JsonProperty("teacherId")]
        public int TeacherId { get; set; }

        [JsonProperty("disciplineId")]
        public int DisciplineId { get; set; }

        [JsonProperty("roomId")]
        public int RoomId { get; set; }

        [JsonProperty("groupId")]
        public int GroupId { get; set; }

        [JsonProperty("subgroupNumber")]
        public int SubgroupNumber { get; set; }
    }
}
