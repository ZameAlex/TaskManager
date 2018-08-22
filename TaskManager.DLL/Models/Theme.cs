using System;
using System.Collections.Generic;
using System.Text;

namespace TaskManager.DLL.Models
{
    public class Theme : Entity
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public List<Task> Tasks { get; set; }
    }
}
