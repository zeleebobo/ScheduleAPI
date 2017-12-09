using System;
using System.Collections.Generic;
using System.Text;

namespace ScheduleApi.Domain.Models
{
    public class Room
    {
        public Room(int id, string name)
        {
            Id = id;
            Name = name;
        }

        public string Name { get; }

        public int Id { get; }
    }
}
