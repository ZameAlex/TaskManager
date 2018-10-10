using System.Collections.Generic;

namespace TaskManager.Shared.DTOs
{
    public class ThemeDTO : EntityDTO
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public List<TaskDTO> Tasks { get; set; }

        public ThemeDTO()
        {
            Tasks = new List<TaskDTO>();
        }
    }
}