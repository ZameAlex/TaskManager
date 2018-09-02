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
    public class ThemeRepositoryTests
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
        public void UpdateThemeTasksByAddingTask_When_update_results_are_equals()
        {
            var id = unitOfWork.Themes.Create(new Theme()
            {
                Name = "123",
                Description = "Description for \"123\"",
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
                    }
                }
            });
            unitOfWork.Themes.UpdateThemeTasksByAddingTask(id, new GlobalTask()
            {
                Name = "Task 1",
                Description = "Description for \"Task 3\"",
                Status = Status.Done,
                EndDate = new DateTime(2018, 10, 3),
                Tasks = new List<Task>()
            });
            Assert.AreEqual(unitOfWork.Themes.GetById(id).Tasks.Count, 3);
            Assert.AreEqual(unitOfWork.Themes.GetById(id).Tasks[unitOfWork.Themes.GetById(id).Tasks.Count - 1].Name, "Task 1");
            unitOfWork.Themes.DeleteById(id);
        }

        [Test]
        public void UpdateThemeTasksByAddingTasks_When_update_results_are_equals()
        {
            var id = unitOfWork.Themes.Create(new Theme()
            {
                Name = "123",
                Description = "Description for \"123\"",
                Tasks = new List<Task>()
                {
                    new GlobalTask()
                    {
                        Name = "Task 1",
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
                    }
                }
            });
            var list = new List<Task>()
            {
                new GlobalTask()
                {
                Name = "Task 3",
                Description = "Description for \"Task 3\"",
                Status = Status.Done,
                EndDate = new DateTime(2018, 10, 3),
                Tasks = new List<Task>()
                },
                new GlobalTask()
                {
                Name = "Task 4",
                Description = "Description for \"Task 3\"",
                Status = Status.Done,
                EndDate = new DateTime(2018, 10, 3),
                Tasks = new List<Task>()
                },
                new GlobalTask()
                {
                Name = "Task 5",
                Description = "Description for \"Task 3\"",
                Status = Status.Done,
                EndDate = new DateTime(2018, 10, 3),
                Tasks = new List<Task>()
                }
            };
            unitOfWork.Themes.UpdateThemeTasksByAddingTasks(id, list);
            Assert.AreEqual(unitOfWork.Themes.GetById(id).Tasks.Count, 5);
            int i = 1;
            foreach (var item in unitOfWork.Themes.GetById(id).Tasks)
            {
                Assert.AreEqual(item.Name, $"Task {i++}");
            }
            unitOfWork.Themes.DeleteById(id);
        }

        [Test]
        public void UpdateThemeTasksByDeletingTask_When_update_results_are_equals()
        {
            var id = unitOfWork.Themes.Create(new Theme()
            {
                Name = "123",
                Description = "Description for \"123\"",
                Tasks = new List<Task>()
                {
                    new GlobalTask()
                    {
                        Name = "Task 1",
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
                        Name = "Task 3",
                        Description = "Description for \"Task 3\"",
                        Status = Status.Done,
                        EndDate = new DateTime(2018, 10, 3),
                        Tasks = new List<Task>()
                    }
                }
            });           
            unitOfWork.Themes.UpdateThemeTasksByDeletingTask(id, unitOfWork.GlobalTasks.GetById(unitOfWork.Themes.GetById(id).Tasks[2].Id));
            Assert.AreEqual(unitOfWork.Themes.GetById(id).Tasks.Count, 2);
            int i = 1;
            foreach (var item in unitOfWork.Themes.GetById(id).Tasks)
            {
                Assert.AreEqual(item.Name, $"Task {i++}");
            }
            unitOfWork.Themes.DeleteById(id);
        }

        [Test]
        public void UpdateThemeTasksByDeletingTasks_When_update_results_are_equals()
        {
            var id = unitOfWork.Themes.Create(new Theme()
            {
                Name = "123",
                Description = "Description for \"123\"",
                Tasks = new List<Task>()
                {
                    new GlobalTask()
                    {
                        Name = "Task 1",
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
                        Name = "Task 3",
                        Description = "Description for \"Task 3\"",
                        Status = Status.Done,
                        EndDate = new DateTime(2018, 10, 3),
                        Tasks = new List<Task>()
                    }
                }
            });
            var list = new List<Task>();
            list.AddRange(unitOfWork.Themes.GetById(id).Tasks);
            unitOfWork.Themes.UpdateThemeTasksByDeletingTasks(id, list);
            Assert.AreEqual(unitOfWork.Themes.GetById(id).Tasks.Count, 0);
            unitOfWork.Themes.DeleteById(id);
        }
    }
}