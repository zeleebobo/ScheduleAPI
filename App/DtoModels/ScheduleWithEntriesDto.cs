﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace App.DtoModels
{
    public class ScheduleWithEntriesDto : ScheduleDto
    {
        [JsonProperty("entries")]
        public IEnumerable<ScheduleEntryDto> Entries { get; set; }
    }
}
