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
                                            .ToDictionary(x => x.Key, x => x);
                if (groupEntriesByDay.ContainsKey(ScheduleEntry.DaysEnum.Monday))
                    scheduleGroup.Monday =
                        Mapper.Map<IEnumerable<ScheduleEntry>, IEnumerable<ScheduleGroupEntryDto>>(
                            groupEntriesByDay[ScheduleEntry.DaysEnum.Monday]);

                if (groupEntriesByDay.ContainsKey(ScheduleEntry.DaysEnum.Tuesday))
                    scheduleGroup.Tuesday =
                    Mapper.Map<IEnumerable<ScheduleEntry>, IEnumerable<ScheduleGroupEntryDto>>(
                        groupEntriesByDay[ScheduleEntry.DaysEnum.Tuesday]);

                if (groupEntriesByDay.ContainsKey(ScheduleEntry.DaysEnum.Wednesday))
                    scheduleGroup.Wednesday =
                    Mapper.Map<IEnumerable<ScheduleEntry>, IEnumerable<ScheduleGroupEntryDto>>(
                        groupEntriesByDay[ScheduleEntry.DaysEnum.Wednesday]);

                if (groupEntriesByDay.ContainsKey(ScheduleEntry.DaysEnum.Thursday))
                    scheduleGroup.Thursday =
                    Mapper.Map<IEnumerable<ScheduleEntry>, IEnumerable<ScheduleGroupEntryDto>>(
                        groupEntriesByDay[ScheduleEntry.DaysEnum.Thursday]);

                if (groupEntriesByDay.ContainsKey(ScheduleEntry.DaysEnum.Friday))
                    scheduleGroup.Friday =
                    Mapper.Map<IEnumerable<ScheduleEntry>, IEnumerable<ScheduleGroupEntryDto>>(
                        groupEntriesByDay[ScheduleEntry.DaysEnum.Friday]);

                if (groupEntriesByDay.ContainsKey(ScheduleEntry.DaysEnum.Saturday))
                    scheduleGroup.Saturday =
                    Mapper.Map<IEnumerable<ScheduleEntry>, IEnumerable<ScheduleGroupEntryDto>>(
                        groupEntriesByDay[ScheduleEntry.DaysEnum.Saturday]);


                yield return scheduleGroup;
            }
        }
    }
}
