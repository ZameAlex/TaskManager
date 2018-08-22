using System;
using System.Collections.Generic;
using System.Text;
using TaskManager.Shared.Enums;

namespace TaskManager.DLL.Models
{
    public abstract class Task : Entity
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public Status Status { get; set; }
    }
}
