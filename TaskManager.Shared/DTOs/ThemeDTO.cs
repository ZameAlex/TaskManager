using System.Collections.Generic;

namespace TaskManager.Shared.DTOs
{
    public class ThemeDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public List<TaskDTO> Tasks { get; set; }

        public ThemeDTO()
        {
            Tasks = new List<TaskDTO>();
        }
    }
}