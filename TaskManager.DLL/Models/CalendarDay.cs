using System;
using System.Collections.Generic;
using System.Text;

namespace TaskManager.DLL.Models
{
    public class CalendarDay : Entity
    {
        public DateTime Date { get; set; }
        public TimeSpan FreeTime { get; set; }
        public List<Task> Tasks { get; set; }
    }
}
