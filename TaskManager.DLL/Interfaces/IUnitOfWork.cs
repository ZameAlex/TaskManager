using System;
using TaskManager.DLL.Models;

namespace TaskManager.DAL.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        IRepository<CalendarDay> CalendarDays { get; }
        IRepository<ConcreteTask> ConcreteTasks { get; }
        IRepository<GlobalTask> GlobalTasks { get; }
        IRepository<Stage> Stages { get; }
        IRepository<Theme> Themes { get; }
        IRepository<User> Users { get; }

        int SaveChanges();
    }
}