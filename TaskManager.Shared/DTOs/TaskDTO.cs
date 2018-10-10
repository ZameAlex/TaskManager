using TaskManager.Shared.Enums;

namespace TaskManager.Shared.DTOs
{
    public abstract class TaskDTO : EntityDTO
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public Status Status { get; set; }
    }
}