using System;
using System.Collections.Generic;
using TaskManager.DLL.DBContext;
using TaskManager.DLL.Models;
using TaskManager.Shared.Enums;
using TaskManager.Shared.Exceptions;

namespace TaskManager.DLL.Repositories
{
    public class GlobalTaskRepository : BaseRepository<GlobalTask>
    {
        public GlobalTaskRepository(TaskManagerContext tmContext) : base(tmContext)
        {

        }

        public override void Update(int id, GlobalTask entity)
        {
            var tmp = GetById(id);
            tmp.Name = entity.Name;
            tmp.Description = entity.Description;
            tmp.Status = entity.Status;
            tmp.EndDate = entity.EndDate;
            tmp.Tasks = entity.Tasks;
            tmContext.GlobalTasks.Update(tmp);
            base.Update(id, tmp);
        }

        public void UpdateGlobalTaskName(int id, string name)
        {
            var tmp = GetById(id);
            tmp.Name = name;
            tmContext.GlobalTasks.Update(tmp);
            base.Update(id, tmp);
        }

        public void UpdateGlobalTaskDescription(int id, string description)
        {
            var tmp = GetById(id);
            tmp.Description = description;
            tmContext.GlobalTasks.Update(tmp);
            base.Update(id, tmp);
        }

        public void UpdateGlobalTaskStatus(int id, Status status)
        {
            var tmp = GetById(id);
            tmp.Status = status;
            tmContext.GlobalTasks.Update(tmp);
            base.Update(id, tmp);
        }

        public void UpdateGlobalTaskEndDate(int id, DateTime endDate)
        {
            var tmp = GetById(id);
            tmp.EndDate = endDate;
            tmContext.GlobalTasks.Update(tmp);
            base.Update(id, tmp);
        }

        public void UpdateGlobalTaskTasksByAddingTask(int id, Task task)
        {
            var tmp = GetById(id);
            tmp.Tasks.Add(task);
            tmContext.GlobalTasks.Update(tmp);
            base.Update(id, tmp);
        }

        public void UpdateGlobalTaskTasksByAddingTasks(int id, List<Task> tasks)
        {
            var tmp = GetById(id);
            foreach (var item in tasks)
            {
                tmp.Tasks.Add(item);
            }
            tmContext.GlobalTasks.Update(tmp);
            base.Update(id, tmp);
        }

        public void UpdateGlobalTaskTasksByDeletingTask(int id, Task task)
        {
            var tmp = GetById(id);
            if (!tmp.Tasks.Remove(task))
            {
                throw new NotFoundException($"Task with id = {task.Id} wasn't found in list \"Tasks\".");
            }
            tmContext.GlobalTasks.Update(tmp);
            base.Update(id, tmp);
        }

        public void UpdateGlobalTaskTasksByDeletingTasks(int id, List<Task> tasks)
        {
            var tmp = GetById(id);
            foreach (var item in tasks)
            {
                if (!tmp.Tasks.Remove(item))
                {
                    throw new NotFoundException($"Task with id = {item.Id} wasn't found in list \"Tasks\".");
                }
            }
            tmContext.GlobalTasks.Update(tmp);
            base.Update(id, tmp);
        }
    }
}