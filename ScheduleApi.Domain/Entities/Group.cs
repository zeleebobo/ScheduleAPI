using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Reflection;
using System.Text;
using System.Text.RegularExpressions;

namespace ScheduleApi.Domain.Entities
{
    public class Group
    {
        private int GetCourseNum(string groupName)
        {
            var pattern = "\\w+-\\d+";
            if (!Regex.IsMatch(groupName, pattern, RegexOptions.Compiled)) return 0; //throw new FormatException();
            return (int) char.GetNumericValue(groupName.Split('-')[1][0]);
        }

        [Required]
        public string Name { get; private set; }

        [NotMapped]
        public int CourseNum => GetCourseNum(Name);

        public int Id { get; private set; }

        public virtual ICollection<ScheduleEntry> Entries { get; private set; }

    }
}
