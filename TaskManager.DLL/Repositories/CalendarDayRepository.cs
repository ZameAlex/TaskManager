using System;
using System.Collections.Generic;
using TaskManager.DLL.DBContext;
using TaskManager.DLL.Models;
using TaskManager.Shared.Exceptions;

namespace TaskManager.DAL.Repositories
{
    public class CalendarDayRepository : BaseRepository<CalendarDay>
    {
        public CalendarDayRepository(TaskManagerContext tmContext) : base(tmContext)
        {

        }

        public override void Update(int id, CalendarDay entity)
        {
            var tmp = GetById(id);
            tmp.Date = entity.Date;
            tmp.FreeTime = entity.FreeTime;
            tmp.Tasks = entity.Tasks;
            tmContext.CalendarDays.Update(tmp);
            base.Update(id, tmp);
        }

        public void UpdateCalendarDayFreeTime(int id, TimeSpan freeTime)
        {
            var tmp = GetById(id);
            tmp.FreeTime += freeTime;
            tmContext.CalendarDays.Update(tmp);
            base.Update(id, tmp);
        }

        public void UpdateCalendarDayTasksByAddingTask(int id, Task task)
        {
            var tmp = GetById(id);
            tmp.Tasks.Add(task);
            tmContext.CalendarDays.Update(tmp);
            base.Update(id, tmp);
        }

        public void UpdateCalendarDayTasksByAddingTasks(int id, List<Task> tasks)
        {
            var tmp = GetById(id);
            foreach (var item in tasks)
            {
                tmp.Tasks.Add(item);
            }
            tmContext.CalendarDays.Update(tmp);
            base.Update(id, tmp);
        }

        public void UpdateCalendarDayTasksByDeletingTask(int id, Task task)
        {
            var tmp = GetById(id);
            if (!tmp.Tasks.Remove(task))
            {
                throw new NotFoundException($"Task with id = {task.Id} wasn't found in list \"Tasks\".");
            }
            tmContext.CalendarDays.Update(tmp);
            base.Update(id, tmp);
        }

        public void UpdateCalendarDayTasksByDeletingTasks(int id, List<Task> tasks)
        {
            var tmp = GetById(id);
            foreach (var item in tasks)
            {
                if (!tmp.Tasks.Remove(item))
                {
                    throw new NotFoundException($"Task with id = {item.Id} wasn't found in list \"Tasks\".");
                }
            }
            tmContext.CalendarDays.Update(tmp);
            base.Update(id, tmp);
        }
    }
}