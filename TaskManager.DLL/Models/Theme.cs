using System.Collections.Generic;

namespace TaskManager.DLL.Models
{
    public class Theme : DescriptiveEntity
    {
        public List<Task> Tasks { get; set; }
    }
}