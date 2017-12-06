using Newtonsoft.Json;

namespace ScheduleApi.Models
{
    public class Order
    {
        [JsonProperty("id")]
        public int Id { get; set; }

        [JsonProperty("discipline")]
        public string Discipline { get; set; }

        [JsonProperty("lectionHours")]
        public int LectionHours { get; set; }

        [JsonProperty("practiceHours")]
        public int PracticeHours { get; set; }
    }
}
