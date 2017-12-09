using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;
using System.Text.RegularExpressions;

namespace ScheduleApi.Domain.Models
{
    public class Group
    {
        public Group(int id, string name)
        {
            Id = id;
            Name = name;
            CourseNum = GetCourseNum(name);
        }

        private int GetCourseNum(string groupName)
        {
            var pattern = "\\w+-\\d+";
            if (!Regex.IsMatch(groupName, pattern, RegexOptions.Compiled)) throw new FormatException();
            return (int) char.GetNumericValue(groupName.Split('-')[1][0]);
        }

        public string Name { get; }

        public int CourseNum { get; }

        public int Id { get; }
    }
}
