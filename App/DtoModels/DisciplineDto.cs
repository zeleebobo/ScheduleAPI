using System.Collections.Generic;
using App.DtoModels;
using Newtonsoft.Json;

namespace ScheduleApi.DtoModels
{
    public class DisciplineDto : Model
    {
        [JsonRequired]
        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("teachersIds")]
        public ICollection<int> TeachersIds { get; set; }
    }
}