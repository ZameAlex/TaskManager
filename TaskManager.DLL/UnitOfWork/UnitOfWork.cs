using System;
using TaskManager.DLL.Interfaces;
using TaskManager.DLL.Repositories;
using TaskManager.DLL.DBContext;

namespace TaskManager.DLL.UnitOfWork
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

        public CalendarDayRepository CalendarDays
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

        public ConcreteTaskRepository ConcreteTasks
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

        public GlobalTaskRepository GlobalTasks
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

        public StageRepository Stages
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

        public ThemeRepository Themes
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

        public UserRepository Users
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