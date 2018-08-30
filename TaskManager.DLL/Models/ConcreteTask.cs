using System;
using System.Collections.Generic;
using TaskManager.Shared.Enums;

namespace TaskManager.DLL.Models
{
    public class ConcreteTask : Task
    {
        public TimeSpan Estimation { get; set; }
        public bool Requirement { get; set; }
        public DateTime StartTime { get; set; }
        public Frequency Frequency { get; set; }
        public List<CalendarDay> Days { get; set; }
        public List<Stage> Stages { get; set; }
    }
}