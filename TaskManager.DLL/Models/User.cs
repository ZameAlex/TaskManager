using System;
using System.Collections.Generic;
using System.Text;

namespace TaskManager.DLL.Models
{
    public class User : Entity
    {
        public string Login { get; set; }
        public string Password { get; set; }
        public List<Task> Tasks { get; set; }
        public List<Theme> Themes { get; set; }
    }
}
