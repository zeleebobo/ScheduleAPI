using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace ScheduleApi.DtoModels
{
    public class Credentials
    {
        [JsonProperty("login")]
        [JsonRequired]
        public string Login { get; set; }

        [JsonProperty("password")]
        [JsonRequired]
        public string Password { get; set; }
    }
}
