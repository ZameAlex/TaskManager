using System;
using TaskManager.DAL.Interfaces;
using TaskManager.DAL.Repositories;
using TaskManager.DLL.DBContext;
using TaskManager.DLL.Models;

namespace TaskManager.DAL.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork
    {
        private CalendarDayRepository calendarDayRepository;
        private ConcreteTaskRepository concreteTaskRepository;
        private GlobalTaskRepository globalTaskRepository;
        private StageRepository stageRepository;
        private ThemeRepository themeRepository;
        private UserRepository userRepository;

        private readonly TaskManagerContext taskManagerContext;

        public UnitOfWork(TaskManagerContext taskManagerContext)
        {
            this.taskManagerContext = taskManagerContext;
        }

        #region Repositories

        public IRepository<CalendarDay> CalendarDays
        {
            get
            {
                if (calendarDayRepository == null)
                {
                    calendarDayRepository = new CalendarDayRepository(taskManagerContext);
                }
                return calendarDayRepository;
            }
        }

        public IRepository<ConcreteTask> ConcreteTasks
        {
            get
            {
                if (concreteTaskRepository == null)
                {
                    concreteTaskRepository = new ConcreteTaskRepository(taskManagerContext);
                }
                return concreteTaskRepository;
            }
        }

        public IRepository<GlobalTask> GlobalTasks
        {
            get
            {
                if (globalTaskRepository == null)
                {
                    globalTaskRepository = new GlobalTaskRepository(taskManagerContext);
                }
                return globalTaskRepository;
            }
        }

        public IRepository<Stage> Stages
        {
            get
            {
                if (stageRepository == null)
                {
                    stageRepository = new StageRepository(taskManagerContext);
                }
                return stageRepository;
            }
        }

        public IRepository<Theme> Themes
        {
            get
            {
                if (themeRepository == null)
                {
                    themeRepository = new ThemeRepository(taskManagerContext);
                }
                return themeRepository;
            }
        }

        public IRepository<User> Users
        {
            get
            {
                if (userRepository == null)
                {
                    userRepository = new UserRepository(taskManagerContext);
                }
                return userRepository;
            }
        }

        #endregion

        public void Dispose()
        {
            
        }

        public int SaveChanges()
        {
            throw new NotImplementedException();
        }
    }
}