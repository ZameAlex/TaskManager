using System;
using System.Collections.Generic;

namespace TaskManager.Shared.DTOs
{
    public class GlobalTaskDTO : TaskDTO
    {
        public DateTime EndDate { get; set; }
        public List<TaskDTO> Tasks { get; set; }

        public GlobalTaskDTO()
        {
            Tasks = new List<TaskDTO>();
        }
    }
}