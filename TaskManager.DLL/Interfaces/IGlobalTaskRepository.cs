using System;
using System.Collections.Generic;
using TaskManager.DLL.Models;

namespace TaskManager.DLL.Interfaces
{
    public interface IGlobalTaskRepository
    {
        void UpdateGlobalTaskEndDate(int id, DateTime endDate);

        void UpdateGlobalTaskTasksByAddingTask(int id, Task task);

        void UpdateGlobalTaskTasksByAddingTasks(int id, List<Task> tasks);

        void UpdateGlobalTaskTasksByDeletingTask(int id, Task task);

        void UpdateGlobalTaskTasksByDeletingTasks(int id, List<Task> tasks);
    }
}