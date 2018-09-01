using System;
using TaskManager.DLL.Models;
using TaskManager.DLL.Repositories;

namespace TaskManager.DLL.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        CalendarDayRepository CalendarDays { get; }
        ConcreteTaskRepository ConcreteTasks { get; }
        GlobalTaskRepository GlobalTasks { get; }
        StageRepository Stages { get; }
        ThemeRepository Themes { get; }
        UserRepository Users { get; }

        int SaveChanges();
    }
}