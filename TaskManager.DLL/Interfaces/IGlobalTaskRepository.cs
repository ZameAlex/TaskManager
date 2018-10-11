using System;
using System.Collections.Generic;
using TaskManager.DLL.Models;
using TaskManager.Shared.Enums;

namespace TaskManager.DLL.Interfaces
{
    public interface IGlobalTaskRepository
    {
        void UpdateGlobalTaskName(int id, string name);

        void UpdateGlobalTaskDescription(int id, string description);

        void UpdateGlobalTaskStatus(int id, Status status);

        void UpdateGlobalTaskEndDate(int id, DateTime endDate);

        void UpdateGlobalTaskTasksByAddingTask(int id, Task task);

        void UpdateGlobalTaskTasksByAddingTasks(int id, List<Task> tasks);

        void UpdateGlobalTaskTasksByDeletingTask(int id, Task task);

        void UpdateGlobalTaskTasksByDeletingTasks(int id, List<Task> tasks);
    }
}