using Microsoft.EntityFrameworkCore;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using TaskManager.DLL.DBContext;
using TaskManager.DLL.Interfaces;
using TaskManager.DLL.Models;
using TaskManager.DLL.UnitOfWork;
using TaskManager.Shared.Enums;

namespace TaskManager.Tests.Repositories
{
    [TestFixture]
    public class CalendarDayRepositoryTests
    {
        TaskManagerContext taskManagerContext;
        IUnitOfWork unitOfWork;

        [OneTimeSetUp]
        public void SetUp()
        {
            var option = new DbContextOptionsBuilder<TaskManagerContext>();
            option.UseSqlServer("Server = DESKTOP-5S77NGN; Database = TaskManager; Trusted_Connection = True;");
            taskManagerContext = new TaskManagerContext(option.Options);
            unitOfWork = new UnitOfWork(taskManagerContext);
        }

        [Test]
        public void UpdateCalendarDayFreeTime_CalendarDay_When_update_Then_results_are_equals()
        {
            var id = unitOfWork.CalendarDays.Create(new CalendarDay()
            {
                Date = new DateTime(2018, 9, 2),
                FreeTime = new TimeSpan(23, 59, 59),
                Tasks = new List<Task>()
                {
                    new GlobalTask()
                    {
                        Name = "Task 3",
                        Description = "Description for \"Task 1\"",
                        Status = Status.NotStarted,
                        EndDate = new DateTime(2018, 10, 1),
                        Tasks = new List<Task>()
                    },
                    new GlobalTask()
                    {
                        Name = "Task 2",
                        Description = "Description for \"Task 2\"",
                        Status = Status.InProgress,
                        EndDate = new DateTime(2018, 10, 2),
                        Tasks = new List<Task>()
                    },
                    new GlobalTask()
                    {
                        Name = "Task 1",
                        Description = "Description for \"Task 3\"",
                        Status = Status.Done,
                        EndDate = new DateTime(2018, 10, 3),
                        Tasks = new List<Task>()
                    }
                }
            });
            unitOfWork.CalendarDays.UpdateCalendarDayFreeTime(id, new TimeSpan(0, -59, -59));
            var tmp = unitOfWork.CalendarDays.GetById(id);
            Assert.AreEqual(tmp.Id, id);
            Assert.AreEqual(tmp.FreeTime, new TimeSpan(23, 0, 0));
            unitOfWork.CalendarDays.DeleteById(id);
        }
    }
}
