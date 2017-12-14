using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using App.DtoModels;
using AutoMapper;
using ScheduleApi.Domain.Entities;
using ScheduleApi.DtoModels;

namespace App.Services
{
    public class ScheduleConverter : ITypeConverter<Schedule, IEnumerable<ScheduleGroupDto>>
    {

        public IEnumerable<ScheduleGroupDto> Convert(Schedule source, IEnumerable<ScheduleGroupDto> destination, ResolutionContext context)
        {
            var entriesByGroup = source.Entries
                                    .GroupBy(x => x.Group)
                                    .Select(x => new {Group = x.Key, Entries = x});

            foreach (var groupEntries in entriesByGroup)
            {
                var scheduleGroup = new ScheduleGroupDto(){Group = Mapper.Map<GroupDto>(groupEntries.Group)};

                var groupEntriesByDay = groupEntries.Entries
                                            .GroupBy(x => x.DayOfWeek)
                                            .ToDictionary(x => x.Key.ToString(), Mapper.Map<IEnumerable<ScheduleEntry>, IEnumerable<ScheduleGroupEntryDto>>);
                var days = Enum.GetValues(typeof(ScheduleEntry.DaysEnum)).Cast<ScheduleEntry.DaysEnum>().Select(x => x.ToString()).ToArray();

                foreach (var day in days)
                {
                    if (groupEntriesByDay.ContainsKey(day)) continue;
                    groupEntriesByDay[day] = new List<ScheduleGroupEntryDto>();
                }

                scheduleGroup.Monday = groupEntriesByDay[days[0]];
                scheduleGroup.Tuesday = groupEntriesByDay[days[1]];
                scheduleGroup.Wednesday = groupEntriesByDay[days[2]];
                scheduleGroup.Thursday = groupEntriesByDay[days[3]];
                scheduleGroup.Friday = groupEntriesByDay[days[4]];
                scheduleGroup.Saturday = groupEntriesByDay[days[5]];

                yield return scheduleGroup;
            }
        }
    }
}
