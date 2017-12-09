
namespace ScheduleApi.Infrastructure.Entities
{
    public class Schedule : Entity
    {
        public int DayId { get; set; }
        
        public int WeekNumber { get; set; }
        
        public int Number { get; set; }
        
        public TeacherEntity Teacher { get; set; }
        
        public DisciplineEntity Discipline { get; set; }
        
        public RoomEntity Room { get; set; }
        
        public GroupEntity Group { get; set; }
        
        public int SubgroupNumber { get; set; }
    }
}
