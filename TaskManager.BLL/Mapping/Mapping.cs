using System;
using System.Collections.Generic;
using TaskManager.BLL.Interfaces;
using TaskManager.DLL.Models;
using TaskManager.DLL.Repositories;
using TaskManager.Shared.DTOs;

namespace TaskManager.BLL.Mapping
{
    public class Mapping : IMapper
    {
        private readonly CalendarDayRepository calendarDayRepo;
        private readonly ConcreteTaskRepository concreteTaskRepo;
        private readonly GlobalTaskRepository globalTaskRepo;
        private readonly StageRepository stageRepo;
        private readonly ThemeRepository themeRepo;
        private readonly UserRepository userRepo;

        public Mapping(CalendarDayRepository calendarDayRepo, ConcreteTaskRepository concreteTaskRepo, GlobalTaskRepository globalTaskRepo, 
            StageRepository stageRepo, ThemeRepository themeRepo, UserRepository userRepo)
        {
            this.calendarDayRepo = calendarDayRepo;
            this.concreteTaskRepo = concreteTaskRepo;
            this.globalTaskRepo = globalTaskRepo;
            this.stageRepo = stageRepo;
            this.themeRepo = themeRepo;
            this.userRepo = userRepo;
        }

        public CalendarDayDTO MapCalendarDay(CalendarDay value)
        {
            var list = new List<TaskDTO>();
            if (value.Tasks != null)
            {
                foreach (var item in value.Tasks)
                {
                    if (item is GlobalTask)
                    {
                        list.Add(MapGlobalTask((GlobalTask)item));
                    }
                    else if (item is ConcreteTask)
                    {
                        list.Add(MapConcreteTask((ConcreteTask)item));
                    }
                    else
                    {
                        throw new NotImplementedException();
                    }
                }
            }

            return new CalendarDayDTO()
            {
                Id = value.Id,
                Date = value.Date,
                FreeTime = value.FreeTime,
                Tasks = list
            };
        }

        public CalendarDay MapCalendarDay(CalendarDayDTO value)
        {
            var listRepoConcreteTasks = concreteTaskRepo.Get();
            var listRepoGlobalTasks = globalTaskRepo.Get();
            List<Task> listTasks = new List<Task>();
            listTasks.AddRange(listRepoConcreteTasks);
            listTasks.AddRange(listRepoGlobalTasks);

            var list = new List<Task>();
            if (value.Tasks != null)
            {
                foreach (var item in value.Tasks)
                {
                    foreach (var task in listTasks)
                    {
                        if (item.Id == task.Id)
                        {
                            list.Add(task);
                            goto Next;
                        }
                    }
                    Next:;
                }
            }

            return new CalendarDay
            {
                Id = value.Id,
                Date = value.Date,
                FreeTime = value.FreeTime,
                Tasks = list
            };
        }

        public ConcreteTaskDTO MapConcreteTask(ConcreteTask value)
        {
            var listDays = new List<CalendarDayDTO>();
            if (value.Days != null)
            {
                foreach (var item in value.Days)
                {
                    listDays.Add(MapCalendarDay(item));
                }
            }

            var listStages = new List<StageDTO>();
            if (value.Stages != null)
            {
                foreach (var item in value.Stages)
                {
                    listStages.Add(MapStage(item));
                }
            }

            return new ConcreteTaskDTO
            {
                Id = value.Id,
                Name = value.Name,
                Description = value.Description,
                Status = value.Status,
                Estimation = value.Estimation,
                Requirement = value.Requirement,
                StartTime = value.StartTime,
                Frequency = value.Frequency,
                Days = listDays,
                Stages = listStages
            };
        }

        public ConcreteTask MapConcreteTask(ConcreteTaskDTO value)
        {
            var listRepoCalendarDays = calendarDayRepo.Get();
            var listDays = new List<CalendarDay>();
            if (value.Days != null)
            {
                foreach (var item in value.Days)
                {
                    foreach (var day in listRepoCalendarDays)
                    {
                        if (item.Id == day.Id)
                        {
                            listDays.Add(day);
                            goto Next;
                        }
                    }
                Next:;
                }
            }

            var listRepoStages = stageRepo.Get();
            var listStages = new List<Stage>();
            if (value.Stages != null)
            {
                foreach (var item in value.Stages)
                {
                    foreach (var stage in listRepoStages)
                    {
                        if (item.Id == stage.Id)
                        {
                            listStages.Add(stage);
                            goto Next;
                        }
                    }
                Next:;
                }
            }

            return new ConcreteTask
            {
                Id = value.Id,
                Name = value.Name,
                Description = value.Description,
                Status = value.Status,
                Estimation = value.Estimation,
                Requirement = value.Requirement,
                StartTime = value.StartTime,
                Frequency = value.Frequency,
                Days = listDays,
                Stages = listStages
            };
        }

        public GlobalTaskDTO MapGlobalTask(GlobalTask value)
        {
            var list = new List<TaskDTO>();
            if (value.Tasks != null)
            {
                foreach (var item in value.Tasks)
                {
                    if (item is GlobalTask)
                    {
                        list.Add(MapGlobalTask((GlobalTask)item));
                    }
                    else if (item is ConcreteTask)
                    {
                        list.Add(MapConcreteTask((ConcreteTask)item));
                    }
                    else
                    {
                        throw new NotImplementedException();
                    }
                }
            }

            return new GlobalTaskDTO
            {
                Id = value.Id,
                Name = value.Name,
                Description = value.Description,
                Status = value.Status,
                EndDate = value.EndDate,
                Tasks = list
            };
        }

        public GlobalTask MapGlobalTask(GlobalTaskDTO value)
        {
            var listRepoConcreteTasks = concreteTaskRepo.Get();
            var listRepoGlobalTasks = globalTaskRepo.Get();
            List<Task> listTasks = new List<Task>();
            listTasks.AddRange(listRepoConcreteTasks);
            listTasks.AddRange(listRepoGlobalTasks);

            var list = new List<Task>();
            if (value.Tasks != null)
            {
                foreach (var item in value.Tasks)
                {
                    foreach (var task in listTasks)
                    {
                        if (item.Id == task.Id)
                        {
                            list.Add(task);
                            goto Next;
                        }
                    }
                Next:;
                }
            }

            return new GlobalTask
            {
                Id = value.Id,
                Name = value.Name,
                Description = value.Description,
                Status = value.Status,
                EndDate = value.EndDate,
                Tasks = list
            };
        }

        public StageDTO MapStage(Stage value)
        {
            return new StageDTO
            {
                Id = value.Id,
                Name = value.Name,
                Description = value.Description
            };
        }

        public Stage MapStage(StageDTO value)
        {
            return new Stage
            {
                Id = value.Id,
                Name = value.Name,
                Description = value.Description
            };
        }

        public ThemeDTO MapTheme(Theme value)
        {
            var list = new List<TaskDTO>();
            if (value.Tasks != null)
            {
                foreach (var item in value.Tasks)
                {
                    if (item is GlobalTask)
                    {
                        list.Add(MapGlobalTask((GlobalTask)item));
                    }
                    else if (item is ConcreteTask)
                    {
                        list.Add(MapConcreteTask((ConcreteTask)item));
                    }
                    else
                    {
                        throw new NotImplementedException();
                    }
                }
            }

            return new ThemeDTO
            {
                Id = value.Id,
                Name = value.Name,
                Description = value.Description,
                Tasks = list
            };
        }

        public Theme MapTheme(ThemeDTO value)
        {
            var listRepoConcreteTasks = concreteTaskRepo.Get();
            var listRepoGlobalTasks = globalTaskRepo.Get();
            List<Task> listTasks = new List<Task>();
            listTasks.AddRange(listRepoConcreteTasks);
            listTasks.AddRange(listRepoGlobalTasks);

            var list = new List<Task>();
            if (value.Tasks != null)
            {
                foreach (var item in value.Tasks)
                {
                    foreach (var task in listTasks)
                    {
                        if (item.Id == task.Id)
                        {
                            list.Add(task);
                            goto Next;
                        }
                    }
                Next:;
                }
            }

            return new Theme
            {
                Id = value.Id,
                Name = value.Name,
                Description = value.Description,
                Tasks = list
            };
        }

        public UserDTO MapUser(User value)
        {
            var listTasks = new List<TaskDTO>();
            if (value.Tasks != null)
            {
                foreach (var item in value.Tasks)
                {
                    if (item is GlobalTask)
                    {
                        listTasks.Add(MapGlobalTask((GlobalTask)item));
                    }
                    else if (item is ConcreteTask)
                    {
                        listTasks.Add(MapConcreteTask((ConcreteTask)item));
                    }
                    else
                    {
                        throw new NotImplementedException();
                    }
                }
            }

            var listThemes = new List<ThemeDTO>();
            if (value.Themes != null)
            {
                foreach (var item in value.Themes)
                {
                    listThemes.Add(MapTheme(item));
                }
            }

            return new UserDTO
            {
                Id = value.Id,
                Login = value.Login,
                Password = value.Password,
                Nickname = value.Nickname,
                Tasks = listTasks,
                Themes = listThemes
            };
        }

        public User MapUser(UserDTO value)
        {
            var listRepoConcreteTasks = concreteTaskRepo.Get();
            var listRepoGlobalTasks = globalTaskRepo.Get();
            List<Task> list = new List<Task>();
            list.AddRange(listRepoConcreteTasks);
            list.AddRange(listRepoGlobalTasks);

            var listTasks = new List<Task>();
            if (value.Tasks != null)
            {
                foreach (var item in value.Tasks)
                {
                    foreach (var task in list)
                    {
                        if (item.Id == task.Id)
                        {
                            listTasks.Add(task);
                            goto Next;
                        }
                    }
                Next:;
                }
            }

            var listRepoThemes = themeRepo.Get();
            var listThemes = new List<Theme>();
            if (value.Themes != null)
            {
                foreach (var item in value.Themes)
                {
                    foreach (var day in listRepoThemes)
                    {
                        if (item.Id == day.Id)
                        {
                            listThemes.Add(day);
                            goto Next;
                        }
                    }
                Next:;
                }
            }

            return new User
            {
                Id = value.Id,
                Login = value.Login,
                Password = value.Password,
                Nickname = value.Nickname,
                Tasks = listTasks,
                Themes = listThemes
            };
        }
    }
}