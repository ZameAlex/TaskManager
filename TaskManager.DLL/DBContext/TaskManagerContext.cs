using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using TaskManager.DLL.Models;

namespace TaskManager.DLL.DBContext
{
    public class TaskManagerContext : DbContext
    {
        public DbSet<ConcreteTask> ConcreteTasks { get; set; }
        public DbSet<GlobalTask> GlobalTasks { get; set; }
        public DbSet<CalendarDay> CalendarDays { get; set; }
        public DbSet<Theme> Themes { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Stage> Stages { get; set; }

        public TaskManagerContext(DbContextOptions<TaskManagerContext> options) : base(options)
        {
            Database.Migrate();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }

        public DbSet<TEntity> SetOf<TEntity>() where TEntity : Entity
        {
            if (ConcreteTasks is IEnumerable<TEntity>)
                return ConcreteTasks as DbSet<TEntity>;
            else if (GlobalTasks is IEnumerable<TEntity>)
                return GlobalTasks as DbSet<TEntity>;
            else if (CalendarDays is IEnumerable<TEntity>)
                return CalendarDays as DbSet<TEntity>;
            else if (Themes is IEnumerable<TEntity>)
                return Themes as DbSet<TEntity>;
            else if (Stages is IEnumerable<TEntity>)
                return Stages as DbSet<TEntity>;
            else
                return Users as DbSet<TEntity>;
        }
    }
}