using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace App.DtoModels
{
    public class OpenTeacherDto : Model
    {
        [JsonRequired]
        public string Name { get; set; }
    }
}
