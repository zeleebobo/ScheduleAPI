using Newtonsoft.Json;

namespace App.DtoModels
{
    public class Model
    {
        [JsonProperty("id")]
        public int Id { get; set; }
    }
}
