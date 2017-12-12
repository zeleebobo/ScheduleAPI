
using Newtonsoft.Json;

public class ScheduleEntryDto
{
    [JsonProperty("dayOfWeek")]
    [JsonRequired]
    public int DayOfWeek { get; set; }
    
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
}