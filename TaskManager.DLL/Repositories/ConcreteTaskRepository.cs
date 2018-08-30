using System;
using System.Collections.Generic;
using TaskManager.DLL.DBContext;
using TaskManager.DLL.Models;
using TaskManager.Shared.Enums;
using TaskManager.Shared.Exceptions;

namespace TaskManager.DAL.Repositories
{
    public class ConcreteTaskRepository : BaseRepository<ConcreteTask>
    {
        public ConcreteTaskRepository(TaskManagerContext tmContext) : base(tmContext)
        {

        }

        public override void Update(int id, ConcreteTask entity)
        {
            var tmp = GetById(id);
            tmp.Name = entity.Name;
            tmp.Description = entity.Description;
            tmp.Status = entity.Status;
            tmp.Estimation = entity.Estimation;
            tmp.Requirement = entity.Requirement;
            tmp.StartTime = entity.StartTime;
            tmp.Frequency = entity.Frequency;
            tmp.Days = entity.Days;
            tmp.Stages = entity.Stages;
            tmContext.ConcreteTasks.Update(tmp);
            base.Update(id, tmp);
        }

        public void UpdateConcreteTaskName(int id, string name)
        {
            var tmp = GetById(id);
            tmp.Name = name;
            tmContext.ConcreteTasks.Update(tmp);
            base.Update(id, tmp);
        }

        public void UpdateConcreteTaskDescription(int id, string description)
        {
            var tmp = GetById(id);
            tmp.Description = description;
            tmContext.ConcreteTasks.Update(tmp);
            base.Update(id, tmp);
        }

        public void UpdateConcreteTaskStatus(int id, Status status)
        {
            var tmp = GetById(id);
            tmp.Status = status;
            tmContext.ConcreteTasks.Update(tmp);
            base.Update(id, tmp);
        }

        public void UpdateConcreteTaskEstimation(int id, TimeSpan estimation)
        {
            var tmp = GetById(id);
            tmp.Estimation = estimation;
            tmContext.ConcreteTasks.Update(tmp);
            base.Update(id, tmp);
        }

        public void UpdateConcreteTaskRequirement(int id, bool requirement)
        {
            var tmp = GetById(id);
            tmp.Requirement = requirement;
            tmContext.ConcreteTasks.Update(tmp);
            base.Update(id, tmp);
        }

        public void UpdateConcreteTaskStartTime(int id, DateTime startTime)
        {
            var tmp = GetById(id);
            tmp.StartTime = startTime;
            tmContext.ConcreteTasks.Update(tmp);
            base.Update(id, tmp);
        }

        public void UpdateConcreteTaskFrequency(int id, Frequency frequency)
        {
            var tmp = GetById(id);
            tmp.Frequency = frequency;
            tmContext.ConcreteTasks.Update(tmp);
            base.Update(id, tmp);
        }

        public void UpdateConcreteTaskDaysByAddingDay(int id, CalendarDay day)
        {
            var tmp = GetById(id);
            tmp.Days.Add(day);
            tmContext.ConcreteTasks.Update(tmp);
            base.Update(id, tmp);
        }

        public void UpdateConcreteTaskDaysByAddingDays(int id, List<CalendarDay> days)
        {
            var tmp = GetById(id);
            foreach (var item in days)
            {
                tmp.Days.Add(item);
            }
            tmContext.ConcreteTasks.Update(tmp);
            base.Update(id, tmp);
        }

        public void UpdateConcreteTaskDaysByDeletingDay(int id, CalendarDay day)
        {
            var tmp = GetById(id);
            if (!tmp.Days.Remove(day))
            {
                throw new NotFoundException($"Day with id = {day.Id} wasn't found in list \"Days\".");
            }
            tmContext.ConcreteTasks.Update(tmp);
            base.Update(id, tmp);
        }

        public void UpdateConcreteTaskDaysByDeletingDays(int id, List<CalendarDay> days)
        {
            var tmp = GetById(id);
            foreach (var item in days)
            {
                if (!tmp.Days.Remove(item))
                {
                    throw new NotFoundException($"Day with id = {item.Id} wasn't found in list \"Days\".");
                }
            }
            tmContext.ConcreteTasks.Update(tmp);
            base.Update(id, tmp);
        }

        public void UpdateConcreteTaskStagesByAddingStage(int id, Stage stage)
        {
            var tmp = GetById(id);
            tmp.Stages.Add(stage);
            tmContext.ConcreteTasks.Update(tmp);
            base.Update(id, tmp);
        }

        public void UpdateConcreteTaskStagesByAddingStages(int id, List<Stage> stages)
        {
            var tmp = GetById(id);
            foreach (var item in stages)
            {
                tmp.Stages.Add(item);
            }
            tmContext.ConcreteTasks.Update(tmp);
            base.Update(id, tmp);
        }

        public void UpdateConcreteTaskStagesByDeletingStage(int id, Stage stage)
        {
            var tmp = GetById(id);
            if (!tmp.Stages.Remove(stage))
            {
                throw new NotFoundException($"Stage with id = {stage.Id} wasn't found in list \"Stages\".");
            }
            tmContext.ConcreteTasks.Update(tmp);
            base.Update(id, tmp);
        }

        public void UpdateConcreteTaskStagesByDeletingStages(int id, List<Stage> stages)
        {
            var tmp = GetById(id);
            foreach (var item in stages)
            {
                if (!tmp.Stages.Remove(item))
                {
                    throw new NotFoundException($"Stage with id = {item.Id} wasn't found in list \"Stages\".");
                }
            }
            tmContext.ConcreteTasks.Update(tmp);
            base.Update(id, tmp);
        }
    }
}