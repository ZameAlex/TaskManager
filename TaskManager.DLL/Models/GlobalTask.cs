using System;
using System.Collections.Generic;
using System.Text;

namespace TaskManager.DLL.Models
{
    public class GlobalTask : Task
    {
        public DateTime EndDate { get; set; }
        public List<Task> Tasks { get; set; }
    }
}
