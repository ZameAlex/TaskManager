using System;
using System.Collections.Generic;
using System.Text;
using TaskManager.Shared.Enums;

namespace TaskManager.DLL.Models
{
    public abstract class Task : DescriptiveEntity
    {
        public Status Status { get; set; }
    }
}
