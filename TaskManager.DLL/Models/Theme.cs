﻿using System;
using System.Collections.Generic;
using System.Text;

namespace TaskManager.DLL.Models
{
    public class Theme : DescriptiveEntity
    {
        public List<Task> Tasks { get; set; }
    }
}
