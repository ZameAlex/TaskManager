using TaskManager.Shared.Enums;

namespace TaskManager.DLL.Models
{
    public abstract class Task : DescriptiveEntity
    {
        public Status Status { get; set; }
    }
}