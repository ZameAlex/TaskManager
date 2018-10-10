using System.Collections.Generic;

namespace TaskManager.Shared.DTOs
{
    public class UserDTO : EntityDTO
    {
        public string Login { get; set; }
        public string Password { get; set; }
        public string Nickname { get; set; }
        public List<TaskDTO> Tasks { get; set; }
        public List<ThemeDTO> Themes { get; set; }

        public UserDTO()
        {
            Tasks = new List<TaskDTO>();
            Themes = new List<ThemeDTO>();
        }
    }
}