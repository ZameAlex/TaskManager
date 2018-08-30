using System;
using System.Collections.Generic;

namespace TaskManager.DLL.Models
{
    public class GlobalTask : Task
    {
        public DateTime EndDate { get; set; }
        public List<Task> Tasks { get; set; }
    }
}