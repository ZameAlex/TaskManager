using TaskManager.Shared.Enums;

namespace TaskManager.Shared.DTOs
{
    public abstract class TaskDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public Status Status { get; set; }
    }
}