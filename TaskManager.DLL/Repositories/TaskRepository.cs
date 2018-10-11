using System;
using System.Collections.Generic;
using TaskManager.DLL.DBContext;
using TaskManager.DLL.Interfaces;
using TaskManager.DLL.Models;
using TaskManager.Shared.Enums;

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
            else
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
            base.Update(id, entity);
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

        public void UpdateConcreteTaskDescription(int id, string description)
        {
            throw new NotImplementedException();
        }

        public void UpdateConcreteTaskEstimation(int id, TimeSpan estimation)
        {
            throw new NotImplementedException();
        }

        public void UpdateConcreteTaskFrequency(int id, Frequency frequency)
        {
            throw new NotImplementedException();
        }

        public void UpdateConcreteTaskName(int id, string name)
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

        public void UpdateConcreteTaskStatus(int id, Status status)
        {
            throw new NotImplementedException();
        }

        public void UpdateGlobalTaskDescription(int id, string description)
        {
            throw new NotImplementedException();
        }

        public void UpdateGlobalTaskEndDate(int id, DateTime endDate)
        {
            throw new NotImplementedException();
        }

        public void UpdateGlobalTaskName(int id, string name)
        {
            throw new NotImplementedException();
        }

        public void UpdateGlobalTaskStatus(int id, Status status)
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
    }
}
