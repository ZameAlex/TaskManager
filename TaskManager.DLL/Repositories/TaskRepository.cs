using System;
using System.Collections.Generic;
using System.IO;
using TaskManager.DLL.DBContext;
using TaskManager.DLL.Interfaces;
using TaskManager.DLL.Models;
using TaskManager.Shared.Enums;
using TaskManager.Shared.Exceptions;

namespace TaskManager.DLL.Repositories
{
    public class TaskRepository<TaskEntity> : BaseRepository<TaskEntity>, IConcreteTaskRepository, IGlobalTaskRepository where TaskEntity : Task
    {
        public TaskRepository(TaskManagerContext context) : base(context)
        {

        }

        public override void Update(int id, TaskEntity entity)
        {
            if (entity is ConcreteTask)
            {
                var concreteTask = entity as ConcreteTask;
                var tmp = GetById(id) as ConcreteTask;
                tmp.Name = concreteTask.Name;
                tmp.Description = concreteTask.Description;
                tmp.Status = concreteTask.Status;
                tmp.Estimation = concreteTask.Estimation;
                tmp.Requirement = concreteTask.Requirement;
                tmp.StartTime = concreteTask.StartTime;
                tmp.Frequency = concreteTask.Frequency;
                tmp.Days = concreteTask.Days;
                tmp.Stages = concreteTask.Stages;
                tmContext.ConcreteTasks.Update(tmp);
            }
            else if (entity is GlobalTask)
            {
                var globalTask = entity as GlobalTask;
                var tmp = GetById(id) as GlobalTask;
                tmp.Name = globalTask.Name;
                tmp.Description = globalTask.Description;
                tmp.Status = globalTask.Status;
                tmp.EndDate = globalTask.EndDate;
                tmp.Tasks = globalTask.Tasks;
                tmContext.GlobalTasks.Update(tmp);
            }
            else
                throw new NotFoundException();
            base.Update(id, entity);
        }

        public void UpdateTaskName(int id, string name)
        {
            var tmp = GetById(id);
            tmp.Name = name;
            if (tmp is ConcreteTask)
                tmContext.ConcreteTasks.Update(tmp as ConcreteTask);
            else if (tmp is GlobalTask)
                tmContext.GlobalTasks.Update(tmp as GlobalTask);
            else
                throw new NotFoundException();
            base.Update(id, tmp);
        }

        public void UpdateTaskDescription(int id, string description)
        {
            var tmp = GetById(id);
            tmp.Description = description;
            if (tmp is ConcreteTask)
                tmContext.ConcreteTasks.Update(tmp as ConcreteTask);
            else if (tmp is GlobalTask)
                tmContext.GlobalTasks.Update(tmp as GlobalTask);
            base.Update(id, tmp);
        }

        public void UpdateTaskStatus(int id, Status status)
        {
            var tmp = GetById(id);
            tmp.Status = status;
            if (tmp is ConcreteTask)
                tmContext.ConcreteTasks.Update(tmp as ConcreteTask);
            else if (tmp is GlobalTask)
                tmContext.GlobalTasks.Update(tmp as GlobalTask);

            base.Update(id, tmp);
        }

        #region ConcreteTaskMethods

        public void UpdateConcreteTaskEstimation(int id, TimeSpan estimation)
        {
            var tmp = GetById(id);
            if (tmp is ConcreteTask)
            {
                (tmp as ConcreteTask).Estimation = estimation;
                tmContext.ConcreteTasks.Update(tmp as ConcreteTask);
            }
            else
                throw new NotFoundException();
            base.Update(id, tmp as TaskEntity);
        }

        public void UpdateConcreteTaskDaysByAddingDay(int id, CalendarDay day)
        {
            throw new NotImplementedException();
        }

        public void UpdateConcreteTaskDaysByAddingDays(int id, List<CalendarDay> days)
        {
            throw new NotImplementedException();
        }

        public void UpdateConcreteTaskDaysByDeletingDay(int id, CalendarDay day)
        {
            throw new NotImplementedException();
        }

        public void UpdateConcreteTaskDaysByDeletingDays(int id, List<CalendarDay> days)
        {
            throw new NotImplementedException();
        }

        public void UpdateConcreteTaskFrequency(int id, Frequency frequency)
        {
            throw new NotImplementedException();
        }

        public void UpdateConcreteTaskRequirement(int id, bool requirement)
        {
            throw new NotImplementedException();
        }

        public void UpdateConcreteTaskStagesByAddingStage(int id, Stage stage)
        {
            throw new NotImplementedException();
        }

        public void UpdateConcreteTaskStagesByAddingStages(int id, List<Stage> stages)
        {
            throw new NotImplementedException();
        }

        public void UpdateConcreteTaskStagesByDeletingStage(int id, Stage stage)
        {
            throw new NotImplementedException();
        }

        public void UpdateConcreteTaskStagesByDeletingStages(int id, List<Stage> stages)
        {
            throw new NotImplementedException();
        }

        public void UpdateConcreteTaskStartTime(int id, DateTime startTime)
        {
            throw new NotImplementedException();
        }

        #endregion

        #region GlobalTaskMethods

        public void UpdateGlobalTaskEndDate(int id, DateTime endDate)
        {
            throw new NotImplementedException();
        }

        public void UpdateGlobalTaskTasksByAddingTask(int id, Task task)
        {
            throw new NotImplementedException();
        }

        public void UpdateGlobalTaskTasksByAddingTasks(int id, List<Task> tasks)
        {
            throw new NotImplementedException();
        }

        public void UpdateGlobalTaskTasksByDeletingTask(int id, Task task)
        {
            throw new NotImplementedException();
        }

        public void UpdateGlobalTaskTasksByDeletingTasks(int id, List<Task> tasks)
        {
            throw new NotImplementedException();
        }

        #endregion
    }
}
