using System;
using System.Collections.Generic;
using TaskManager.Shared.Enums;

namespace TaskManager.Shared.DTOs
{
    public class ConcreteTaskDTO : TaskDTO
    {
        public TimeSpan Estimation { get; set; }
        public bool Requirement { get; set; }
        public DateTime StartTime { get; set; }
        public Frequency Frequency { get; set; }
        public List<CalendarDayDTO> Days { get; set; }
        public List<StageDTO> Stages { get; set; }

        public ConcreteTaskDTO()
        {
            Days = new List<CalendarDayDTO>();
            Stages = new List<StageDTO>();
        }
    }
}