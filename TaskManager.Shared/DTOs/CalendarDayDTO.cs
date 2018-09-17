using System;
using System.Collections.Generic;

namespace TaskManager.Shared.DTOs
{
    public class CalendarDayDTO
    {
        public int Id { get; set; }
        public DateTime Date { get; set; }
        public TimeSpan FreeTime { get; set; }
        public List<TaskDTO> Tasks { get; set; }

        public CalendarDayDTO()
        {
            Tasks = new List<TaskDTO>();
        }
    }
}